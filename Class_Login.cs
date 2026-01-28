// Classe responsável por fornecer informações de autenticação do usuário
using System;

namespace NOC_Actions
{
    public class Class_Login
    {
        // Login baseado no usuário da máquina
        public string UserLogin_Windows { get; set; }

        // Login padrão para acesso administrativo
        public string UserLoginPadrao { get; set; }

        public Class_Login()
        {
            UserLogin_Windows = Environment.UserName;
            UserLoginPadrao = "nocadmin";
        }
    }
}
