/*
 * Created by SharpDevelop.
 * User: fjstavares
 * Date: 18/07/2025
 * Time: 09:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NOC_Actions
{
	partial class UcLiberacaoDeAcessoComPrevisao
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
		private System.Windows.Forms.Button btnApagarCampos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox richTextBox1_DadosTecnicos;
		private System.Windows.Forms.TextBox textBox1_PrevisaoChegada;
		private System.Windows.Forms.Label label6;
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
			this.btnGravarECopiar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.btnApagarCampos = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.richTextBox1_DadosTecnicos = new System.Windows.Forms.RichTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1_PrevisaoChegada = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnFecharJanela = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnGravarECopiar
			// 
			this.btnGravarECopiar.Location = new System.Drawing.Point(339, 315);
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
			// btnApagarCampos
			// 
			this.btnApagarCampos.Location = new System.Drawing.Point(219, 315);
			this.btnApagarCampos.Name = "btnApagarCampos";
			this.btnApagarCampos.Size = new System.Drawing.Size(114, 33);
			this.btnApagarCampos.TabIndex = 10;
			this.btnApagarCampos.Text = "Apagar";
			this.btnApagarCampos.UseVisualStyleBackColor = true;
			this.btnApagarCampos.Click += new System.EventHandler(this.BtnApagarCamposClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(464, 35);
			this.label1.TabIndex = 9;
			this.label1.Text = "Prezados, necessário acionamento com a loja para liberação de acesso do(s) técnic" +
	"o(s) abaixo. Previsão de chegada as __ (hh) OU no período da manhã/tarde/noite.";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(39, 251);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(391, 35);
			this.label3.TabIndex = 23;
			this.label3.Text = "No campo acima, adicione as informações pessoais da equipe técnica (NOME, RG, CPF" +
	" e outros documentos).";
			// 
			// richTextBox1_DadosTecnicos
			// 
			this.richTextBox1_DadosTecnicos.Location = new System.Drawing.Point(57, 94);
			this.richTextBox1_DadosTecnicos.Name = "richTextBox1_DadosTecnicos";
			this.richTextBox1_DadosTecnicos.Size = new System.Drawing.Size(359, 96);
			this.richTextBox1_DadosTecnicos.TabIndex = 22;
			this.richTextBox1_DadosTecnicos.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(39, 237);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(391, 13);
			this.label5.TabIndex = 21;
			this.label5.Text = "________________________________________________________________";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(39, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(134, 23);
			this.label2.TabIndex = 20;
			this.label2.Text = "Equipe Técnica (Dados)";
			// 
			// textBox1_PrevisaoChegada
			// 
			this.textBox1_PrevisaoChegada.Location = new System.Drawing.Point(172, 211);
			this.textBox1_PrevisaoChegada.Name = "textBox1_PrevisaoChegada";
			this.textBox1_PrevisaoChegada.Size = new System.Drawing.Size(237, 20);
			this.textBox1_PrevisaoChegada.TabIndex = 24;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(57, 214);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(109, 13);
			this.label6.TabIndex = 25;
			this.label6.Text = "Previsão de Chagada";
			// 
			// btnFecharJanela
			// 
			this.btnFecharJanela.Location = new System.Drawing.Point(44, 317);
			this.btnFecharJanela.Name = "btnFecharJanela";
			this.btnFecharJanela.Size = new System.Drawing.Size(114, 33);
			this.btnFecharJanela.TabIndex = 26;
			this.btnFecharJanela.Text = "Fechar";
			this.btnFecharJanela.UseVisualStyleBackColor = true;
			this.btnFecharJanela.Click += new System.EventHandler(this.BtnFecharJanelaClick);
			// 
			// UcLiberacaoDeAcessoComPrevisao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.btnFecharJanela);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox1_PrevisaoChegada);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.richTextBox1_DadosTecnicos);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnGravarECopiar);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnApagarCampos);
			this.Controls.Add(this.label1);
			this.Name = "UcLiberacaoDeAcessoComPrevisao";
			this.Size = new System.Drawing.Size(470, 380);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
