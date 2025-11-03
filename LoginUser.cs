
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NOC_Actions
{
	public partial class LoginUser : Form
	{
		public LoginUser()
		{
			InitializeComponent();
		}
		void BtnLoginClick(object sender, EventArgs e)
		{
			if (textBox1_userLogin.Text == "admin" && textBox2_userPassword.Text == "admin") {
				MainForm open_mainForm = new MainForm();
				open_mainForm.Show();
				this.Hide();
			} else
			{
				MessageBox.Show("senha incorreta");
			}
		}
		void BtnSairClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
