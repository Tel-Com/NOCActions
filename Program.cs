using System;
using System.Windows.Forms;

namespace NOC_Actions        
{
    internal sealed class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginUser());
        }
    }
}
