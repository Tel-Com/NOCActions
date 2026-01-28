using NOC_Actions.Uc_AvisosSolicitacoesAoCliente;
using System;
using System.Windows.Forms;

namespace NOC_Actions
{
    // Ponto de entrada da aplicação
    internal sealed class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicializa a aplicação exibindo a tela de login
            Application.Run(new LoginUser());
        }
    }
}
