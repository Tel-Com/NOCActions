using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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

        #region Persistência (Salvar / Carregar)

        private void SalvarOperadora()
        {
            SalvarItem(comboBox_operadoraUnidade, arquivoOperadora);
        }

        private void SalvarUnidade()
        {
            SalvarItem(comboBox_unidadeParaAnaliseEnergia, arquivoUnidade);
        }

        private void SalvarEndereco()
        {
            SalvarItem(comboBox_enderecoUnidade, arquivoEndereco);
        }

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

        #region Exclusão de Itens

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

        #region Eventos de Botões

        private void btnSalvarECopiar_Click(object sender, EventArgs e)
        {
            richTextBox_MensagemASerEncaminhadaAoCliente.Clear();

            string operadora = comboBox_operadoraUnidade.Text;
            string unidade = comboBox_unidadeParaAnaliseEnergia.Text;
            string endereco = comboBox_enderecoUnidade.Text;
            string horario = maskedTextBox_horarioQuedaCircuito.Text;
            string dataRef = maskedTextBox_dataReferencia.Text;

            // Salva os novos itens nos arquivos
            SalvarOperadora();
            SalvarUnidade();
            SalvarEndereco();

            LimparCampos();

            string mensagem = GerarMensagem(operadora, unidade, endereco, horario, dataRef);

            // Copia para a área de transferência
            Clipboard.SetText(mensagem);
        }


        private void btnEditarInformacoes_Click(object sender, EventArgs e)
        {
            bool excluiuAlgo = false;
            excluiuAlgo |= ExcluirSelecionado(comboBox_operadoraUnidade, arquivoOperadora);
            excluiuAlgo |= ExcluirSelecionado(comboBox_unidadeParaAnaliseEnergia, arquivoUnidade);
            excluiuAlgo |= ExcluirSelecionado(comboBox_enderecoUnidade, arquivoEndereco);

            MessageBox.Show(
                excluiuAlgo ? "Item(ns) excluído(s) com sucesso!" : "Selecione ao menos um item para excluir."
            );
        }


        private void btnApagarCampos_Click(object sender, EventArgs e)
        {
            richTextBox_MensagemASerEncaminhadaAoCliente.Clear();
            LimparCampos();
        }

        #endregion

        #region Utilitários

        private void LimparCampos()
        {
            comboBox_operadoraUnidade.Text = string.Empty;
            comboBox_unidadeParaAnaliseEnergia.Text = string.Empty;
            comboBox_enderecoUnidade.Text = string.Empty;
            maskedTextBox_horarioQuedaCircuito.Text = string.Empty;
            maskedTextBox_dataReferencia.Text = string.Empty;
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
                $"Solicitamos, gentilmente, que verifiquem a situação junto à unidade e nos mantenham informados sobre quaisquer atualizações.\n\n" +
                $"Atenciosamente,\n" +
                $"Equipe NOC";
        }

        private string ObterSaudacao()
        {
            int hora = DateTime.Now.Hour;

            if (hora >= 5 && hora < 12) return "bom dia";
            if (hora >= 12 && hora < 18) return "boa tarde";
            return "boa noite";
        }

        #endregion

        private void btnGerarAlerta_Click(object sender, EventArgs e)
        {
            // Limpa a mensagem antes de gerar
            richTextBox_MensagemASerEncaminhadaAoCliente.Clear();

            // Captura os valores atuais dos controles
            string operadora = comboBox_operadoraUnidade.Text;
            string unidade = comboBox_unidadeParaAnaliseEnergia.Text;
            string endereco = comboBox_enderecoUnidade.Text;
            string horario = maskedTextBox_horarioQuedaCircuito.Text;
            string dataRef = maskedTextBox_dataReferencia.Text;

            // Gera a mensagem e exibe no richTextBox
            string mensagem = GerarMensagem(operadora, unidade, endereco, horario, dataRef);
            richTextBox_MensagemASerEncaminhadaAoCliente.Text = mensagem;
        }

        private void btnApagarCampos_Click_1(object sender, EventArgs e)
        {
            ClearField();
        }

        void ClearField()
        {
            // Limpa todos os ComboBoxes
            comboBox_operadoraUnidade.Text = string.Empty;
            comboBox_unidadeParaAnaliseEnergia.Text = string.Empty;
            comboBox_enderecoUnidade.Text = string.Empty;

            // Limpa os MaskedTextBox
            maskedTextBox_horarioQuedaCircuito.Text = string.Empty;
            maskedTextBox_dataReferencia.Text = string.Empty;

            // Limpa o RichTextBox
            richTextBox_MensagemASerEncaminhadaAoCliente.Clear();
        }

        void CloseJanelinha()
        {
            this.FindForm().Close();
        }


        private void btnCloseWindow_Click_1(object sender, EventArgs e) => CloseJanelinha();
    }
}