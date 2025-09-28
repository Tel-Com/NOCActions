/*
 * Created by SharpDevelop.
 * User: fjstavares
 * Date: 21/07/2025
 * Time: 10:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NOC_Actions
{
	partial class UcPendenciaFinanceiraInformes
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox1_UnidadeComBloqueioFinanceiro;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnGravarECopiar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnApagarCampos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
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
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1_UnidadeComBloqueioFinanceiro = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnGravarECopiar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.btnApagarCampos = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnFecharJanela = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(50, 129);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 13);
			this.label6.TabIndex = 35;
			this.label6.Text = "Unidade";
			// 
			// textBox1_UnidadeComBloqueioFinanceiro
			// 
			this.textBox1_UnidadeComBloqueioFinanceiro.Location = new System.Drawing.Point(165, 126);
			this.textBox1_UnidadeComBloqueioFinanceiro.Name = "textBox1_UnidadeComBloqueioFinanceiro";
			this.textBox1_UnidadeComBloqueioFinanceiro.Size = new System.Drawing.Size(237, 20);
			this.textBox1_UnidadeComBloqueioFinanceiro.TabIndex = 34;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(34, 164);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(391, 13);
			this.label5.TabIndex = 31;
			this.label5.Text = "________________________________________________________________";
			// 
			// btnGravarECopiar
			// 
			this.btnGravarECopiar.Location = new System.Drawing.Point(339, 315);
			this.btnGravarECopiar.Name = "btnGravarECopiar";
			this.btnGravarECopiar.Size = new System.Drawing.Size(114, 33);
			this.btnGravarECopiar.TabIndex = 29;
			this.btnGravarECopiar.Text = "Gravar e Copiar";
			this.btnGravarECopiar.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 13);
			this.label4.TabIndex = 28;
			this.label4.Text = "Mensagem a ser exibida";
			// 
			// btnApagarCampos
			// 
			this.btnApagarCampos.Location = new System.Drawing.Point(219, 315);
			this.btnApagarCampos.Name = "btnApagarCampos";
			this.btnApagarCampos.Size = new System.Drawing.Size(114, 33);
			this.btnApagarCampos.TabIndex = 27;
			this.btnApagarCampos.Text = "Apagar";
			this.btnApagarCampos.UseVisualStyleBackColor = true;
			this.btnApagarCampos.Click += new System.EventHandler(this.BtnApagarCamposClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(464, 35);
			this.label1.TabIndex = 26;
			this.label1.Text = "\t\t\tPrezados, constatamos a existência de um bloqueio administrativo-financeiro no" +
	" contrato da unidade...";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(34, 186);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(391, 42);
			this.label2.TabIndex = 38;
			this.label2.Text = "Você pode escolher \"detalhar fatura\" para aprimorar e adicionar informações refer" +
	"ente ao Bloqueio Financeiro no respectivo contrato.";
			// 
			// btnFecharJanela
			// 
			this.btnFecharJanela.Location = new System.Drawing.Point(44, 317);
			this.btnFecharJanela.Name = "btnFecharJanela";
			this.btnFecharJanela.Size = new System.Drawing.Size(114, 33);
			this.btnFecharJanela.TabIndex = 39;
			this.btnFecharJanela.Text = "Fechar";
			this.btnFecharJanela.UseVisualStyleBackColor = true;
			this.btnFecharJanela.Click += new System.EventHandler(this.BtnFecharJanelaClick);
			// 
			// UcPendenciaFinanceiraInformes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnFecharJanela);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox1_UnidadeComBloqueioFinanceiro);
			this.Controls.Add(this.btnGravarECopiar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnApagarCampos);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label5);
			this.Name = "UcPendenciaFinanceiraInformes";
			this.Size = new System.Drawing.Size(470, 380);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
