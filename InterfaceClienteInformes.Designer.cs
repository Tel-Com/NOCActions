namespace NOC_Actions
{
	partial class InterfaceClienteInformes
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnAlarmeLinkIndisponivel;
		private System.Windows.Forms.Button btnChamadoRegistrado;
		private System.Windows.Forms.Button btnLibAcessoSemPrevisao;
		private System.Windows.Forms.Button btnLibAcessoComPrevisao;
		private System.Windows.Forms.Button btnAnaliseEnergia;
		private System.Windows.Forms.Button btnAlarmeComChamado;

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel painelInterface;
		private System.Windows.Forms.Button button1;

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
			this.btnAlarmeLinkIndisponivel = new System.Windows.Forms.Button();
			this.btnChamadoRegistrado = new System.Windows.Forms.Button();
			this.btnLibAcessoSemPrevisao = new System.Windows.Forms.Button();
			this.btnLibAcessoComPrevisao = new System.Windows.Forms.Button();
			this.btnAnaliseEnergia = new System.Windows.Forms.Button();
			this.btnAlarmeComChamado = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.button1 = new System.Windows.Forms.Button();
			this.painelInterface = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAlarmeLinkIndisponivel
			// 
			this.btnAlarmeLinkIndisponivel.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAlarmeLinkIndisponivel.Location = new System.Drawing.Point(0, 0);
			this.btnAlarmeLinkIndisponivel.Name = "btnAlarmeLinkIndisponivel";
			this.btnAlarmeLinkIndisponivel.Size = new System.Drawing.Size(230, 23);
			this.btnAlarmeLinkIndisponivel.TabIndex = 6;
			this.btnAlarmeLinkIndisponivel.Text = "Alarme de Link Indisponível";
			this.btnAlarmeLinkIndisponivel.Click += new System.EventHandler(this.BtnAlarmeLinkIndisponivel_Click);
			// 
			// btnChamadoRegistrado
			// 
			this.btnChamadoRegistrado.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnChamadoRegistrado.Location = new System.Drawing.Point(0, 23);
			this.btnChamadoRegistrado.Name = "btnChamadoRegistrado";
			this.btnChamadoRegistrado.Size = new System.Drawing.Size(230, 23);
			this.btnChamadoRegistrado.TabIndex = 5;
			this.btnChamadoRegistrado.Text = "Chamado Registrado";
			this.btnChamadoRegistrado.Click += new System.EventHandler(this.BtnChamadoRegistrado_Click);
			// 
			// btnLibAcessoSemPrevisao
			// 
			this.btnLibAcessoSemPrevisao.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnLibAcessoSemPrevisao.Location = new System.Drawing.Point(0, 46);
			this.btnLibAcessoSemPrevisao.Name = "btnLibAcessoSemPrevisao";
			this.btnLibAcessoSemPrevisao.Size = new System.Drawing.Size(230, 23);
			this.btnLibAcessoSemPrevisao.TabIndex = 4;
			this.btnLibAcessoSemPrevisao.Text = "Liberação de Acesso (Sem Previsão)";
			this.btnLibAcessoSemPrevisao.Click += new System.EventHandler(this.BtnLibAcessoSemPrevisao_Click);
			// 
			// btnLibAcessoComPrevisao
			// 
			this.btnLibAcessoComPrevisao.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnLibAcessoComPrevisao.Location = new System.Drawing.Point(0, 69);
			this.btnLibAcessoComPrevisao.Name = "btnLibAcessoComPrevisao";
			this.btnLibAcessoComPrevisao.Size = new System.Drawing.Size(230, 23);
			this.btnLibAcessoComPrevisao.TabIndex = 3;
			this.btnLibAcessoComPrevisao.Text = "Liberação de Acesso (Com Previsão)";
			this.btnLibAcessoComPrevisao.Click += new System.EventHandler(this.BtnLibAcessoComPrevisao_Click);
			// 
			// btnAnaliseEnergia
			// 
			this.btnAnaliseEnergia.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAnaliseEnergia.Location = new System.Drawing.Point(0, 92);
			this.btnAnaliseEnergia.Name = "btnAnaliseEnergia";
			this.btnAnaliseEnergia.Size = new System.Drawing.Size(230, 23);
			this.btnAnaliseEnergia.TabIndex = 2;
			this.btnAnaliseEnergia.Text = "Análise de Energia";
			this.btnAnaliseEnergia.Click += new System.EventHandler(this.BtnAnaliseEnergia_Click);
			// 
			// btnAlarmeComChamado
			// 
			this.btnAlarmeComChamado.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAlarmeComChamado.Location = new System.Drawing.Point(0, 115);
			this.btnAlarmeComChamado.Name = "btnAlarmeComChamado";
			this.btnAlarmeComChamado.Size = new System.Drawing.Size(230, 23);
			this.btnAlarmeComChamado.TabIndex = 1;
			this.btnAlarmeComChamado.Text = "Alarme + Chamado Registrado";
			this.btnAlarmeComChamado.Click += new System.EventHandler(this.BtnAlarmeComChamadoClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Gainsboro;
			this.splitContainer1.Panel1.Controls.Add(this.button1);
			this.splitContainer1.Panel1.Controls.Add(this.btnAlarmeComChamado);
			this.splitContainer1.Panel1.Controls.Add(this.btnAnaliseEnergia);
			this.splitContainer1.Panel1.Controls.Add(this.btnLibAcessoComPrevisao);
			this.splitContainer1.Panel1.Controls.Add(this.btnLibAcessoSemPrevisao);
			this.splitContainer1.Panel1.Controls.Add(this.btnChamadoRegistrado);
			this.splitContainer1.Panel1.Controls.Add(this.btnAlarmeLinkIndisponivel);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer1.Panel2.Controls.Add(this.painelInterface);
			this.splitContainer1.Size = new System.Drawing.Size(704, 380);
			this.splitContainer1.SplitterDistance = 230;
			this.splitContainer1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Top;
			this.button1.Location = new System.Drawing.Point(0, 138);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(230, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Pendência Financeira";
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// painelInterface
			// 
			this.painelInterface.Dock = System.Windows.Forms.DockStyle.Fill;
			this.painelInterface.Location = new System.Drawing.Point(0, 0);
			this.painelInterface.Name = "painelInterface";
			this.painelInterface.Size = new System.Drawing.Size(470, 380);
			this.painelInterface.TabIndex = 0;
			// 
			// InterfaceClienteInformes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(704, 380);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "InterfaceClienteInformes";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "InterfaceClienteInformes";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}