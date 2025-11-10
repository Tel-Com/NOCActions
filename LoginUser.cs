using System;
using System.Drawing;
using System.Windows.Forms;

namespace NOC_Actions
{
	public partial class LoginUser : Form
	{
		string machinaNameUser = Environment.UserName;

		public LoginUser()
		{
			InitializeComponent();
		}
		
		public LoginUser(string userName)
		{
			InitializeComponent();
			userName += machinaNameUser;
		}
		
		void BtnLoginClick(object sender, EventArgs e)
		{
			if (textBox1_userLogin.Text == machinaNameUser && textBox2_userPassword.Text == machinaNameUser) {
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
