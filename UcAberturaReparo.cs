using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NOC_Actions
{
	public partial class UcAberturaDeReparo : UserControl
	{
		public UcAberturaDeReparo()
		{
			InitializeComponent();
		}
		void BtnGravarECopiarClick(object sender, EventArgs e)
		{
			string getNumeroChamado = textBox1_ChamadoOperadora.Text.Trim();
			string getHorarioDeRegistro = textBox2_horarioDoRegistroChamado.Text.Trim();

			string msn = "Prezados, chamado " + getNumeroChamado + " registrado às " + getHorarioDeRegistro + " junto ao fornecedor.";

			Clipboard.SetText(msn); 
			
			textBox1_ChamadoOperadora.Text = "";
			textBox2_horarioDoRegistroChamado.Text = "";

		}
		void BtnApagarCamposClick(object sender, EventArgs e)
		{
			textBox1_ChamadoOperadora.Text = "";
			textBox2_horarioDoRegistroChamado.Text = "";
		}
		void BtnFecharJanelaClick(object sender, EventArgs e)
		{
			this.FindForm().Close();
		}
	}
}
