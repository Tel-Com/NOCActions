/*
 * Created by SharpDevelop.
 * User: fjstavares
 * Date: 06/12/2024
 * Time: 09:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NOCActions
{
	partial class MassivaForm
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonCopiar;
		private System.Windows.Forms.Button btnGerar;
		private System.Windows.Forms.TextBox textBoxOperadora;
		private System.Windows.Forms.ComboBox comboBoxEstados;
		private System.Windows.Forms.RichTextBox textBoxExemplo;
		private System.Windows.Forms.Button btnApagar;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxOperadora = new System.Windows.Forms.TextBox();
			this.comboBoxEstados = new System.Windows.Forms.ComboBox();
			this.textBoxExemplo = new System.Windows.Forms.RichTextBox();
			this.btnApagar = new System.Windows.Forms.Button();
			this.buttonCopiar = new System.Windows.Forms.Button();
			this.btnGerar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 12.25F);
			this.label1.Location = new System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 19);
			this.label1.TabIndex = 10;
			this.label1.Text = "Estado";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 12.25F);
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 19);
			this.label2.TabIndex = 4;
			this.label2.Text = "Operadora";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 12.25F);
			this.label3.Location = new System.Drawing.Point(12, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 19);
			this.label3.TabIndex = 8;
			this.label3.Text = "Exemplo";
			// 
			// textBoxOperadora
			// 
			this.textBoxOperadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxOperadora.Location = new System.Drawing.Point(110, 40);
			this.textBoxOperadora.Name = "textBoxOperadora";
			this.textBoxOperadora.Size = new System.Drawing.Size(171, 21);
			this.textBoxOperadora.TabIndex = 3;
			// 
			// comboBoxEstados
			// 
			this.comboBoxEstados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxEstados.FormattingEnabled = true;
			this.comboBoxEstados.Items.AddRange(new object[] {
			"Acre (AC)",
			"Alagoas (AL)",
			"Amapá (AP)",
			"Amazonas (AM)",
			"Bahia (BA)",
			"Ceará (CE)",
			"Distrito Federal (DF)",
			"Espírito Santo (ES)",
			"Goiás (GO)",
			"Maranhão (MA)",
			"Mato Grosso (MT)",
			"Mato Grosso do Sul (MS)",
			"Minas Gerais (MG)",
			"Pará (PA)",
			"Paraíba (PB)",
			"Paraná (PR)",
			"Pernambuco (PE)",
			"Piauí (PI)",
			"Rio de Janeiro (RJ)",
			"Rio Grande do Norte (RN)",
			"Rio Grande do Sul (RS)",
			"Rondônia (RO)",
			"Roraima (RR)",
			"Santa Catarina (SC)",
			"São Paulo (SP)",
			"Sergipe (SE)",
			"Tocantins (TO)"});
			this.comboBoxEstados.Location = new System.Drawing.Point(110, 11);
			this.comboBoxEstados.Name = "comboBoxEstados";
			this.comboBoxEstados.Size = new System.Drawing.Size(171, 23);
			this.comboBoxEstados.TabIndex = 1;
			// 
			// textBoxExemplo
			// 
			this.textBoxExemplo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.textBoxExemplo.Location = new System.Drawing.Point(110, 86);
			this.textBoxExemplo.Name = "textBoxExemplo";
			this.textBoxExemplo.Size = new System.Drawing.Size(440, 71);
			this.textBoxExemplo.TabIndex = 9;
			this.textBoxExemplo.Text = "";
			// 
			// btnApagar
			// 
			this.btnApagar.Location = new System.Drawing.Point(456, 163);
			this.btnApagar.Name = "btnApagar";
			this.btnApagar.Size = new System.Drawing.Size(94, 56);
			this.btnApagar.TabIndex = 7;
			this.btnApagar.Text = "Apagar";
			this.btnApagar.Click += new System.EventHandler(this.BtnApagarClick);
			// 
			// buttonCopiar
			// 
			this.buttonCopiar.Location = new System.Drawing.Point(353, 163);
			this.buttonCopiar.Name = "buttonCopiar";
			this.buttonCopiar.Size = new System.Drawing.Size(94, 56);
			this.buttonCopiar.TabIndex = 6;
			this.buttonCopiar.Text = "Copiar";
			this.buttonCopiar.Click += new System.EventHandler(this.ButtonCopiarClick);
			// 
			// btnGerar
			// 
			this.btnGerar.Location = new System.Drawing.Point(250, 163);
			this.btnGerar.Name = "btnGerar";
			this.btnGerar.Size = new System.Drawing.Size(94, 56);
			this.btnGerar.TabIndex = 5;
			this.btnGerar.Text = "Gerar";
			this.btnGerar.Click += new System.EventHandler(this.BtnGerarClick);
			// 
			// MassivaForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ClientSize = new System.Drawing.Size(562, 236);
			this.Controls.Add(this.comboBoxEstados);
			this.Controls.Add(this.textBoxOperadora);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnGerar);
			this.Controls.Add(this.buttonCopiar);
			this.Controls.Add(this.btnApagar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxExemplo);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MassivaForm";
			this.Text = "Abertura de Massiva";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}

