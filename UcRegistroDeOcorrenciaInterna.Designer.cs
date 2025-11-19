/*
 * Criado por SharpDevelop.
 * Usuário: fjstavares
 * Data: 16/11/2025
 * Hora: 16:09
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
namespace NOC_Actions
{
	partial class UcRegistroDeOcorrenciaInterna
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ListBox listBox_RegistroDeOcorrencia;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnPreviewMessage;
		private System.Windows.Forms.Button btnCloseWindow;
		private System.Windows.Forms.Button btnSalvarContratoEOperadora;
		private System.Windows.Forms.Button btnClearFields;
		private System.Windows.Forms.TextBox textBox_UnidadeContrato;
		private System.Windows.Forms.TextBox textBox_OperadoraDaUnidade;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label_textoDeAvisoUnidadeContrato;
		private System.Windows.Forms.Label label_textoDeAvisoOperadora;
		
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
			this.listBox_RegistroDeOcorrencia = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnPreviewMessage = new System.Windows.Forms.Button();
			this.btnCloseWindow = new System.Windows.Forms.Button();
			this.btnSalvarContratoEOperadora = new System.Windows.Forms.Button();
			this.btnClearFields = new System.Windows.Forms.Button();
			this.textBox_UnidadeContrato = new System.Windows.Forms.TextBox();
			this.textBox_OperadoraDaUnidade = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label_textoDeAvisoUnidadeContrato = new System.Windows.Forms.Label();
			this.label_textoDeAvisoOperadora = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox_RegistroDeOcorrencia
			// 
			this.listBox_RegistroDeOcorrencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox_RegistroDeOcorrencia.FormattingEnabled = true;
			this.listBox_RegistroDeOcorrencia.ItemHeight = 17;
			this.listBox_RegistroDeOcorrencia.Location = new System.Drawing.Point(0, 106);
			this.listBox_RegistroDeOcorrencia.Name = "listBox_RegistroDeOcorrencia";
			this.listBox_RegistroDeOcorrencia.Size = new System.Drawing.Size(470, 157);
			this.listBox_RegistroDeOcorrencia.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(3, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Reincidência de Falha";
			// 
			// btnPreviewMessage
			// 
			this.btnPreviewMessage.BackColor = System.Drawing.Color.Transparent;
			this.btnPreviewMessage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnPreviewMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnPreviewMessage.ForeColor = System.Drawing.Color.Black;
			this.btnPreviewMessage.Location = new System.Drawing.Point(153, 315);
			this.btnPreviewMessage.Name = "btnPreviewMessage";
			this.btnPreviewMessage.Size = new System.Drawing.Size(96, 44);
			this.btnPreviewMessage.TabIndex = 8;
			this.btnPreviewMessage.Text = "Deletar Tudo";
			this.btnPreviewMessage.UseVisualStyleBackColor = false;
			// 
			// btnCloseWindow
			// 
			this.btnCloseWindow.BackColor = System.Drawing.Color.Transparent;
			this.btnCloseWindow.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCloseWindow.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnCloseWindow.ForeColor = System.Drawing.Color.Black;
			this.btnCloseWindow.Location = new System.Drawing.Point(34, 315);
			this.btnCloseWindow.Name = "btnCloseWindow";
			this.btnCloseWindow.Size = new System.Drawing.Size(96, 44);
			this.btnCloseWindow.TabIndex = 9;
			this.btnCloseWindow.Text = "Fechar";
			this.btnCloseWindow.UseVisualStyleBackColor = false;
			// 
			// btnSalvarContratoEOperadora
			// 
			this.btnSalvarContratoEOperadora.BackColor = System.Drawing.Color.Transparent;
			this.btnSalvarContratoEOperadora.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSalvarContratoEOperadora.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnSalvarContratoEOperadora.ForeColor = System.Drawing.Color.Black;
			this.btnSalvarContratoEOperadora.Location = new System.Drawing.Point(357, 315);
			this.btnSalvarContratoEOperadora.Name = "btnSalvarContratoEOperadora";
			this.btnSalvarContratoEOperadora.Size = new System.Drawing.Size(96, 44);
			this.btnSalvarContratoEOperadora.TabIndex = 6;
			this.btnSalvarContratoEOperadora.Text = "Gravar e Copiar";
			this.btnSalvarContratoEOperadora.UseVisualStyleBackColor = false;
			this.btnSalvarContratoEOperadora.Click += new System.EventHandler(this.BtnSaveAndCopyClick);
			// 
			// btnClearFields
			// 
			this.btnClearFields.BackColor = System.Drawing.Color.Transparent;
			this.btnClearFields.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnClearFields.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnClearFields.ForeColor = System.Drawing.Color.Black;
			this.btnClearFields.Location = new System.Drawing.Point(255, 315);
			this.btnClearFields.Name = "btnClearFields";
			this.btnClearFields.Size = new System.Drawing.Size(96, 44);
			this.btnClearFields.TabIndex = 7;
			this.btnClearFields.Text = "Deletar";
			this.btnClearFields.UseVisualStyleBackColor = false;
			// 
			// textBox_UnidadeContrato
			// 
			this.textBox_UnidadeContrato.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.textBox_UnidadeContrato.Location = new System.Drawing.Point(9, 50);
			this.textBox_UnidadeContrato.Name = "textBox_UnidadeContrato";
			this.textBox_UnidadeContrato.Size = new System.Drawing.Size(222, 25);
			this.textBox_UnidadeContrato.TabIndex = 10;
			// 
			// textBox_OperadoraDaUnidade
			// 
			this.textBox_OperadoraDaUnidade.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.textBox_OperadoraDaUnidade.Location = new System.Drawing.Point(239, 50);
			this.textBox_OperadoraDaUnidade.Name = "textBox_OperadoraDaUnidade";
			this.textBox_OperadoraDaUnidade.Size = new System.Drawing.Size(222, 25);
			this.textBox_OperadoraDaUnidade.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(9, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 17);
			this.label2.TabIndex = 12;
			this.label2.Text = "Unidade / Contrato";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(239, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 17);
			this.label3.TabIndex = 13;
			this.label3.Text = "Operadora";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label4.Location = new System.Drawing.Point(2, 279);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(468, 17);
			this.label4.TabIndex = 14;
			this.label4.Text = "_________________________________________________________________________________" +
	"___________";
			// 
			// label_textoDeAvisoUnidadeContrato
			// 
			this.label_textoDeAvisoUnidadeContrato.AutoSize = true;
			this.label_textoDeAvisoUnidadeContrato.BackColor = System.Drawing.Color.Transparent;
			this.label_textoDeAvisoUnidadeContrato.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_textoDeAvisoUnidadeContrato.ForeColor = System.Drawing.Color.Red;
			this.label_textoDeAvisoUnidadeContrato.Location = new System.Drawing.Point(9, 76);
			this.label_textoDeAvisoUnidadeContrato.Name = "label_textoDeAvisoUnidadeContrato";
			this.label_textoDeAvisoUnidadeContrato.Size = new System.Drawing.Size(33, 13);
			this.label_textoDeAvisoUnidadeContrato.TabIndex = 15;
			this.label_textoDeAvisoUnidadeContrato.Text = "aviso";
			this.label_textoDeAvisoUnidadeContrato.Visible = false;
			// 
			// label_textoDeAvisoOperadora
			// 
			this.label_textoDeAvisoOperadora.AutoSize = true;
			this.label_textoDeAvisoOperadora.BackColor = System.Drawing.Color.Transparent;
			this.label_textoDeAvisoOperadora.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_textoDeAvisoOperadora.ForeColor = System.Drawing.Color.Red;
			this.label_textoDeAvisoOperadora.Location = new System.Drawing.Point(239, 76);
			this.label_textoDeAvisoOperadora.Name = "label_textoDeAvisoOperadora";
			this.label_textoDeAvisoOperadora.Size = new System.Drawing.Size(33, 13);
			this.label_textoDeAvisoOperadora.TabIndex = 16;
			this.label_textoDeAvisoOperadora.Text = "aviso";
			this.label_textoDeAvisoOperadora.Visible = false;
			// 
			// UcRegistroDeOcorrenciaInterna
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.label_textoDeAvisoOperadora);
			this.Controls.Add(this.label_textoDeAvisoUnidadeContrato);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_OperadoraDaUnidade);
			this.Controls.Add(this.textBox_UnidadeContrato);
			this.Controls.Add(this.btnPreviewMessage);
			this.Controls.Add(this.btnCloseWindow);
			this.Controls.Add(this.btnSalvarContratoEOperadora);
			this.Controls.Add(this.btnClearFields);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox_RegistroDeOcorrencia);
			this.ForeColor = System.Drawing.SystemColors.Control;
			this.Name = "UcRegistroDeOcorrenciaInterna";
			this.Size = new System.Drawing.Size(470, 380);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
