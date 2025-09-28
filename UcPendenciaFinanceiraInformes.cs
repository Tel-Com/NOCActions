using System;
using System.Windows.Forms;


namespace NOC_Actions
{
	public partial class UcPendenciaFinanceiraInformes : UserControl
	{
		public UcPendenciaFinanceiraInformes()
		{
			InitializeComponent();
		}
		
		void BtnGravarECopiarClick(object sender, EventArgs e)
		{
			string getValueTextBox_textBox1_UnidadeComBloqueioFinanceiro = textBox1_UnidadeComBloqueioFinanceiro.Text;
			string msn = "Prezados, informamos que foi identificado um bloqueio de natureza administrativo-financeira no contrato da unidade: " + getValueTextBox_textBox1_UnidadeComBloqueioFinanceiro + ".";
			
			Clipboard.SetText(msn);
			textBox1_UnidadeComBloqueioFinanceiro.Text = "";
		}
		
		void BtnApagarCamposClick(object sender, EventArgs e)
		{
			textBox1_UnidadeComBloqueioFinanceiro.Text = "";
		}
		void BtnFecharJanelaClick(object sender, EventArgs e)
		{
			this.FindForm().Close();
		}
	}
}
