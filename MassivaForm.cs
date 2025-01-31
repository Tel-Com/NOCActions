/*
 * Created by SharpDevelop.
 * User: fjstavares
 * Date: 06/12/2024
 * Time: 09:37
 */

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NOCActions
{
	public partial class MassivaForm : Form
	{
		public MassivaForm()
		{
			InitializeComponent();
			this.TopMost = true;
			DefinirOrdemDosControles();
		}

		private void DefinirOrdemDosControles()
		{
			comboBoxEstados.TabIndex = 0;
			textBoxOperadora.TabIndex = 1;
			btnGerar.TabIndex = 2;
			buttonCopiar.TabIndex = 3;
			btnApagar.TabIndex = 4;
		}

		private void BtnGerarClick(object sender, EventArgs e)
		{
			GerarMensagemDeMassiva();
		}

		private void GerarMensagemDeMassiva()
		{
			textBoxExemplo.Clear();
			var estadoAfetado = comboBoxEstados.Text;
			var operadoraAfetada = textBoxOperadora.Text;
			var mensagemDeMassiva = string.Format("Possível massiva na região de {0} devido ambos os links da {1} caírem simultaneamente.", estadoAfetado, operadoraAfetada);
			textBoxExemplo.Text = mensagemDeMassiva;
		}
		void ButtonCopiarClick(object sender, EventArgs e)
		{
			Clipboard.SetText(textBoxExemplo.Text);
		}
		void BtnApagarClick(object sender, EventArgs e)
		{
			comboBoxEstados.Text = string.Empty;
			textBoxOperadora.Text = string.Empty;
			textBoxExemplo.Text = string.Empty;
		}
	}
}