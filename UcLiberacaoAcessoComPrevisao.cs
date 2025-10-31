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
		
		private string GetCustomerNotificationMessage()
		{
			string getDadosTecnicos = richTextBoxTechnicalData.Text.Trim();
			string getPrevisaoChegada = textBoxEstimatedArrival.Text.Trim();
			
			return "Prezados, é necessário acionar a loja para a liberação de acesso do(s) técnico(s) abaixo. " +
				"Previsão de chegada às " + getPrevisaoChegada + ". Seguem os dados dos técnicos responsáveis pela solução do problema:" +
				Environment.NewLine + Environment.NewLine +
				getDadosTecnicos;
		}
		
		void BtnCloseWindowClick(object sender, EventArgs e)
		{
			CloseWindow();
		}
		
		void BtnPreviewMessageClick(object sender, EventArgs e)
		{
			// monta a mensagem com os campos atuais (sem precisar gravar/copiar)
			string getDadosTecnicos = richTextBoxTechnicalData.Text.Trim();
			string getPrevisaoChegada = textBoxEstimatedArrival.Text.Trim();

			if (string.IsNullOrWhiteSpace(getDadosTecnicos) ||
			    string.IsNullOrWhiteSpace(getPrevisaoChegada))
			{
				MessageBox.Show("Preencha todos os campos antes de ver a prévia.",
				                "Atenção",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Warning);
				return;
			}
			string previa = GetCustomerNotificationMessage();
			MessageBox.Show(previa, "Prévia da Mensagem",
			                MessageBoxButtons.OK,
			                MessageBoxIcon.Information);
		}
		
		void BtnClearFieldsClick(object sender, EventArgs e)
		{
			ClearField();
		}
		
		void BtnSaveAndCopyClick(object sender, EventArgs e)
		{
			string msn = GetCustomerNotificationMessage();
			Clipboard.SetText(msn);
			ClearField();
		}
		
		void ClearField()
		{
			richTextBoxTechnicalData.Text = "";
			textBoxEstimatedArrival.Text = "";
		}
		
		void CloseWindow()
		{
			this.FindForm().Close();
		}
	}
}
