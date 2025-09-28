/*
 * Created by SharpDevelop.
 * User: fjstavares
 * Date: 18/07/2025
 * Time: 10:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NOC_Actions
{
	partial class UcAberturaDeReparo
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnGravarECopiar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2_horarioDoRegistroChamado;
		private System.Windows.Forms.TextBox textBox1_ChamadoOperadora;
		private System.Windows.Forms.Button btnApagarCampos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnFecharJanela;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.label5 = new System.Windows.Forms.Label();
			this.btnGravarECopiar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2_horarioDoRegistroChamado = new System.Windows.Forms.TextBox();
			this.textBox1_ChamadoOperadora = new System.Windows.Forms.TextBox();
			this.btnApagarCampos = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnFecharJanela = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(44, 203);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(391, 13);
			this.label5.TabIndex = 17;
			this.label5.Text = "________________________________________________________________";
			// 
			// btnGravarECopiar
			// 
			this.btnGravarECopiar.Location = new System.Drawing.Point(339, 316);
			this.btnGravarECopiar.Name = "btnGravarECopiar";
			this.btnGravarECopiar.Size = new System.Drawing.Size(114, 33);
			this.btnGravarECopiar.TabIndex = 16;
			this.btnGravarECopiar.Text = "Gravar e Copiar";
			this.btnGravarECopiar.UseVisualStyleBackColor = true;
			this.btnGravarECopiar.Click += new System.EventHandler(this.BtnGravarECopiarClick);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Mensagem a ser exibida";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(72, 161);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 14;
			this.label3.Text = "Horário do Registro";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(72, 126);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 13;
			this.label2.Text = "Chamado";
			// 
			// textBox2_horarioDoRegistroChamado
			// 
			this.textBox2_horarioDoRegistroChamado.Location = new System.Drawing.Point(178, 158);
			this.textBox2_horarioDoRegistroChamado.Name = "textBox2_horarioDoRegistroChamado";
			this.textBox2_horarioDoRegistroChamado.Size = new System.Drawing.Size(196, 20);
			this.textBox2_horarioDoRegistroChamado.TabIndex = 12;
			// 
			// textBox1_ChamadoOperadora
			// 
			this.textBox1_ChamadoOperadora.Location = new System.Drawing.Point(178, 126);
			this.textBox1_ChamadoOperadora.Name = "textBox1_ChamadoOperadora";
			this.textBox1_ChamadoOperadora.Size = new System.Drawing.Size(196, 20);
			this.textBox1_ChamadoOperadora.TabIndex = 11;
			// 
			// btnApagarCampos
			// 
			this.btnApagarCampos.Location = new System.Drawing.Point(219, 316);
			this.btnApagarCampos.Name = "btnApagarCampos";
			this.btnApagarCampos.Size = new System.Drawing.Size(114, 33);
			this.btnApagarCampos.TabIndex = 10;
			this.btnApagarCampos.Text = "Apagar";
			this.btnApagarCampos.UseVisualStyleBackColor = true;
			this.btnApagarCampos.Click += new System.EventHandler(this.BtnApagarCamposClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(464, 35);
			this.label1.TabIndex = 9;
			this.label1.Text = "\t\tPrezados, chamado ___ registrado as ___ (hh:mm) junto ao fornecedor.";
			// 
			// btnFecharJanela
			// 
			this.btnFecharJanela.Location = new System.Drawing.Point(44, 317);
			this.btnFecharJanela.Name = "btnFecharJanela";
			this.btnFecharJanela.Size = new System.Drawing.Size(114, 33);
			this.btnFecharJanela.TabIndex = 18;
			this.btnFecharJanela.Text = "Fechar";
			this.btnFecharJanela.UseVisualStyleBackColor = true;
			this.btnFecharJanela.Click += new System.EventHandler(this.BtnFecharJanelaClick);
			// 
			// UcAberturaDeReparo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnFecharJanela);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnGravarECopiar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2_horarioDoRegistroChamado);
			this.Controls.Add(this.textBox1_ChamadoOperadora);
			this.Controls.Add(this.btnApagarCampos);
			this.Controls.Add(this.label1);
			this.Name = "UcAberturaDeReparo";
			this.Size = new System.Drawing.Size(470, 380);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
