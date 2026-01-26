using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NOC_Actions
{
    /// <summary>
    /// UserControl responsável por registrar e comunicar bloqueios financeiros,
    /// permitindo persistência de dados, geração de mensagens formais
    /// e gerenciamento completo dos itens cadastrados.
    /// </summary>
    public partial class Uc_BloqueioFinanceiro : UserControl
    {
        #region Arquivos (Persistência)

        // Caminho base do AppData do usuário logado
        private static readonly string AppData =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        // Arquivo responsável por armazenar as unidades com bloqueio financeiro
        private readonly string arquivo_unidade =
            Path.Combine(AppData, "unidadeBloqueioFinanceiro.txt");

        // Arquivo responsável por armazenar os endereços das unidades
        private readonly string arquivo_endereco =
            Path.Combine(AppData, "enderecoUnidadeBloqueioFinanceiro.txt");

        // Arquivo responsável por armazenar as operadoras com bloqueio financeiro
        private readonly string arquivo_operadora =
            Path.Combine(AppData, "operadoraComBloqueioFinanceiro.txt");

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor do UserControl.
        /// Inicializa os componentes visuais e carrega as informações persistidas.
        /// </summary>
        public Uc_BloqueioFinanceiro()
        {
            InitializeComponent();
            CarregarInformacoes();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Salva os dados informados, gera a mensagem de bloqueio financeiro
        /// e copia automaticamente para a área de transferência.
        /// </summary>
        private void btnSalvarECopiar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            // Persiste os dados digitados nos respectivos arquivos
            SalvarItem(comboBox_unidadeComBloqueioFinanceiro, arquivo_unidade);
            SalvarItem(comboBox_enderecoRespectivoDoBloqueioFinanceiro, arquivo_endereco);
            SalvarItem(comboBox_operadoraComBloqueioFinanceiro, arquivo_operadora);

            // Copia a mensagem gerada para o clipboard
            Clipboard.SetText(GerarMensagem());

            MessageBox.Show(
                "Itens salvos e mensagem copiada para a área de transferência.",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            LimparCampos();
        }

        /// <summary>
        /// Exibe a mensagem gerada em tela, sem salvar dados ou copiar para o clipboard.
        /// </summary>
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            MessageBox.Show(
                GerarMensagem(),
                "Visualização da Mensagem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        /// <summary>
        /// Limpa apenas os campos visuais do formulário.
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

        /// <summary>
        /// Exclui apenas os itens selecionados das listas e arquivos persistidos.
        /// </summary>
        private void bntExcluirSelecionado_Click(object sender, EventArgs e)
        {
            bool excluiu = false;

            excluiu |= ExcluirSelecionado(comboBox_unidadeComBloqueioFinanceiro, arquivo_unidade);
            excluiu |= ExcluirSelecionado(comboBox_enderecoRespectivoDoBloqueioFinanceiro, arquivo_endereco);
            excluiu |= ExcluirSelecionado(comboBox_operadoraComBloqueioFinanceiro, arquivo_operadora);

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
        /// Exclui todos os itens cadastrados e limpa completamente os arquivos,
        /// mediante confirmação explícita do usuário.
        /// </summary>
        private void btnExcluirTudoDasListas_Click(object sender, EventArgs e)
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

            excluiu |= ExcluirTodos(comboBox_unidadeComBloqueioFinanceiro, arquivo_unidade);
            excluiu |= ExcluirTodos(comboBox_enderecoRespectivoDoBloqueioFinanceiro, arquivo_endereco);
            excluiu |= ExcluirTodos(comboBox_operadoraComBloqueioFinanceiro, arquivo_operadora);

            MessageBox.Show(
                excluiu
                    ? "Todos os itens foram excluídos com sucesso."
                    : "Não havia itens cadastrados para exclusão.",
                excluiu ? "Sucesso" : "Atenção",
                MessageBoxButtons.OK,
                excluiu ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );
        }

        #endregion

        #region Validações

        /// <summary>
        /// Valida se todos os campos obrigatórios foram corretamente preenchidos.
        /// </summary>
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(comboBox_unidadeComBloqueioFinanceiro.Text) ||
                string.IsNullOrWhiteSpace(comboBox_operadoraComBloqueioFinanceiro.Text) ||
                !maskedTextBox_valorAPagar.MaskCompleted ||
                !maskedTextBox_dataDaReferencia.MaskCompleted ||
                !maskedTextBox_horarioQueda.MaskCompleted)
            {
                MessageBox.Show(
                    "Preencha todos os campos antes de continuar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }

        #endregion

        #region Mensagem

        /// <summary>
        /// Gera a mensagem formal de bloqueio financeiro,
        /// formatando valores monetários, data e horário.
        /// </summary>
        private string GerarMensagem()
        {
            // Converte o valor informado respeitando a cultura atual
            decimal valor = decimal.Parse(
                maskedTextBox_valorAPagar.Text,
                CultureInfo.CurrentCulture
            );

            DateTime data = DateTime.Parse(maskedTextBox_dataDaReferencia.Text);
            DateTime hora = DateTime.Parse(maskedTextBox_horarioQueda.Text);

            return
                $"Prezados, {ObterSaudacao()}.\n\n" +
                $"Informamos que a unidade {comboBox_unidadeComBloqueioFinanceiro.Text} encontra-se inoperante " +
                $"devido a bloqueio financeiro junto à operadora {comboBox_operadoraComBloqueioFinanceiro.Text}.\n\n" +
                $"Valor pendente: R$ {valor:N2}\n" +
                $"Data de referência: {data:dd/MM/yyyy}\n" +
                $"Início da indisponibilidade: {hora:HH:mm}\n\n" +
                $"Atenciosamente,\nEquipe NOC";
        }

        /// <summary>
        /// Retorna a saudação adequada de acordo com o horário atual.
        /// </summary>
        private static string ObterSaudacao()
        {
            int hora = DateTime.Now.Hour;

            if (hora < 12) return "bom dia";
            if (hora < 18) return "boa tarde";
            return "boa noite";
        }

        #endregion

        #region Utilidades

        /// <summary>
        /// Limpa todos os campos visuais do formulário,
        /// sem afetar os dados persistidos.
        /// </summary>
        private void LimparCampos()
        {
            comboBox_unidadeComBloqueioFinanceiro.Text = "";
            comboBox_enderecoRespectivoDoBloqueioFinanceiro.Text = "";
            comboBox_operadoraComBloqueioFinanceiro.Text = "";

            maskedTextBox_valorAPagar.Clear();
            maskedTextBox_dataDaReferencia.Clear();
            maskedTextBox_horarioQueda.Clear();
        }

        #endregion

        #region Arquivos

        /// <summary>
        /// Salva um novo item no ComboBox e persiste em arquivo,
        /// evitando valores vazios ou duplicados.
        /// </summary>
        private void SalvarItem(ComboBox comboBox, string arquivo)
        {
            var valor = comboBox.Text?.Trim();

            if (string.IsNullOrWhiteSpace(valor))
                return;

            if (comboBox.Items.Contains(valor))
                return;

            comboBox.Items.Add(valor);
            File.WriteAllLines(arquivo, comboBox.Items.Cast<string>());
        }

        /// <summary>
        /// Exclui apenas o item selecionado do ComboBox e do arquivo correspondente.
        /// </summary>
        private bool ExcluirSelecionado(ComboBox comboBox, string arquivo)
        {
            var valor = comboBox.SelectedItem as string;

            if (valor == null || !File.Exists(arquivo))
                return false;

            var linhas = File.ReadAllLines(arquivo).ToList();

            if (!linhas.Remove(valor))
                return false;

            File.WriteAllLines(arquivo, linhas);
            comboBox.Items.Remove(valor);
            comboBox.SelectedIndex = -1;

            return true;
        }

        /// <summary>
        /// Exclui todos os itens do ComboBox e limpa completamente o arquivo.
        /// </summary>
        private bool ExcluirTodos(ComboBox comboBox, string arquivo)
        {
            if (!File.Exists(arquivo))
                return false;

            File.WriteAllText(arquivo, string.Empty);
            comboBox.Items.Clear();
            comboBox.SelectedIndex = -1;
            comboBox.Text = string.Empty;

            return true;
        }

        /// <summary>
        /// Carrega os dados persistidos anteriormente nos ComboBoxes.
        /// </summary>
        private void CarregarInformacoes()
        {
            CarregarItens(arquivo_unidade, comboBox_unidadeComBloqueioFinanceiro);
            CarregarItens(arquivo_endereco, comboBox_enderecoRespectivoDoBloqueioFinanceiro);
            CarregarItens(arquivo_operadora, comboBox_operadoraComBloqueioFinanceiro);
        }

        /// <summary>
        /// Carrega itens de um arquivo para um ComboBox,
        /// removendo linhas vazias e duplicadas.
        /// </summary>
        private void CarregarItens(string arquivo, ComboBox comboBox)
        {
            if (!File.Exists(arquivo))
                return;

            comboBox.Items.Clear();
            comboBox.Items.AddRange(
                File.ReadAllLines(arquivo)
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .Distinct()
                    .ToArray()
            );
        }

        #endregion

        #region Close Form

        /// <summary>
        /// Fecha o formulário pai que contém este UserControl.
        /// </summary>
        private void CloseWindow()
        {
            FindForm()?.Close();
        }

        #endregion
    }
}
