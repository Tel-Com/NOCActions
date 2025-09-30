using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NOC_Actions
{
	public partial class Utilitarios : Form
	{
		string caminhoArquivo = "dados_richTextBox.txt";
		
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		private const int WM_NCLBUTTONDOWN = 0xA1;
		private const int HTCAPTION = 0x2;
		
		public Utilitarios()
		{
			InitializeComponent();
			
			if(File.Exists(caminhoArquivo)){
				richTextBox_TextoUtilitario.Text = File.ReadAllText(caminhoArquivo);
			}
			
			this.FormClosing += Utilitarios_FormClosing;
			label1.MouseDown += Label1_MouseDown;
		}
		
		private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
		
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
			}
		}
		
		private void Utilitarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(caminhoArquivo, richTextBox_TextoUtilitario.Text);
        }
		void BtnCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
