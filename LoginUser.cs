using System;
using System.Windows.Forms;

namespace NOC_Actions
{
	public partial class LoginUser : Form
	{
		LoginUsuario class_login = new LoginUsuario();
		
		public LoginUser()
		{
			InitializeComponent();
		}
		
		public LoginUser(string userName)
		{
			InitializeComponent();
			userName += class_login;

		}
		
		void BtnLoginClick(object sender, EventArgs e)
		{
			if (textBox1_userLogin.Text == class_login.UserLogin_Windows && textBox2_userPassword.Text == class_login.UserLogin_Windows) {
				MainForm open_mainForm = new MainForm();
				open_mainForm.Show();
				this.Hide();
			} else
			{
				MessageBox.Show("Senha incorreta!");
			}
		}
		void BtnSairClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}

