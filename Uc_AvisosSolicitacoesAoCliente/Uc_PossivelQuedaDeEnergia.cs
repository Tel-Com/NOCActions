using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NOC_Actions
{
    public partial class Uc_PossivelQuedaDeEnergia : UserControl
    {
        #region Arquivos (Persistência)

        private static readonly string AppData =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private readonly string arquivoOperadora =
            Path.Combine(AppData, "arquivoOperadoraEnergia.txt");

        private readonly string arquivoUnidade =
            Path.Combine(AppData, "arquivoUnidadeEnergia.txt");

        private readonly string arquivoEndereco =
            Path.Combine(AppData, "arquivoEnderecoEnergia.txt");

        #endregion

        #region Construtor

        public Uc_PossivelQuedaDeEnergia()
        {
            InitializeComponent();
            CarregarDadosIniciais();
        }

        #endregion

        #region Inicialização

        private void CarregarDadosIniciais()
        {
            CarregarItens(arquivoOperadora, comboBox_operadoraUnidade);
            CarregarItens(arquivoUnidade, comboBox_unidadeParaAnaliseEnergia);
            CarregarItens(arquivoEndereco, comboBox_enderecoUnidade);
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

            if (string.IsNullOrWhiteSpace(valor))
                return false;

            if (!File.Exists(caminhoArquivo))
                return false;

            var linhas = File.ReadAllLines(caminhoArquivo).ToList();

            if (!linhas.Remove(valor))
                return false;

            File.WriteAllLines(caminhoArquivo, linhas);

            comboBox.Items.Remove(valor);
            comboBox.SelectedIndex = -1;
            comboBox.Text = "";

            return true;
        }

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

        private void btnApagarCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        #endregion

        #region Utilitários

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

        private void LimparCampos()
        {
            comboBox_operadoraUnidade.Text = "";
            comboBox_unidadeParaAnaliseEnergia.Text = "";
            comboBox_enderecoUnidade.Text = "";

            maskedTextBox_horarioQuedaCircuito.Clear();
            maskedTextBox_dataReferencia.Clear();

            richTextBox_MensagemASerEncaminhadaAoCliente.Clear();
        }

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

        private static string ObterSaudacao()
        {
            int hora = DateTime.Now.Hour;

            if (hora < 12) return "Bom dia";
            if (hora < 18) return "Boa tarde";
            return "Boa noite";
        }

        #endregion

        #region Close Form

        private void CloseWindow()
        {
            FindForm()?.Close();
        }


        #endregion

    }
}
