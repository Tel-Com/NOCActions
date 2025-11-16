using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace NOC_Actions
{
	public partial class UcDetalharFaturaDoCliente : UserControl
	{
		private readonly string arquivo_unidadeComPendenciaFinanceira = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "unidadeComPendenciaFinanceira.txt");
		private readonly string arquivo_operadoraQueBloqueouOServico = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "operadoraQueBloqueouOServico.txt");
		private readonly string arquivo_statusDoContrato = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "statusDoContrato.txt");
		
		public UcDetalharFaturaDoCliente()
		{
			InitializeComponent();
			
			if (checkBox_PermitirEdicaoSim.Checked)
			{
				checkBox_PermitirEdicaoNao.Checked = false;
			}
			CarregarItensNoForm(arquivo_unidadeComPendenciaFinanceira, comboBox_UnidadeASerNotificada);
			CarregarItensNoForm(arquivo_operadoraQueBloqueouOServico, textBox_TipoDeOperadoraDoContrato);
			CarregarItensNoForm(arquivo_statusDoContrato, textBox_StatusDaFatura);
			
		}
		
		private void MostrarUserControl(UserControl uc)
		{
			this.Controls.Clear();
			uc.Dock = DockStyle.Fill;
			this.Controls.Add(uc);
		}
		
		private string ObterSaudacao()
		{
			int hora = DateTime.Now.Hour;
			
			if (hora >= 5 && hora < 12)
				return "bom dia";
			else if (hora >= 12 && hora < 18)
				return "boa tarde";
			else
				return "boa noite";
		}
		
		private bool AnaliseDeCamposVazios()
		{
			if (string.IsNullOrWhiteSpace(comboBox_UnidadeASerNotificada.Text) &&
			    string.IsNullOrWhiteSpace(textBox_TipoDeOperadoraDoContrato.Text) &&
			    string.IsNullOrWhiteSpace(richTextBox_ObservacaoDaFatura.Text) &&
			    string.IsNullOrWhiteSpace(maskedTextBox_ValorDaFatura.Text) &&
			    string.IsNullOrWhiteSpace(maskedTextBox_VencimentoFatura.Text) &&
			    string.IsNullOrWhiteSpace(textBox_StatusDaFatura .Text) &&
			    string.IsNullOrWhiteSpace(textBox_CodigoDeBarrasDaFatura.Text))
			{
				return true;
			}
			return false;
		}
		
		private string DetalhamentoDeFatura()
		{
			if (AnaliseDeCamposVazios())
			{
				MessageBox.Show("Por favor, preencha todos os campos!");
				return string.Empty;
			}

			string msn = "Prezados, " + ObterSaudacao() + "," + Environment.NewLine +
				"Informamos que foi identificado um bloqueio de caráter administrativo-financeiro no contrato da unidade " +
				comboBox_UnidadeASerNotificada.Text.ToUpper() + "." + Environment.NewLine +
				"A seguir, seguem os detalhes referentes à situação:" + Environment.NewLine + Environment.NewLine;

			string detalheFatura =
				"Operadora: " + textBox_TipoDeOperadoraDoContrato.Text + Environment.NewLine +
				"Valor da Fatura: " + maskedTextBox_ValorDaFatura.Text + Environment.NewLine +
				"Data de Vencimento: " + maskedTextBox_VencimentoFatura.Text + Environment.NewLine +
				"Código de Pagamento: " + textBox_CodigoDeBarrasDaFatura.Text + Environment.NewLine +
				"Status: " + textBox_StatusDaFatura.Text + Environment.NewLine +
				"Observações: " + richTextBox_ObservacaoDaFatura.Text + Environment.NewLine +
				"Religamento por inadimplemento: " + CheckReliguePorConfianca();

			return msn + detalheFatura;
		}

		private string CheckReliguePorConfianca()
		{
			if (religuePorConfianca_Sim.Checked)
			{
				religuePorConfianca_Nao.Checked = false;
				return "O procedimento de religamento por confiança foi realizado pela operadora.";
			}
			else if (religuePorConfianca_Nao.Checked)
			{
				religuePorConfianca_Sim.Checked = false;
				return "O procedimento de religamento por confiança não foi realizado pela operadora.";
			}
			else
			{
				return "O status do religamento por confiança não foi definido.";
			}
		}
		
		private void AdicionarAoArquivo(ComboBox comboBox, string valorAdicionado)
		{
			string valor = comboBox.Text.Trim();
			
			if (!string.IsNullOrWhiteSpace(valor) && !comboBox.Items.Contains(valor)) {
				
				comboBox.Items.Add(valor);
				comboBox.Text = "";
				SalvarNoArquivo(comboBox, valorAdicionado);
				
			}
		}
		
		private void SalvarNoArquivo(ComboBox comboBox, string arquivoCaminho)
		{
			try {
				File.WriteAllLines(arquivoCaminho, comboBox.Items.Cast<string>());
			} catch (Exception ex) {
				MessageBox.Show(string.Format("Erro ao salvar os dados: {0}", ex.Message), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		private void CarregarItensNoForm(string arquivoTxt, ComboBox comboBox)
		{
			if (File.Exists(arquivoTxt)) {
				comboBox.Items.Clear();
				string[] item = File.ReadAllLines(arquivoTxt);
				comboBox.Items.AddRange(item);
			}
		}
		
		void BtnPreviaClick(object sender, EventArgs e)
		{
			string previa = DetalhamentoDeFatura();
			MessageBox.Show(previa);
		}
		
		void BtnVoltarClick(object sender, EventArgs e)
		{
			MostrarUserControl(new UcPendenciaFinanceiraInformes());
		}
		
		void BtnGravarECopiarInformacoesDetalhadasClick(object sender, EventArgs e)
		{
			
			AdicionarAoArquivo(comboBox_UnidadeASerNotificada, arquivo_unidadeComPendenciaFinanceira);
			AdicionarAoArquivo(textBox_TipoDeOperadoraDoContrato, arquivo_operadoraQueBloqueouOServico);
			AdicionarAoArquivo(textBox_StatusDaFatura,  arquivo_statusDoContrato);
			
			string msn = DetalhamentoDeFatura();
			Clipboard.SetText(msn);
		}
		
		void CheckBox_PermitirEdicaoSimCheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_PermitirEdicaoSim.Checked)
			{
				checkBox_PermitirEdicaoNao.Checked = false;
				label_modoDiretorAtivado.Visible = true;
				DesabilitarComponentesQuandoOModoEditorForAtivado(true);
			}
		}

		void CheckBox_PermitirEdicaoNaoCheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_PermitirEdicaoNao.Checked)
			{
				checkBox_PermitirEdicaoSim.Checked = false;
				label_modoDiretorAtivado.Visible = false;
				DesabilitarComponentesQuandoOModoEditorForAtivado(false);
			}
		}

		
		void DesabilitarComponentesQuandoOModoEditorForAtivado(bool modoAtivo)
		{
			if (modoAtivo)
			{
				btnDeletarItemSelecionadoNaLista.Enabled = true;
				btnDeletarLista.Enabled = true;
				richTextBox_ObservacaoDaFatura.Enabled = false;
				maskedTextBox_ValorDaFatura.Enabled = false;
				maskedTextBox_VencimentoFatura.Enabled = false;
				textBox_CodigoDeBarrasDaFatura.Enabled = false;
				btnPrevia.Enabled = false;
				btnApagarOsCampos.Enabled = false;
				btnGravarECopiarInformacoesDetalhadas.Enabled = false;
				religuePorConfianca_Sim.Enabled = false;
				religuePorConfianca_Nao.Enabled = false;
			}
			else
			{
				btnDeletarItemSelecionadoNaLista.Enabled = false;
				btnDeletarLista.Enabled = false;
				richTextBox_ObservacaoDaFatura.Enabled = true;
				maskedTextBox_ValorDaFatura.Enabled = true;
				maskedTextBox_VencimentoFatura.Enabled = true;
				textBox_CodigoDeBarrasDaFatura.Enabled = true;
				btnPrevia.Enabled = true;
				btnApagarOsCampos.Enabled = true;
				btnGravarECopiarInformacoesDetalhadas.Enabled = true;
				religuePorConfianca_Sim.Enabled = true;
				religuePorConfianca_Nao.Enabled = true;
			}
		}
		
		void ReliguePorConfianca_SimCheckedChanged(object sender, EventArgs e)
		{
			if (religuePorConfianca_Sim.Checked) {
				religuePorConfianca_Nao.Checked = false;
			}
		}
		
		void ReliguePorConfianca_NaoCheckedChanged(object sender, EventArgs e)
		{
			if (religuePorConfianca_Nao.Checked) {
				religuePorConfianca_Sim.Checked = false;
			}
		}
	}
}