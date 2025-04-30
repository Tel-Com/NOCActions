/*
 * Created by SharpDevelop.
 * User: fjstavares
 * Date: 26/02/2025
 * Time: 15:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NOCActions
{
	partial class MenuDeAcesso
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1AcaoAberturaDeMassiva;
//		private System.Windows.Forms.Button buttonAvaliacaoComCliente;
		private System.Windows.Forms.Button button3AberturaDeReparo;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button buttonComunicacaoComCliente;
		
		// Adicione no topo da classe
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Label labelTitulo;
		private System.Windows.Forms.Button buttonFechar;

		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();

			// Panel superior (cabeçalho preto)
			this.panelTop = new System.Windows.Forms.Panel();
			this.labelTitulo = new System.Windows.Forms.Label();
			this.buttonFechar = new System.Windows.Forms.Button();

			this.button1AcaoAberturaDeMassiva = new System.Windows.Forms.Button();
			this.button3AberturaDeReparo = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.buttonComunicacaoComCliente = new System.Windows.Forms.Button();

			this.SuspendLayout();

			// panelTop
			this.panelTop.BackColor = System.Drawing.Color.Black;
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Height = 40;
			this.panelTop.Controls.Add(this.labelTitulo);
			this.panelTop.Controls.Add(this.buttonFechar);

			// labelTitulo
			this.labelTitulo.ForeColor = System.Drawing.Color.White;
			this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.labelTitulo.Text = "Menu - Ações Específicas";
			this.labelTitulo.AutoSize = true;
			this.labelTitulo.Location = new System.Drawing.Point(10, 10);

			// buttonFechar
			this.buttonFechar.Text = "X";
			this.buttonFechar.ForeColor = System.Drawing.Color.White;
			this.buttonFechar.BackColor = System.Drawing.Color.Black;
			this.buttonFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFechar.FlatAppearance.BorderSize = 0;
			this.buttonFechar.Size = new System.Drawing.Size(30, 30);
			this.buttonFechar.Location = new System.Drawing.Point(275, 5);
			this.buttonFechar.Click += (s, e) => this.Close();

			// Botões de ação (exemplo com botão 1)
			System.Drawing.Font fonte = new System.Drawing.Font("Segoe UI", 9F);
			System.Drawing.Color corBotao = System.Drawing.Color.WhiteSmoke;

			this.button1AcaoAberturaDeMassiva.Font = fonte;
			this.button1AcaoAberturaDeMassiva.BackColor = corBotao;
			this.button1AcaoAberturaDeMassiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1AcaoAberturaDeMassiva.Location = new System.Drawing.Point(3, 50);
			this.button1AcaoAberturaDeMassiva.Size = new System.Drawing.Size(97, 71);
			this.button1AcaoAberturaDeMassiva.Text = "Massiva";
			this.button1AcaoAberturaDeMassiva.Click += new System.EventHandler(this.Button1AcaoAberturaDeMassivaClick);

			this.buttonComunicacaoComCliente.Font = fonte;
			this.buttonComunicacaoComCliente.BackColor = corBotao;
			this.buttonComunicacaoComCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonComunicacaoComCliente.Location = new System.Drawing.Point(106, 50);
			this.buttonComunicacaoComCliente.Size = new System.Drawing.Size(97, 71);
			this.buttonComunicacaoComCliente.Text = "Comunicar Cliente";
			this.buttonComunicacaoComCliente.Click += new System.EventHandler(this.ButtonComunicacaoComClienteClick);

			this.button3AberturaDeReparo.Font = fonte;
			this.button3AberturaDeReparo.BackColor = corBotao;
			this.button3AberturaDeReparo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3AberturaDeReparo.Location = new System.Drawing.Point(209, 50);
			this.button3AberturaDeReparo.Size = new System.Drawing.Size(97, 71);
			this.button3AberturaDeReparo.Text = "Abertura de Reparo - (E-mail)";

			this.button4.Font = fonte;
			this.button4.BackColor = corBotao;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Location = new System.Drawing.Point(3, 127);
			this.button4.Size = new System.Drawing.Size(97, 71);
			this.button4.Text = "Ação";

			this.button5.Font = fonte;
			this.button5.BackColor = corBotao;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button5.Location = new System.Drawing.Point(106, 127);
			this.button5.Size = new System.Drawing.Size(97, 71);
			this.button5.Text = "Ação";

			this.button6.Font = fonte;
			this.button6.BackColor = corBotao;
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button6.Location = new System.Drawing.Point(209, 127);
			this.button6.Size = new System.Drawing.Size(97, 71);
			this.button6.Text = "Ação";

			// Form
			this.ClientSize = new System.Drawing.Size(309, 210);
			this.Controls.Add(this.panelTop);
			this.Controls.Add(this.button1AcaoAberturaDeMassiva);
			this.Controls.Add(this.buttonComunicacaoComCliente);
			this.Controls.Add(this.button3AberturaDeReparo);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button6);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MenuDeAcesso";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.BackColor = System.Drawing.Color.WhiteSmoke;

			this.ResumeLayout(false);
		}

	}
}
