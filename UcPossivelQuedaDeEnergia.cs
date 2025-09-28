using System;
using System.Windows.Forms;

namespace NOC_Actions
{
	public partial class UcPossivelQuedaDeEnergia : UserControl
	{
		public UcPossivelQuedaDeEnergia()
		{
			InitializeComponent();
		}
		
		void BtnGravarECopiarClick(object sender, EventArgs e)
		{
			string getValueUnidadeComQueda = textBox1_UnidadeQueda.Text.Trim();

			string msn = "Prezados, poderiam confirmar possível queda de energia na loja "
				+ getValueUnidadeComQueda
				+ "? Constatamos que ambos os links estão indisponíveis neste momento.";
			Clipboard.SetText(msn);
			textBox1_UnidadeQueda.Text = "";
		}
		void BtnApagarCamposClick(object sender, EventArgs e)
		{
			textBox1_UnidadeQueda.Text = "";
		}
		void BtnFecharJanelaClick(object sender, EventArgs e)
		{
			this.FindForm().Close();
		}
	}
}
