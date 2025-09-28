using System;
using System.Windows.Forms;

namespace NOC_Actions
{
	public partial class UcLiberacaoDeAcessoComPrevisao : UserControl
	{
		public UcLiberacaoDeAcessoComPrevisao()
		{
			InitializeComponent();
		}
		void BtnGravarECopiarClick(object sender, EventArgs e)
		{
			
			string getDadosTecnicos = richTextBox1_DadosTecnicos.Text.Trim();
			string getPrevisaoChegada = textBox1_PrevisaoChegada.Text.Trim();

			string msn = "Prezados, necessário acionamento com a loja para liberação de acesso do(s) técnico(s) abaixo. "
				+ "Previsão de chegada às " + getPrevisaoChegada + "."
				+ Environment.NewLine + Environment.NewLine
				+ getDadosTecnicos;
			Clipboard.SetText(msn);
			richTextBox1_DadosTecnicos.Text = "";
			textBox1_PrevisaoChegada.Text = "";
		}
		void BtnApagarCamposClick(object sender, EventArgs e)
		{
			richTextBox1_DadosTecnicos.Text = "";
			textBox1_PrevisaoChegada.Text = "";
		}
		void BtnFecharJanelaClick(object sender, EventArgs e)
		{
			this.FindForm().Close();
		}
	}
}
