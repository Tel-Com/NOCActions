/*
 * Criado por SharpDevelop.
 * Usuário: fjstavares
 * Data: 31/10/2025
 * Hora: 23:50
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
namespace NOC_Actions
{
	partial class LoginUser
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1_userLogin;
		private System.Windows.Forms.TextBox textBox2_userPassword;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnSair;
		private System.Windows.Forms.Label label3;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1_userLogin = new System.Windows.Forms.TextBox();
			this.textBox2_userPassword = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnSair = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(35, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Login";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(35, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "Senha";
			// 
			// textBox1_userLogin
			// 
			this.textBox1_userLogin.Location = new System.Drawing.Point(95, 41);
			this.textBox1_userLogin.Name = "textBox1_userLogin";
			this.textBox1_userLogin.Size = new System.Drawing.Size(246, 25);
			this.textBox1_userLogin.TabIndex = 2;
			// 
			// textBox2_userPassword
			// 
			this.textBox2_userPassword.Location = new System.Drawing.Point(95, 73);
			this.textBox2_userPassword.Name = "textBox2_userPassword";
			this.textBox2_userPassword.Size = new System.Drawing.Size(246, 25);
			this.textBox2_userPassword.TabIndex = 3;
			this.textBox2_userPassword.UseSystemPasswordChar = true;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(390, 30);
			this.panel1.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(3, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 25);
			this.label3.TabIndex = 7;
			this.label3.Text = "Login";
			// 
			// btnLogin
			// 
			this.btnLogin.ForeColor = System.Drawing.Color.Black;
			this.btnLogin.Location = new System.Drawing.Point(293, 113);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(79, 26);
			this.btnLogin.TabIndex = 5;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.BtnLoginClick);
			// 
			// btnSair
			// 
			this.btnSair.ForeColor = System.Drawing.Color.Black;
			this.btnSair.Location = new System.Drawing.Point(212, 113);
			this.btnSair.Name = "btnSair";
			this.btnSair.Size = new System.Drawing.Size(79, 26);
			this.btnSair.TabIndex = 6;
			this.btnSair.Text = "Sair";
			this.btnSair.UseVisualStyleBackColor = true;
			this.btnSair.Click += new System.EventHandler(this.BtnSairClick);
			// 
			// LoginUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(390, 148);
			this.Controls.Add(this.btnSair);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.textBox2_userPassword);
			this.Controls.Add(this.textBox1_userLogin);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "LoginUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
			this.PerformLayout();
		}

	}
}
