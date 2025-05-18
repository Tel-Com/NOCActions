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
		private System.Windows.Forms.Button btnEmailAberturaDeReparoParaCliente;
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
			this.button1AcaoAberturaDeMassiva = new System.Windows.Forms.Button();
			this.button3AberturaDeReparo = new System.Windows.Forms.Button();
			this.btnEmailAberturaDeReparoParaCliente = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.buttonComunicacaoComCliente = new System.Windows.Forms.Button();
			this.buttonFechar = new System.Windows.Forms.Button();
			this.labelTitulo = new System.Windows.Forms.Label();
			this.panelTop = new System.Windows.Forms.Panel();
			this.panelTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1AcaoAberturaDeMassiva
			// 
			this.button1AcaoAberturaDeMassiva.BackColor = System.Drawing.Color.WhiteSmoke;
			this.button1AcaoAberturaDeMassiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1AcaoAberturaDeMassiva.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1AcaoAberturaDeMassiva.Location = new System.Drawing.Point(3, 50);
			this.button1AcaoAberturaDeMassiva.Name = "button1AcaoAberturaDeMassiva";
			this.button1AcaoAberturaDeMassiva.Size = new System.Drawing.Size(97, 71);
			this.button1AcaoAberturaDeMassiva.TabIndex = 1;
			this.button1AcaoAberturaDeMassiva.Text = "Ação";
			this.button1AcaoAberturaDeMassiva.UseVisualStyleBackColor = false;
			this.button1AcaoAberturaDeMassiva.Click += new System.EventHandler(this.Button1AcaoAberturaDeMassivaClick);
			// 
			// button3AberturaDeReparo
			// 
			this.button3AberturaDeReparo.BackColor = System.Drawing.Color.WhiteSmoke;
			this.button3AberturaDeReparo.Enabled = false;
			this.button3AberturaDeReparo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3AberturaDeReparo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3AberturaDeReparo.Location = new System.Drawing.Point(208, 127);
			this.button3AberturaDeReparo.Name = "button3AberturaDeReparo";
			this.button3AberturaDeReparo.Size = new System.Drawing.Size(97, 71);
			this.button3AberturaDeReparo.TabIndex = 3;
			this.button3AberturaDeReparo.Text = "Ação";
			this.button3AberturaDeReparo.UseVisualStyleBackColor = false;
			// 
			// btnEmailAberturaDeReparoParaCliente
			// 
			this.btnEmailAberturaDeReparoParaCliente.BackColor = System.Drawing.Color.WhiteSmoke;
			this.btnEmailAberturaDeReparoParaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEmailAberturaDeReparoParaCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEmailAberturaDeReparoParaCliente.Location = new System.Drawing.Point(106, 50);
			this.btnEmailAberturaDeReparoParaCliente.Name = "btnEmailAberturaDeReparoParaCliente";
			this.btnEmailAberturaDeReparoParaCliente.Size = new System.Drawing.Size(97, 71);
			this.btnEmailAberturaDeReparoParaCliente.TabIndex = 4;
			this.btnEmailAberturaDeReparoParaCliente.Text = "Abertura de reparo";
			this.btnEmailAberturaDeReparoParaCliente.UseVisualStyleBackColor = false;
			this.btnEmailAberturaDeReparoParaCliente.Click += new System.EventHandler(this.BtnEmailAberturaDeReparoParaClienteClick);
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.WhiteSmoke;
			this.button5.Enabled = false;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button5.Location = new System.Drawing.Point(3, 127);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(97, 71);
			this.button5.TabIndex = 5;
			this.button5.Text = "Ação";
			this.button5.UseVisualStyleBackColor = false;
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.Color.WhiteSmoke;
			this.button6.Enabled = false;
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button6.Location = new System.Drawing.Point(106, 127);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(97, 71);
			this.button6.TabIndex = 6;
			this.button6.Text = "Ação";
			this.button6.UseVisualStyleBackColor = false;
			// 
			// buttonComunicacaoComCliente
			// 
			this.buttonComunicacaoComCliente.BackColor = System.Drawing.Color.WhiteSmoke;
			this.buttonComunicacaoComCliente.Enabled = false;
			this.buttonComunicacaoComCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonComunicacaoComCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonComunicacaoComCliente.Location = new System.Drawing.Point(208, 50);
			this.buttonComunicacaoComCliente.Name = "buttonComunicacaoComCliente";
			this.buttonComunicacaoComCliente.Size = new System.Drawing.Size(97, 71);
			this.buttonComunicacaoComCliente.TabIndex = 2;
			this.buttonComunicacaoComCliente.Text = "Ação";
			this.buttonComunicacaoComCliente.UseVisualStyleBackColor = false;
			this.buttonComunicacaoComCliente.Click += new System.EventHandler(this.ButtonComunicacaoComClienteClick);
			// 
			// buttonFechar
			// 
			this.buttonFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(62)))), ((int)(((byte)(93)))));
			this.buttonFechar.FlatAppearance.BorderSize = 0;
			this.buttonFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFechar.ForeColor = System.Drawing.Color.White;
			this.buttonFechar.Location = new System.Drawing.Point(275, 5);
			this.buttonFechar.Name = "buttonFechar";
			this.buttonFechar.Size = new System.Drawing.Size(30, 30);
			this.buttonFechar.TabIndex = 1;
			this.buttonFechar.Text = "X";
			this.buttonFechar.UseVisualStyleBackColor = false;
			// 
			// labelTitulo
			// 
			this.labelTitulo.AutoSize = true;
			this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.labelTitulo.ForeColor = System.Drawing.Color.White;
			this.labelTitulo.Location = new System.Drawing.Point(10, 10);
			this.labelTitulo.Name = "labelTitulo";
			this.labelTitulo.Size = new System.Drawing.Size(184, 20);
			this.labelTitulo.TabIndex = 0;
			this.labelTitulo.Text = "Menu - Ações Específicas";
			// 
			// panelTop
			// 
			this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(62)))), ((int)(((byte)(93)))));
			this.panelTop.Controls.Add(this.labelTitulo);
			this.panelTop.Controls.Add(this.buttonFechar);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(308, 40);
			this.panelTop.TabIndex = 0;
			// 
			// MenuDeAcesso
			// 
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(308, 202);
			this.Controls.Add(this.panelTop);
			this.Controls.Add(this.button1AcaoAberturaDeMassiva);
			this.Controls.Add(this.buttonComunicacaoComCliente);
			this.Controls.Add(this.button3AberturaDeReparo);
			this.Controls.Add(this.btnEmailAberturaDeReparoParaCliente);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button6);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MenuDeAcesso";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.ResumeLayout(false);

		}

	}
}
