using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NOC_Actions
{
    /// <summary>
    /// UserControl responsável pela análise de infraestrutura,
    /// permitindo persistência de dados, geração de mensagens
    /// e exclusão controlada das informações.
    /// </summary>
    public partial class Uc_AnaliseDeInfra : UserControl
    {
        #region Arquivos (Persistência)

        // Caminho base do AppData do usuário logado
        private static readonly string AppData =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        // Arquivo responsável por armazenar as operadoras cadastradas
        private readonly string _arquivoOperadora =
            Path.Combine(AppData, "arquivoOperadora.txt");

        // Arquivo responsável por armazenar as unidades cadastradas
        private readonly string _arquivoUnidade =
            Path.Combine(AppData, "arquivoUnidade.txt");

        // Arquivo responsável por armazenar os tipos/status de análise
        private readonly string _arquivoTipoAnalise =
            Path.Combine(AppData, "arquivoTipoAnalise.txt");

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor do UserControl.
        /// Inicializa os componentes visuais e carrega os dados persistidos.
        /// </summary>
        public Uc_AnaliseDeInfra()
        {
            InitializeComponent();
            CarregarDadosIniciais();
        }

        #endregion

        #region Inicialização

        /// <summary>
        /// Carrega os dados persistidos anteriormente para os ComboBoxes,
        /// garantindo reutilização das informações salvas.
        /// </summary>
        private void CarregarDadosIniciais()
        {
            CarregarItens(_arquivoOperadora, comboBox_OperadoraDaUnidade);
            CarregarItens(_arquivoUnidade, comboBox_unidade);
            CarregarItens(_arquivoTipoAnalise, comboBox_statusObtidoPelaOperadora);
        }

        #endregion

        #region Persistência

        /// <summary>
        /// Salva um novo item digitado no ComboBox em arquivo,
        /// evitando salvar valores vazios ou duplicados.
        /// </summary>
        private void SalvarItem(ComboBox comboBox, string caminhoArquivo)
        {
            var valor = comboBox.Text?.Trim();

            // Ignora valores inválidos
            if (string.IsNullOrWhiteSpace(valor))
                return;

            // Evita duplicidade
            if (comboBox.Items.Contains(valor))
                return;

            // Adiciona ao ComboBox e persiste em arquivo
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
        /// Exclui apenas o item selecionado do ComboBox e do arquivo correspondente.
        /// </summary>
        private bool ExcluirSelecionado(ComboBox comboBox, string caminhoArquivo)
        {
            var valor = comboBox.SelectedItem as string;

            if (valor == null || !File.Exists(caminhoArquivo))
                return false;

            var linhas = File.ReadAllLines(caminhoArquivo).ToList();

            // Remove o valor do arquivo
            if (!linhas.Remove(valor))
                return false;

            File.WriteAllLines(caminhoArquivo, linhas);

            // Remove o valor do ComboBox
            comboBox.Items.Remove(valor);
            comboBox.SelectedIndex = -1;

            return true;
        }

        /// <summary>
        /// Exclui todos os itens do ComboBox e limpa o arquivo físico.
        /// </summary>
        private bool ExcluirTodos(ComboBox comboBox, string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
                return false;

            // Limpa o conteúdo do arquivo
            File.WriteAllText(caminhoArquivo, string.Empty);

            // Limpa o ComboBox
            comboBox.Items.Clear();
            comboBox.SelectedIndex = -1;
            comboBox.Text = string.Empty;

            return true;
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Salva os dados preenchidos, gera a mensagem
        /// e copia automaticamente para a área de transferência.
        /// </summary>
        private void btnSalvarECopiar_Click(object sender, EventArgs e)
        {
            var operadora = comboBox_OperadoraDaUnidade.Text;
            var unidade = comboBox_unidade.Text;
            var status = comboBox_statusObtidoPelaOperadora.Text;

            // Validação básica de campos obrigatórios
            if (string.IsNullOrWhiteSpace(operadora) ||
                string.IsNullOrWhiteSpace(unidade) ||
                string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show(
                    "Preencha todos os campos antes de salvar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Persistência dos dados
            SalvarItem(comboBox_OperadoraDaUnidade, _arquivoOperadora);
            SalvarItem(comboBox_unidade, _arquivoUnidade);
            SalvarItem(comboBox_statusObtidoPelaOperadora, _arquivoTipoAnalise);

            // Copia a mensagem gerada para o clipboard
            Clipboard.SetText(GerarMensagem(operadora, unidade, status));

            MessageBox.Show(
                "Itens salvos e mensagem copiada para a área de transferência.",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            LimparCampos();
        }

        /// <summary>
        /// Gera a mensagem e exibe no RichTextBox,
        /// sem salvar ou persistir dados.
        /// </summary>
        private void btnGerarAlerta_Click(object sender, EventArgs e)
        {
            richTextBox_MensagemASerEncaminhadaAoCliente.Text =
                GerarMensagem(
                    comboBox_OperadoraDaUnidade.Text,
                    comboBox_unidade.Text,
                    comboBox_statusObtidoPelaOperadora.Text
                );
        }

        /// <summary>
        /// Exclui apenas os itens selecionados após confirmação do usuário.
        /// </summary>
        private void bntExcluirSelecionado_Click(object sender, EventArgs e)
        {
            var confirmacao = MessageBox.Show(
                "Deseja realmente excluir o(s) item(ns) selecionado(s)?",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacao != DialogResult.Yes)
                return;

            var excluiu = false;

            excluiu |= ExcluirSelecionado(comboBox_OperadoraDaUnidade, _arquivoOperadora);
            excluiu |= ExcluirSelecionado(comboBox_unidade, _arquivoUnidade);
            excluiu |= ExcluirSelecionado(comboBox_statusObtidoPelaOperadora, _arquivoTipoAnalise);

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
        /// Exclui todos os dados persistidos após confirmação explícita do usuário.
        /// </summary>
        private void btnExcluirTodosOsCampos_Click(object sender, EventArgs e)
        {
            var confirmacao = MessageBox.Show(
                "Tem certeza que deseja excluir TODOS os itens?\n\n" +
                "Essa ação não poderá ser desfeita.",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacao != DialogResult.Yes)
                return;

            var excluiu = false;

            excluiu |= ExcluirTodos(comboBox_OperadoraDaUnidade, _arquivoOperadora);
            excluiu |= ExcluirTodos(comboBox_unidade, _arquivoUnidade);
            excluiu |= ExcluirTodos(comboBox_statusObtidoPelaOperadora, _arquivoTipoAnalise);

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
        /// Limpa os campos da tela sem afetar os dados persistidos.
        /// </summary>
        private void btnApagarCampos_Click(object sender, EventArgs e)
        {
            richTextBox_MensagemASerEncaminhadaAoCliente.Clear();
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
        /// Limpa todos os campos visuais da tela.
        /// </summary>
        private void LimparCampos()
        {
            comboBox_OperadoraDaUnidade.Text = "";
            comboBox_unidade.Text = "";
            comboBox_statusObtidoPelaOperadora.Text = "";
            richTextBox_MensagemASerEncaminhadaAoCliente.Text = "";
        }

        /// <summary>
        /// Gera a mensagem padrão de análise de infraestrutura
        /// a ser encaminhada ao cliente.
        /// </summary>
        private static string GerarMensagem(string operadora, string unidade, string tipoAnalise)
        {
            return
                $"Prezados, {ObterSaudacao()}.\n\n" +
                $"Faço parte do NOC da Tel&Com e estou realizando uma análise interna na {unidade}.\n\n" +
                $"Poderiam, por gentileza, verificar o serviço da {operadora}? " +
                $"Conforme identificado pela fornecedora, o serviço encontra-se com o seguinte status: {tipoAnalise}.\n\n" +
                "Fico no aguardo.\n" +
                "Obrigado.";
        }

        /// <summary>
        /// Retorna a saudação adequada conforme o horário atual.
        /// </summary>
        private static string ObterSaudacao()
        {
            var hora = DateTime.Now.Hour;

            if (hora < 12) return "bom dia";
            if (hora < 18) return "boa tarde";
            return "boa noite";
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
