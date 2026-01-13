using System.Drawing;
using System.Windows.Forms;

namespace NOC_Actions.Uc_AvisosSolicitacoesAoCliente
{
    public partial class AmpliarMensagemDeTexto_LiberacaoDeAcesso : Form
    {
        public AmpliarMensagemDeTexto_LiberacaoDeAcesso(string mensagem)
        {
            InitializeComponent();
            CriarLayout(mensagem);
        }

        private void CriarLayout(string mensagem)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(500, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var richTextBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Text = mensagem,
                Font = new Font("Segoe UI", 11),
                BackColor = Color.White,
                WordWrap = true,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };

            var btnFechar = new Button
            {
                Text = "Fechar",
                Dock = DockStyle.Bottom,
                Height = 42
            };

            btnFechar.Click += (s, e) => this.Close();

            this.Controls.Add(richTextBox);
            this.Controls.Add(btnFechar);
        }
    }
}
