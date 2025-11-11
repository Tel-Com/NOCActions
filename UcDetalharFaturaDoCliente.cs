using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NOC_Actions
{
	public partial class UcDetalharFaturaDoCliente : UserControl
	{
		public UcDetalharFaturaDoCliente()
		{
			InitializeComponent();
		}
		
		private void MostrarUserControl(UserControl uc)
		{
			this.Controls.Clear();
			uc.Dock = DockStyle.Fill;
			this.Controls.Add(uc);
		}
		
		private bool AnaliseDeCamposVazios()
		{
			if (string.IsNullOrWhiteSpace(textBox_Unidade.Text) &&
			    string.IsNullOrWhiteSpace(textBox_OperadoraDaUnidade.Text) &&
			    string.IsNullOrWhiteSpace(richTextBox_ObservacaoDaFatura.Text) &&
			    string.IsNullOrWhiteSpace(maskedTextBox_ValorDaFatura.Text) &&
			    string.IsNullOrWhiteSpace(maskedTextBox_VencimentoFatura.Text) &&
			    string.IsNullOrWhiteSpace(textBox_StatusDaFatura.Text) &&
			    string.IsNullOrWhiteSpace(textBox_CodigoDeBarrasDaFatura.Text))
			{
				return true;
			}
			return false;
		}
		
		private string DetalhamentoDeFatura()
		{
			if (AnaliseDeCamposVazios()) {
				MessageBox.Show("Por favor, preencha todos os campos!");
				return string.Empty;
			}
			string msn = "Prezados, informamos que foi identificado um bloqueio de natureza administrativo-financeira no contrato da unidade " +textBox_Unidade.Text.ToUpper()+"." +Environment.NewLine +"Seguem abaixo os detalhes." +Environment.NewLine +Environment.NewLine;
			
			string detalheFatura = "Valor: " +maskedTextBox_ValorDaFatura.Text+ "" +Environment.NewLine+ "Vencimento: " +maskedTextBox_VencimentoFatura.Text+ "" +Environment.NewLine+ "Status da Fatura: " +textBox_StatusDaFatura.Text+ ""  +Environment.NewLine+ "Observação: " +richTextBox_ObservacaoDaFatura.Text;

			return msn + detalheFatura;
		}
		
//		Detalha o modo de tudo do UcDetalhamentoFaturaCliente.cs
		void BtnDuvidaClick(object sender, EventArgs e)
		{
			string a = DetalhamentoDeFatura();
			MessageBox.Show(a);
		}
		
		void BtnVoltarClick(object sender, EventArgs e)
		{
			MostrarUserControl(new UcPendenciaFinanceiraInformes());
		}
		
		void BtnGravarECopiarInformacoesDetalhadasClick(object sender, EventArgs e)
		{
			string msn = DetalhamentoDeFatura();
			Clipboard.SetText(msn);
		}
	}
}