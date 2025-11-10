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
		
		private string GetCustomerNotificationMessage()
		{
			string getValueUnidadeComQueda = txtUnitName.Text.Trim();
			const string msnValidacao = "Prezados, poderiam confirmar possível queda de energia na loja ";
			return msnValidacao
				+ getValueUnidadeComQueda + "? Constatamos que ambos os links estão indisponíveis neste momento.";
		}
		
		void BtnCloseWindowClick(object sender, EventArgs e)
		{
			CloseWindow();
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
			txtUnitName.Text = "";
		}
		
		void CloseWindow()
		{
			this.FindForm().Close();
		}
	}
}