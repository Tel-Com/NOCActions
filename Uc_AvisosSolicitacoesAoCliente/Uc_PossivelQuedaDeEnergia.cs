using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NOC_Actions
{
    public partial class Uc_PossivelQuedaDeEnergia : UserControl
    {
        #region Constantes / Caminhos de Arquivo

        private readonly string arquivoOperadora =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "arquivoOperadoraEnergia.txt");

        private readonly string arquivoUnidade =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "arquivoUnidadeEnergia.txt");

        private readonly string arquivoEndereco =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "arquivoEnderecoEnergia.txt");

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
            string valor = comboBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(valor))
                return;

            if (!comboBox.Items.Contains(valor))
            {
                comboBox.Items.Add(valor);
                File.WriteAllLines(caminhoArquivo, comboBox.Items.Cast<string>());
            }
        }

        private void CarregarItens(string arquivo, ComboBox comboBox)
        {
            if (!File.Exists(arquivo))
                return;

            comboBox.Items.Clear();
            comboBox.Items.AddRange(
                File.ReadAllLines(arquivo)
                    .Distinct()
                    .ToArray()
            );
        }

        #endregion

        #region Exclusão

        private bool ExcluirSelecionado(ComboBox comboBox, string caminhoArquivo)
        {
            if (comboBox.SelectedItem == null || !File.Exists(caminhoArquivo))
                return false;

            string valor = comboBox.SelectedItem.ToString();
            List<string> linhas = File.ReadAllLines(caminhoArquivo).ToList();

            if (!linhas.Remove(valor))
                return false;

            File.WriteAllLines(caminhoArquivo, linhas);
            comboBox.Items.Remove(valor);
            comboBox.SelectedIndex = -1;

            return true;
        }

        #endregion

        #region Eventos

        private void btnSalvarECopiar_Click(object sender, EventArgs e)
        {
            string operadora = comboBox_operadoraUnidade.Text;
            string unidade = comboBox_unidadeParaAnaliseEnergia.Text;
            string endereco = comboBox_enderecoUnidade.Text;

            if (string.IsNullOrWhiteSpace(operadora) ||
                string.IsNullOrWhiteSpace(unidade) ||
                string.IsNullOrWhiteSpace(endereco) ||
                !maskedTextBox_horarioQuedaCircuito.MaskCompleted ||
                !maskedTextBox_dataReferencia.MaskCompleted)
            {
                MessageBox.Show(
                    "Preencha todos os campos antes de salvar.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string horario = maskedTextBox_horarioQuedaCircuito.Text;
            string dataRef = maskedTextBox_dataReferencia.Text;

            // Salvar dados
            SalvarItem(comboBox_operadoraUnidade, arquivoOperadora);
            SalvarItem(comboBox_unidadeParaAnaliseEnergia, arquivoUnidade);
            SalvarItem(comboBox_enderecoUnidade, arquivoEndereco);

            // Gerar e copiar mensagem
            string mensagem = GerarMensagem(operadora, unidade, endereco, horario, dataRef);
            Clipboard.SetText(mensagem);

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
            string mensagem = GerarMensagem(
                comboBox_operadoraUnidade.Text,
                comboBox_unidadeParaAnaliseEnergia.Text,
                comboBox_enderecoUnidade.Text,
                maskedTextBox_horarioQuedaCircuito.Text,
                maskedTextBox_dataReferencia.Text
            );
            richTextBox_MensagemASerEncaminhadaAoCliente.Text = mensagem;
        }


        private void btnEditarInformacoes_Click(object sender, EventArgs e)
        {
            bool excluiu =
                ExcluirSelecionado(comboBox_operadoraUnidade, arquivoOperadora) |
                ExcluirSelecionado(comboBox_unidadeParaAnaliseEnergia, arquivoUnidade) |
                ExcluirSelecionado(comboBox_enderecoUnidade, arquivoEndereco);

            MessageBox.Show(
                excluiu ? "Item(ns) excluído(s) com sucesso!" : "Selecione ao menos um item para excluir."
            );
        }

        #endregion

        #region Utilitários

        private void btnApagarCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // Fechar userControl
        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        void CloseWindow()
        {
            this.FindForm().Close();
        }

        private void LimparCampos()
        {
            comboBox_operadoraUnidade.SelectedIndex = -1;
            comboBox_unidadeParaAnaliseEnergia.SelectedIndex = -1;
            comboBox_enderecoUnidade.SelectedIndex = -1;

            comboBox_operadoraUnidade.Text = string.Empty;
            comboBox_unidadeParaAnaliseEnergia.Text = string.Empty;
            comboBox_enderecoUnidade.Text = string.Empty;

            maskedTextBox_horarioQuedaCircuito.Clear();
            maskedTextBox_dataReferencia.Clear();

            richTextBox_MensagemASerEncaminhadaAoCliente.Clear();
        }


        private string GerarMensagem(string operadora, string unidade, string endereco, string horario, string dataRef)
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

        private string ObterSaudacao()
        {
            int hora = DateTime.Now.Hour;

            if (hora >= 5 && hora < 12) return "Bom dia";
            if (hora >= 12 && hora < 18) return "Boa tarde";
            return "Boa noite";
        }

        #endregion

    }
}
