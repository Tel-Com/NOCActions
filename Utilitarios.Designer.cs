/*
 * Criado por SharpDevelop.
 * Usuário: fjstavares
 * Data: 29/09/2025
 * Hora: 10:02
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
namespace NOC_Actions
{
	partial class Utilitarios
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.RichTextBox richTextBox_TextoUtilitario;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClearField;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label richTextBox_information;
		private System.Windows.Forms.Label labelUserInformation;
		
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
			this.richTextBox_TextoUtilitario = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClearField = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.richTextBox_information = new System.Windows.Forms.Label();
			this.labelUserInformation = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// richTextBox_TextoUtilitario
			// 
			this.richTextBox_TextoUtilitario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox_TextoUtilitario.Location = new System.Drawing.Point(12, 78);
			this.richTextBox_TextoUtilitario.Name = "richTextBox_TextoUtilitario";
			this.richTextBox_TextoUtilitario.Size = new System.Drawing.Size(488, 183);
			this.richTextBox_TextoUtilitario.TabIndex = 3;
			this.richTextBox_TextoUtilitario.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Gray;
			this.panel1.Controls.Add(this.btnExit);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnClearField);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Enabled = false;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(512, 60);
			this.panel1.TabIndex = 2;
			// 
			// btnExit
			// 
			this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnExit.Location = new System.Drawing.Point(307, 25);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(88, 30);
			this.btnExit.TabIndex = 2;
			this.btnExit.Text = "Sair";
			this.btnExit.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnSave.Location = new System.Drawing.Point(213, 25);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(88, 30);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Salvar";
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// btnClearField
			// 
			this.btnClearField.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnClearField.Location = new System.Drawing.Point(119, 25);
			this.btnClearField.Name = "btnClearField";
			this.btnClearField.Size = new System.Drawing.Size(88, 30);
			this.btnClearField.TabIndex = 1;
			this.btnClearField.Text = "Apagar";
			this.btnClearField.UseVisualStyleBackColor = true;
			this.btnClearField.Click += new System.EventHandler(this.BtnClearFieldClick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel2.Controls.Add(this.button5);
			this.panel2.Controls.Add(this.button6);
			this.panel2.Controls.Add(this.button7);
			this.panel2.Controls.Add(this.button8);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Enabled = false;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(512, 23);
			this.panel2.TabIndex = 7;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(335, 23);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(85, 28);
			this.button5.TabIndex = 6;
			this.button5.Text = "button5";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(244, 23);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(85, 28);
			this.button6.TabIndex = 5;
			this.button6.Text = "button6";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(153, 23);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(85, 28);
			this.button7.TabIndex = 4;
			this.button7.Text = "button7";
			this.button7.UseVisualStyleBackColor = true;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(62, 23);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(85, 28);
			this.button8.TabIndex = 3;
			this.button8.Text = "button8";
			this.button8.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Silver;
			this.label2.Location = new System.Drawing.Point(0, 275);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(517, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "_________________________________________________________________________________" +
	"____";
			// 
			// richTextBox_information
			// 
			this.richTextBox_information.AutoSize = true;
			this.richTextBox_information.ForeColor = System.Drawing.Color.Black;
			this.richTextBox_information.Location = new System.Drawing.Point(9, 268);
			this.richTextBox_information.Name = "richTextBox_information";
			this.richTextBox_information.Size = new System.Drawing.Size(120, 13);
			this.richTextBox_information.TabIndex = 4;
			this.richTextBox_information.Text = "richTextBox_information";
			// 
			// labelUserInformation
			// 
			this.labelUserInformation.AutoSize = true;
			this.labelUserInformation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUserInformation.ForeColor = System.Drawing.Color.Silver;
			this.labelUserInformation.Location = new System.Drawing.Point(207, 299);
			this.labelUserInformation.Name = "labelUserInformation";
			this.labelUserInformation.Size = new System.Drawing.Size(122, 21);
			this.labelUserInformation.TabIndex = 5;
			this.labelUserInformation.Text = "userInformation";
			// 
			// Utilitarios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(512, 329);
			this.Controls.Add(this.labelUserInformation);
			this.Controls.Add(this.richTextBox_information);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.richTextBox_TextoUtilitario);
			this.Controls.Add(this.label1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Utilitarios";
			this.Text = "Utilitarios";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
