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
		
		private void MostrarUserControl(UserControl uc)
		{
			this.Controls.Clear();
			uc.Dock = DockStyle.Fill;
			this.Controls.Add(uc);
		}
		
		private string GetCustomerNotificationMessage()
		{
			return "Prezados, informamos que foi identificado um bloqueio de natureza administrativo-financeira no contrato da unidade: " + Environment.NewLine + Environment.NewLine + txtFinBlockUnitName.Text.Trim();
			
			if (checkBoxDetalharFatura.Checked)
			{
				
			}
			
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
		
		void BtnViewInvoiceDetailsClick(object sender, EventArgs e)
		{
			MostrarUserControl(new UcDetalharFaturaDoCliente());
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
