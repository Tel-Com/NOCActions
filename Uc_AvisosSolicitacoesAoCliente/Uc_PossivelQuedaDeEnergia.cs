using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NOC_Actions
{
    /// <summary>
    /// UserControl responsável por gerenciar alertas de possível queda de energia,
    /// permitindo persistir dados, gerar mensagens e copiá-las para o clipboard.
    /// </summary>
    public partial class Uc_PossivelQuedaDeEnergia : UserControl
    {
        #region Arquivos (Persistência)

        // Caminho base do AppData do usuário (ex: C:\Users\...\AppData\Roaming)
        private static readonly string AppData =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        // Arquivo responsável por armazenar as operadoras cadastradas
        private readonly string arquivoOperadora =
            Path.Combine(AppData, "arquivoOperadoraEnergia.txt");

        // Arquivo responsável por armazenar as unidades cadastradas
        private readonly string arquivoUnidade =
            Path.Combine(AppData, "arquivoUnidadeEnergia.txt");

        // Arquivo responsável por armazenar os endereços cadastrados
        private readonly string arquivoEndereco =
            Path.Combine(AppData, "arquivoEnderecoEnergia.txt");

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor do UserControl.
        /// Inicializa os componentes visuais e carrega os dados persistidos.
        /// </summary>
        public Uc_PossivelQuedaDeEnergia()
        {
            InitializeComponent();
            CarregarDadosIniciais();
        }

        #endregion

        #region Inicialização

        /// <summary>
        /// Carrega os dados salvos anteriormente nos ComboBoxes,
        /// garantindo persistência entre execuções da aplicação.
        /// </summary>
        private void CarregarDadosIniciais()
        {
            CarregarItens(arquivoOperadora, comboBox_operadoraUnidade);
            CarregarItens(arquivoUnidade, comboBox_unidadeParaAnaliseEnergia);
            CarregarItens(arquivoEndereco, comboBox_enderecoUnidade);
        }

        #endregion

        #region Persistência

        /// <summary>
        /// Salva um novo item digitado no ComboBox em arquivo,
        /// evitando duplicidade e valores vazios.
        /// </summary>
        private void SalvarItem(ComboBox comboBox, string caminhoArquivo)
        {
            var valor = comboBox.Text?.Trim();

            // Ignora valores vazios
            if (string.IsNullOrWhiteSpace(valor))
                return;

            // Evita salvar itens duplicados
            if (comboBox.Items.Contains(valor))
                return;

            // Adiciona ao ComboBox e persiste no arquivo
            comboBox.Items.Add(valor);
            File.WriteAllLines(caminhoArquivo, comboBox.Items.Cast<string>());
        }

        /// <summary>
        /// Carrega os itens de um arquivo para um ComboBox,
        /// removendo linhas vazias e duplicadas.
        /// </summary>
        private void CarregarItens(string caminhoArquivo, ComboBox comboBox)
        {
            if (!File.Exists(caminhoArquivo))
                return;

            comboBox.Items.Clear();
            comboBox.Items.AddRange(
                File.ReadAllLines(caminhoArquivo)
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .Distinct()
                    .ToArray()
            );
        }

        #endregion

        #region Exclusão

        /// <summary>
        /// Exclui apenas o item selecionado do ComboBox e do arquivo.
        /// </summary>
        private bool ExcluirSelecionado(ComboBox comboBox, string caminhoArquivo)
        {
            var valor = comboBox.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(valor))
                return false;

            if (!File.Exists(caminhoArquivo))
                return false;

            var linhas = File.ReadAllLines(caminhoArquivo).ToList();

            // Remove o item do arquivo
            if (!linhas.Remove(valor))
                return false;

            File.WriteAllLines(caminhoArquivo, linhas);

            // Remove o item do ComboBox
            comboBox.Items.Remove(valor);
            comboBox.SelectedIndex = -1;
            comboBox.Text = "";

            return true;
        }

        /// <summary>
        /// Exclui todos os itens do ComboBox e remove o arquivo físico.
        /// </summary>
        private bool ExcluirTodos(ComboBox comboBox, string caminhoArquivo)
        {
            bool haviaItens = comboBox.Items.Count > 0 || File.Exists(caminhoArquivo);

            comboBox.Items.Clear();
            comboBox.SelectedIndex = -1;
            comboBox.Text = "";

            if (File.Exists(caminhoArquivo))
                File.Delete(caminhoArquivo);

            return haviaItens;
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Salva os dados preenchidos, gera a mensagem e copia para o clipboard.
        /// </summary>
        private void btnSalvarECopiar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            SalvarItem(comboBox_operadoraUnidade, arquivoOperadora);
            SalvarItem(comboBox_unidadeParaAnaliseEnergia, arquivoUnidade);
            SalvarItem(comboBox_enderecoUnidade, arquivoEndereco);

            var mensagem = GerarMensagem(
                comboBox_operadoraUnidade.Text,
                comboBox_unidadeParaAnaliseEnergia.Text,
                comboBox_enderecoUnidade.Text,
                maskedTextBox_horarioQuedaCircuito.Text,
                maskedTextBox_dataReferencia.Text
            );

            Clipboard.SetText(mensagem);

            MessageBox.Show(
                "Itens salvos e mensagem copiada para a área de transferência.",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            LimparCampos();
        }

        /// <summary>
        /// Apenas gera a mensagem e exibe no RichTextBox, sem salvar dados.
        /// </summary>
        private void btnGerarAlerta_Click(object sender, EventArgs e)
        {
            richTextBox_MensagemASerEncaminhadaAoCliente.Text =
                GerarMensagem(
                    comboBox_operadoraUnidade.Text,
                    comboBox_unidadeParaAnaliseEnergia.Text,
                    comboBox_enderecoUnidade.Text,
                    maskedTextBox_horarioQuedaCircuito.Text,
                    maskedTextBox_dataReferencia.Text
                );
        }

        /// <summary>
        /// Exclui apenas os itens selecionados dos ComboBoxes.
        /// </summary>
        private void bntExcluirSelecionado_Click(object sender, EventArgs e)
        {
            bool excluiu = false;

            excluiu |= ExcluirSelecionado(comboBox_operadoraUnidade, arquivoOperadora);
            excluiu |= ExcluirSelecionado(comboBox_unidadeParaAnaliseEnergia, arquivoUnidade);
            excluiu |= ExcluirSelecionado(comboBox_enderecoUnidade, arquivoEndereco);

            MessageBox.Show(
                excluiu
                    ? "Item(ns) selecionado(s) excluído(s) com sucesso."
                    : "Selecione ao menos um item válido para exclusão.",
                excluiu ? "Sucesso" : "Atenção",
                MessageBoxButtons.OK,
                excluiu ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );
        }

        /// <summary>
        /// Exclui todos os dados persistidos após confirmação do usuário.
        /// </summary>
        private void btnExcluirTodosOsCampos_Click(object sender, EventArgs e)
        {
            var confirmacao = MessageBox.Show(
                "Tem certeza que deseja excluir TODOS os itens?\n\nEssa ação não poderá ser desfeita.",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacao != DialogResult.Yes)
                return;

            bool excluiu = false;

            excluiu |= ExcluirTodos(comboBox_operadoraUnidade, arquivoOperadora);
            excluiu |= ExcluirTodos(comboBox_unidadeParaAnaliseEnergia, arquivoUnidade);
            excluiu |= ExcluirTodos(comboBox_enderecoUnidade, arquivoEndereco);

            richTextBox_MensagemASerEncaminhadaAoCliente.Clear();

            MessageBox.Show(
                excluiu
                    ? "Todos os itens foram excluídos com sucesso."
                    : "Não havia itens cadastrados para exclusão.",
                excluiu ? "Sucesso" : "Atenção",
                MessageBoxButtons.OK,
                excluiu ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );
        }

        /// <summary>
        /// Limpa apenas os campos da tela, sem afetar dados persistidos.
        /// </summary>
        private void btnApagarCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        /// <summary>
        /// Fecha o formulário que contém este UserControl.
        /// </summary>
        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        #endregion

        #region Utilitários

        /// <summary>
        /// Valida se todos os campos obrigatórios foram preenchidos corretamente.
        /// </summary>
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(comboBox_operadoraUnidade.Text) ||
                string.IsNullOrWhiteSpace(comboBox_unidadeParaAnaliseEnergia.Text) ||
                string.IsNullOrWhiteSpace(comboBox_enderecoUnidade.Text) ||
                !maskedTextBox_horarioQuedaCircuito.MaskCompleted ||
                !maskedTextBox_dataReferencia.MaskCompleted)
            {
                MessageBox.Show(
                    "Preencha todos os campos antes de salvar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }

        /// <summary>
        /// Limpa todos os campos visuais da tela.
        /// </summary>
        private void LimparCampos()
        {
            comboBox_operadoraUnidade.Text = "";
            comboBox_unidadeParaAnaliseEnergia.Text = "";
            comboBox_enderecoUnidade.Text = "";

            maskedTextBox_horarioQuedaCircuito.Clear();
            maskedTextBox_dataReferencia.Clear();

            richTextBox_MensagemASerEncaminhadaAoCliente.Clear();
        }

        /// <summary>
        /// Monta a mensagem padrão a ser enviada ao cliente.
        /// </summary>
        private static string GerarMensagem(
            string operadora,
            string unidade,
            string endereco,
            string horario,
            string dataRef)
        {
            return
                $"Prezados,\n\n" +
                $"{ObterSaudacao()},\n\n" +
                $"Identificamos uma possível interrupção de energia no circuito abaixo.\n\n" +
                $"--- Detalhamento da Ocorrência ---\n" +
                $"Unidade: {unidade}\n" +
                $"Localização: {endereco}\n" +
                $"Data de referência: {dataRef}\n" +
                $"Horário estimado da ocorrência: {horario} horas\n" +
                $"Operadora responsável: {operadora}\n" +
                $"---------------------------------\n\n" +
                $"Solicitamos, gentilmente, que verifiquem a situação junto à unidade e nos mantenham informados.\n\n" +
                $"Atenciosamente,\nEquipe NOC";
        }

        /// <summary>
        /// Retorna a saudação adequada conforme o horário atual.
        /// </summary>
        private static string ObterSaudacao()
        {
            int hora = DateTime.Now.Hour;

            if (hora < 12) return "Bom dia";
            if (hora < 18) return "Boa tarde";
            return "Boa noite";
        }

        #endregion

        #region Close Form

        /// <summary>
        /// Fecha o formulário pai do UserControl.
        /// </summary>
        private void CloseWindow()
        {
            FindForm()?.Close();
        }

        #endregion
    }
}
