/*
 * Created by SharpDevelop.
 * User: fjstavares
 * Date: 26/02/2025
 * Time: 15:19
 */

using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace NOCActions
{
	public partial class MenuDeAcesso : Form
	{
		// Lista que armazena os caminhos dos arquivos anexados
		private List<string> arquivoAnexadoPeloAgente = new List<string>();
		
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		private const int WM_NCLBUTTONDOWN = 0xA1;
		private const int HTCAPTION = 0x2;
		
		public MenuDeAcesso()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
			panelTop.MouseDown += PanelConfiguracoes_MouseDown;
		}
		
		private void PanelConfiguracoes_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
			}
		}
		
//		button responsável para opções de abertura de Massiva Contratual
		void Button1AcaoAberturaDeMassivaClick(object sender, EventArgs e)
		{
			MassivaForm acaoAberturaDeMassivaForm = new MassivaForm();
			acaoAberturaDeMassivaForm.ShowDialog();
		}

		void ButtonComunicacaoComClienteClick(object sender, EventArgs e)
		{
			ACAO_ComunicacaoComCliente comunicacaoComClienteShowProject = new ACAO_ComunicacaoComCliente();
			comunicacaoComClienteShowProject.ShowDialog();
		}
		void BtnEmailAberturaDeReparoParaClienteClick(object sender, EventArgs e)
		{

			var getSoftwareExterno = @"C:\Users\fjstavares\Tel&Com_desenvolvimento_noc\NOC_Actions\bin\Debug\NOC_Email.exe";

			
			if (System.IO.File.Exists(getSoftwareExterno))
			{
				Process.Start(getSoftwareExterno);
			}
			else
			{
				MessageBox.Show("Não foi possível executar!");
			}
		}
	}
}
