using System;
using System.Windows.Forms;

namespace NOC_Actions
{
	public partial class UcLiberacaoDeAcessoSemPrevisao : UserControl
	{
		public UcLiberacaoDeAcessoSemPrevisao()
		{
			InitializeComponent();
		}
		void BtnGravarECopiarClick(object sender, EventArgs e)
		{
			string msn = "Prezados, necessário acionamento com a loja para liberação de acesso do(s) técnico(s) abaixo. Ainda não foi repassado previsão de chegada, assim que obtivermos iremos atualizar a thread."
				+ Environment.NewLine + Environment.NewLine
				+ richTextBox1_DadosTecnicos.Text;
			Clipboard.SetText(msn);
			richTextBox1_DadosTecnicos.Text = "";
		}
		void BtnApagarCamposClick(object sender, EventArgs e)
		{
			richTextBox1_DadosTecnicos.Text = "";
		}
		void BtnFecharJanelaClick(object sender, EventArgs e)
		{
			this.FindForm().Close();
		}
	}
}
