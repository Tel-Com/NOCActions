using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NOC_Actions
{
    public partial class Uc_AnaliseDeInfra : UserControl
    {
        #region Arquivos (persistência)

        private static readonly string AppData =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private readonly string _arquivoOperadora = Path.Combine(AppData, "arquivoOperadora.txt");
        private readonly string _arquivoUnidade = Path.Combine(AppData, "arquivoUnidade.txt");
        private readonly string _arquivoTipoAnalise = Path.Combine(AppData, "arquivoTipoAnalise.txt");

        #endregion

        #region Construtor

        public Uc_AnaliseDeInfra()
        {
            InitializeComponent();
            CarregarDadosIniciais();
        }

        #endregion

        #region Inicialização

        private void CarregarDadosIniciais()
        {
            CarregarItens(_arquivoOperadora, comboBox_OperadoraDaUnidade);
            CarregarItens(_arquivoUnidade, comboBox_unidade);
            CarregarItens(_arquivoTipoAnalise, comboBox_statusObtidoPelaOperadora);
        }

        #endregion

        #region Persistência

        private void SalvarItem(ComboBox comboBox, string caminhoArquivo)
        {
            var valor = comboBox.Text?.Trim();

            if (string.IsNullOrWhiteSpace(valor))
                return;

            if (comboBox.Items.Contains(valor))
                return;

            comboBox.Items.Add(valor);
            File.WriteAllLines(caminhoArquivo, comboBox.Items.Cast<string>());
        }

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

        private bool ExcluirSelecionado(ComboBox comboBox, string caminhoArquivo)
        {
            var valor = comboBox.SelectedItem as string;
            if (valor == null || !File.Exists(caminhoArquivo))
                return false;

            var linhas = File.ReadAllLines(caminhoArquivo).ToList();

            if (!linhas.Remove(valor))
                return false;

            File.WriteAllLines(caminhoArquivo, linhas);
            comboBox.Items.Remove(valor);
            comboBox.SelectedIndex = -1;

            return true;
        }

        private bool ExcluirTodos(ComboBox comboBox, string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo))
                return false;

            File.WriteAllText(caminhoArquivo, string.Empty);
            comboBox.Items.Clear();
            comboBox.SelectedIndex = -1;
            comboBox.Text = string.Empty;

            return true;
        }

        #endregion

        #region Eventos

        private void btnSalvarECopiar_Click(object sender, EventArgs e)
        {
            var operadora = comboBox_OperadoraDaUnidade.Text;
            var unidade = comboBox_unidade.Text;
            var status = comboBox_statusObtidoPelaOperadora.Text;

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

            // Salvar
            SalvarItem(comboBox_OperadoraDaUnidade, _arquivoOperadora);
            SalvarItem(comboBox_unidade, _arquivoUnidade);
            SalvarItem(comboBox_statusObtidoPelaOperadora, _arquivoTipoAnalise);

            // Copiar
            Clipboard.SetText(GerarMensagem(operadora, unidade, status));

            // Feedback correto
            MessageBox.Show(
                "Itens salvos e mensagem copiada para a área de transferência.",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            LimparCampos();
        }

        private void btnGerarAlerta_Click(object sender, EventArgs e)
        {
            richTextBox_MensagemASerEncaminhadaAoCliente.Text =
                GerarMensagem(
                    comboBox_OperadoraDaUnidade.Text,
                    comboBox_unidade.Text,
                    comboBox_statusObtidoPelaOperadora.Text
                );
        }

        private void bntExcluirSelecionado_Click(object sender, EventArgs e)
        {
            var excluiu = false;

            excluiu |= ExcluirSelecionado(comboBox_OperadoraDaUnidade, _arquivoOperadora);
            excluiu |= ExcluirSelecionado(comboBox_unidade, _arquivoUnidade);
            excluiu |= ExcluirSelecionado(comboBox_statusObtidoPelaOperadora, _arquivoTipoAnalise);

            MessageBox.Show(
                excluiu
                    ? "Item(ns) excluído(s) com sucesso!"
                    : "Selecione ao menos um item para excluir.",
                "Resultado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnExcluirTodosOsCampos_Click(object sender, EventArgs e)
        {
            var excluiu = false;

            excluiu |= ExcluirTodos(comboBox_OperadoraDaUnidade, _arquivoOperadora);
            excluiu |= ExcluirTodos(comboBox_unidade, _arquivoUnidade);
            excluiu |= ExcluirTodos(comboBox_statusObtidoPelaOperadora, _arquivoTipoAnalise);

            richTextBox_MensagemASerEncaminhadaAoCliente.Clear();

            MessageBox.Show(
                excluiu
                    ? "Todos os itens foram excluídos com sucesso!"
                    : "Não havia itens para excluir.",
                "Resultado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnApagarCampos_Click(object sender, EventArgs e)
        {
            richTextBox_MensagemASerEncaminhadaAoCliente.Clear();
            LimparCampos();
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            FindForm()?.Close();
        }

        #endregion

        #region Utilitários

        private void LimparCampos()
        {
            comboBox_OperadoraDaUnidade.Text = "";
            comboBox_unidade.Text = "";
            comboBox_statusObtidoPelaOperadora.Text = "";
            richTextBox_MensagemASerEncaminhadaAoCliente.Text = "";
        }

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

        private static string ObterSaudacao()
        {
            var hora = DateTime.Now.Hour;

            if (hora < 12) return "bom dia";
            if (hora < 18) return "boa tarde";
            return "boa noite";
        }

        #endregion
    }
}
