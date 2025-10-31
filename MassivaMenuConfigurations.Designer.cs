/*
 * Created by SharpDevelop.
 * User: fjstavares
 * Date: 01/02/2025
 * Time: 02:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NOC_Actions
{
	partial class UserConfig
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxAdicionarOperadora;
		private System.Windows.Forms.Button btnAdicionarOperadora;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxOperadoraJaAdicionadas;
		private System.Windows.Forms.Button btnDeletarOperadora;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonDeletarCidade;
		private System.Windows.Forms.ComboBox comboBoxCidadeAdicionada;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonAdicionarCidade;
		private System.Windows.Forms.TextBox textBoxAdicionarCidade;
		private System.Windows.Forms.Label label5;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxAdicionarOperadora = new System.Windows.Forms.TextBox();
			this.btnAdicionarOperadora = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxOperadoraJaAdicionadas = new System.Windows.Forms.ComboBox();
			this.btnDeletarOperadora = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonDeletarCidade = new System.Windows.Forms.Button();
			this.comboBoxCidadeAdicionada = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonAdicionarCidade = new System.Windows.Forms.Button();
			this.textBoxAdicionarCidade = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label1.Location = new System.Drawing.Point(12, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(132, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Adicionar Operadora";
			// 
			// textBoxAdicionarOperadora
			// 
			this.textBoxAdicionarOperadora.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.textBoxAdicionarOperadora.Location = new System.Drawing.Point(151, 79);
			this.textBoxAdicionarOperadora.Name = "textBoxAdicionarOperadora";
			this.textBoxAdicionarOperadora.Size = new System.Drawing.Size(186, 25);
			this.textBoxAdicionarOperadora.TabIndex = 2;
			// 
			// btnAdicionarOperadora
			// 
			this.btnAdicionarOperadora.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnAdicionarOperadora.Location = new System.Drawing.Point(345, 82);
			this.btnAdicionarOperadora.Name = "btnAdicionarOperadora";
			this.btnAdicionarOperadora.Size = new System.Drawing.Size(77, 23);
			this.btnAdicionarOperadora.TabIndex = 6;
			this.btnAdicionarOperadora.Text = "Adicionar";
			this.btnAdicionarOperadora.UseVisualStyleBackColor = true;
			this.btnAdicionarOperadora.Click += new System.EventHandler(this.BtnAdicionarOperadoraClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label2.Location = new System.Drawing.Point(12, 109);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Opers. adicionadas";
			// 
			// comboBoxOperadoraJaAdicionadas
			// 
			this.comboBoxOperadoraJaAdicionadas.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.comboBoxOperadoraJaAdicionadas.FormattingEnabled = true;
			this.comboBoxOperadoraJaAdicionadas.Location = new System.Drawing.Point(151, 107);
			this.comboBoxOperadoraJaAdicionadas.Name = "comboBoxOperadoraJaAdicionadas";
			this.comboBoxOperadoraJaAdicionadas.Size = new System.Drawing.Size(186, 25);
			this.comboBoxOperadoraJaAdicionadas.TabIndex = 3;
			// 
			// btnDeletarOperadora
			// 
			this.btnDeletarOperadora.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnDeletarOperadora.Location = new System.Drawing.Point(345, 108);
			this.btnDeletarOperadora.Name = "btnDeletarOperadora";
			this.btnDeletarOperadora.Size = new System.Drawing.Size(77, 23);
			this.btnDeletarOperadora.TabIndex = 7;
			this.btnDeletarOperadora.Text = "Deletar";
			this.btnDeletarOperadora.UseVisualStyleBackColor = true;
			this.btnDeletarOperadora.Click += new System.EventHandler(this.BtnDeletarOperadoraClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
			this.label3.Location = new System.Drawing.Point(-2, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(442, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "______________________________________________________________";
			// 
			// buttonDeletarCidade
			// 
			this.buttonDeletarCidade.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.buttonDeletarCidade.Location = new System.Drawing.Point(345, 35);
			this.buttonDeletarCidade.Name = "buttonDeletarCidade";
			this.buttonDeletarCidade.Size = new System.Drawing.Size(77, 23);
			this.buttonDeletarCidade.TabIndex = 5;
			this.buttonDeletarCidade.Text = "Deletar";
			this.buttonDeletarCidade.UseVisualStyleBackColor = true;
			this.buttonDeletarCidade.Click += new System.EventHandler(this.ButtonDeletarCidadeClick);
			// 
			// comboBoxCidadeAdicionada
			// 
			this.comboBoxCidadeAdicionada.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.comboBoxCidadeAdicionada.FormattingEnabled = true;
			this.comboBoxCidadeAdicionada.Location = new System.Drawing.Point(151, 35);
			this.comboBoxCidadeAdicionada.Name = "comboBoxCidadeAdicionada";
			this.comboBoxCidadeAdicionada.Size = new System.Drawing.Size(186, 25);
			this.comboBoxCidadeAdicionada.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label4.Location = new System.Drawing.Point(12, 35);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(129, 17);
			this.label4.TabIndex = 10;
			this.label4.Text = "Cidades adicionadas";
			// 
			// buttonAdicionarCidade
			// 
			this.buttonAdicionarCidade.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.buttonAdicionarCidade.Location = new System.Drawing.Point(345, 9);
			this.buttonAdicionarCidade.Name = "buttonAdicionarCidade";
			this.buttonAdicionarCidade.Size = new System.Drawing.Size(77, 23);
			this.buttonAdicionarCidade.TabIndex = 4;
			this.buttonAdicionarCidade.Text = "Adicionar";
			this.buttonAdicionarCidade.UseVisualStyleBackColor = true;
			this.buttonAdicionarCidade.Click += new System.EventHandler(this.ButtonAdicionarCidadeClick);
			// 
			// textBoxAdicionarCidade
			// 
			this.textBoxAdicionarCidade.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.textBoxAdicionarCidade.Location = new System.Drawing.Point(151, 7);
			this.textBoxAdicionarCidade.Name = "textBoxAdicionarCidade";
			this.textBoxAdicionarCidade.Size = new System.Drawing.Size(186, 25);
			this.textBoxAdicionarCidade.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label5.Location = new System.Drawing.Point(12, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(108, 17);
			this.label5.TabIndex = 7;
			this.label5.Text = "Adicionar Cidade";
			// 
			// UserConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 148);
			this.Controls.Add(this.buttonDeletarCidade);
			this.Controls.Add(this.comboBoxCidadeAdicionada);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.buttonAdicionarCidade);
			this.Controls.Add(this.textBoxAdicionarCidade);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnDeletarOperadora);
			this.Controls.Add(this.comboBoxOperadoraJaAdicionadas);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnAdicionarOperadora);
			this.Controls.Add(this.textBoxAdicionarOperadora);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "UserConfig";
			this.Text = "Configurações";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
