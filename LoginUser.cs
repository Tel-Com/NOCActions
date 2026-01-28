using System;
using System.Windows.Forms;

namespace NOC_Actions
{
    // Tela responsável pela autenticação e acesso ao sistema
    public partial class LoginUser : Form
    {
        // Dependências de login e exibição de alertas
        private readonly Class_Login loginInfo = new Class_Login();
        private readonly Class_PopUp popupAlert = new Class_PopUp();

        public LoginUser()
        {
            InitializeComponent();
        }

        // Realiza a validação das credenciais e controla o fluxo de acesso
        private void BtnLoginClick(object sender, EventArgs e)
        {
            string usuarioDigitado = textBox1_userLogin.Text;
            string senhaDigitada = textBox2_userPassword.Text;

            bool loginWindowsValido =
                usuarioDigitado == loginInfo.UserLogin_Windows &&
                senhaDigitada == loginInfo.UserLogin_Windows;

            bool loginPadraoValido =
                usuarioDigitado == loginInfo.UserLoginPadrao &&
                senhaDigitada == loginInfo.UserLoginPadrao;

            if (loginWindowsValido || loginPadraoValido)
            {
                MainForm principal = new MainForm();
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Encerra a aplicação
        private void BtnSairClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Exibe orientações de acesso ao sistema
        private void btnAjuda_Click(object sender, EventArgs e)
        {
            popupAlert.Mostrar(
                "Acesse o NOCActions utilizando as credenciais padrão da sua máquina.\n\n" +
                "Caso necessite de acesso imediato, utilize as credenciais padrão abaixo:\n\n" +
                "Credenciais padrão:\n" +
                "Usuário: nocadmin\n" +
                "Senha: nocadmin\n\n" +
                "Credenciais da máquina:\n" +
                "Usuário: " + loginInfo.UserLogin_Windows + "\n" +
                "Senha: " + loginInfo.UserLogin_Windows + "\n\n" +
                "Em caso de dúvidas ou problemas de acesso, entre em contato com o suporte técnico.",
                "Ajuda — Acesso ao NOCActions"
            );
        }
    }
}
