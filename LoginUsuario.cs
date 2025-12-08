//class destinada a pegar informações do login do usuário

using System;

namespace NOC_Actions
{
    public class LoginUsuario
    {
//    	login padrão de usuário na máquina
        public string UserLogin_Windows { get; set; }

        public LoginUsuario()
        {
            UserLogin_Windows = Environment.UserName;
        }
    }
}

