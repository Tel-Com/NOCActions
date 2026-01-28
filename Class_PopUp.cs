using System.Windows.Forms;

namespace NOC_Actions
{
    // Centraliza a exibição de mensagens ao usuário
    internal class Class_PopUp
    {
        public void Mostrar(string mensagem, string titulo = "Aviso")
        {
            MessageBox.Show(
                mensagem,
                titulo,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
