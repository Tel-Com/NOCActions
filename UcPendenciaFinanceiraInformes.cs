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
		
		private string GetCustomerNotificationMessage()
		{
			return "Prezados, informamos que foi identificado um bloqueio de natureza administrativo-financeira no contrato da unidade: " + Environment.NewLine + Environment.NewLine + txtFinBlockUnitName.Text.Trim();
		}
		void BtnCloseWindowClick(object sender, EventArgs e)
		{
			CloseWindow();
		}
		
		void BtnViewInvoiceDetailsClick(object sender, EventArgs e)
		{
			this.Hide();
			var open_userControl_window = new Uc_PendenciaFinanceira_UcDetalhamentoDeFatura();
			this.Parent.Controls.Add(open_userControl_window);
			open_userControl_window.Dock = DockStyle.Fill;
			open_userControl_window.BringToFront();
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
			txtFinBlockUnitName.Text="";
		}
		
		void CloseWindow()
		{
			this.FindForm().Close();
		}
		
	}
}
