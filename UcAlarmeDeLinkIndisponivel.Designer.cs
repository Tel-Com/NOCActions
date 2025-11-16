/*
 * Created by SharpDevelop.
 * User: fjstavares
 * Date: 18/07/2025
 * Time: 10:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NOC_Actions
{
	partial class UcAlarmeDeLinkIndisponivel
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnSaveAndCopy;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxDowntime;
		private System.Windows.Forms.ComboBox comboBoxCarrierName;
		private System.Windows.Forms.Button btnClearFields;
		private System.Windows.Forms.Label title_ExemploDeMensagem;
		private System.Windows.Forms.Button btnCloseWindow;
		private System.Windows.Forms.Button btnDeletarTodosOsItensSelecionadosDaLista;
		private System.Windows.Forms.Button btnDeletarItemSelecionadoDaLista;
		private System.Windows.Forms.Button btnPrevia;
		private System.Windows.Forms.CheckBox checkBox_Sim;
		private System.Windows.Forms.CheckBox checkBox_Não;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelAvisoDeUso;
		private System.Windows.Forms.Label labelModoDiretor;
		
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
			this.btnSaveAndCopy = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxDowntime = new System.Windows.Forms.TextBox();
			this.btnClearFields = new System.Windows.Forms.Button();
			this.title_ExemploDeMensagem = new System.Windows.Forms.Label();
			this.btnCloseWindow = new System.Windows.Forms.Button();
			this.comboBoxCarrierName = new System.Windows.Forms.ComboBox();
			this.btnDeletarTodosOsItensSelecionadosDaLista = new System.Windows.Forms.Button();
			this.btnDeletarItemSelecionadoDaLista = new System.Windows.Forms.Button();
			this.btnPrevia = new System.Windows.Forms.Button();
			this.checkBox_Sim = new System.Windows.Forms.CheckBox();
			this.checkBox_Não = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.labelAvisoDeUso = new System.Windows.Forms.Label();
			this.labelModoDiretor = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(44, 203);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(391, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "________________________________________________________________";
			// 
			// btnSaveAndCopy
			// 
			this.btnSaveAndCopy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSaveAndCopy.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnSaveAndCopy.Location = new System.Drawing.Point(357, 315);
			this.btnSaveAndCopy.Name = "btnSaveAndCopy";
			this.btnSaveAndCopy.Size = new System.Drawing.Size(96, 44);
			this.btnSaveAndCopy.TabIndex = 2;
			this.btnSaveAndCopy.Text = "Gravar e Copiar";
			this.btnSaveAndCopy.UseVisualStyleBackColor = true;
			this.btnSaveAndCopy.Click += new System.EventHandler(this.BtnSaveAndCopyClick);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label4.Location = new System.Drawing.Point(3, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "Mensagem a ser exibida";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label3.Location = new System.Drawing.Point(57, 162);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "Horário da Queda";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label2.Location = new System.Drawing.Point(57, 126);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Operadora";
			// 
			// textBoxDowntime
			// 
			this.textBoxDowntime.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.textBoxDowntime.Location = new System.Drawing.Point(178, 158);
			this.textBoxDowntime.Name = "textBoxDowntime";
			this.textBoxDowntime.Size = new System.Drawing.Size(196, 25);
			this.textBoxDowntime.TabIndex = 1;
			// 
			// btnClearFields
			// 
			this.btnClearFields.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnClearFields.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnClearFields.Location = new System.Drawing.Point(255, 315);
			this.btnClearFields.Name = "btnClearFields";
			this.btnClearFields.Size = new System.Drawing.Size(96, 44);
			this.btnClearFields.TabIndex = 3;
			this.btnClearFields.Text = "Apagar";
			this.btnClearFields.UseVisualStyleBackColor = true;
			this.btnClearFields.Click += new System.EventHandler(this.BtnClearFieldsClick);
			// 
			// title_ExemploDeMensagem
			// 
			this.title_ExemploDeMensagem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.title_ExemploDeMensagem.Location = new System.Drawing.Point(3, 23);
			this.title_ExemploDeMensagem.Name = "title_ExemploDeMensagem";
			this.title_ExemploDeMensagem.Size = new System.Drawing.Size(464, 51);
			this.title_ExemploDeMensagem.TabIndex = 0;
			this.title_ExemploDeMensagem.Text = "Prezados, [saudação]! Identificamos que o link da operadora [nome da operadora] e" +
	"stá indisponível às [hh:mm]. Daremos sequência ao acionamento junto ao fornecedo" +
	"r.";
			// 
			// btnCloseWindow
			// 
			this.btnCloseWindow.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCloseWindow.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnCloseWindow.Location = new System.Drawing.Point(34, 315);
			this.btnCloseWindow.Name = "btnCloseWindow";
			this.btnCloseWindow.Size = new System.Drawing.Size(96, 44);
			this.btnCloseWindow.TabIndex = 4;
			this.btnCloseWindow.Text = "Fechar";
			this.btnCloseWindow.UseVisualStyleBackColor = true;
			this.btnCloseWindow.Click += new System.EventHandler(this.BtnCloseWindowClick);
			// 
			// comboBoxCarrierName
			// 
			this.comboBoxCarrierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBoxCarrierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBoxCarrierName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.comboBoxCarrierName.FormattingEnabled = true;
			this.comboBoxCarrierName.Location = new System.Drawing.Point(178, 126);
			this.comboBoxCarrierName.Name = "comboBoxCarrierName";
			this.comboBoxCarrierName.Size = new System.Drawing.Size(196, 25);
			this.comboBoxCarrierName.TabIndex = 0;
			// 
			// btnDeletarTodosOsItensSelecionadosDaLista
			// 
			this.btnDeletarTodosOsItensSelecionadosDaLista.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDeletarTodosOsItensSelecionadosDaLista.Enabled = false;
			this.btnDeletarTodosOsItensSelecionadosDaLista.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnDeletarTodosOsItensSelecionadosDaLista.Location = new System.Drawing.Point(339, 219);
			this.btnDeletarTodosOsItensSelecionadosDaLista.Name = "btnDeletarTodosOsItensSelecionadosDaLista";
			this.btnDeletarTodosOsItensSelecionadosDaLista.Size = new System.Drawing.Size(96, 40);
			this.btnDeletarTodosOsItensSelecionadosDaLista.TabIndex = 9;
			this.btnDeletarTodosOsItensSelecionadosDaLista.Text = "Deletar Lista";
			this.btnDeletarTodosOsItensSelecionadosDaLista.UseVisualStyleBackColor = true;
			this.btnDeletarTodosOsItensSelecionadosDaLista.Click += new System.EventHandler(this.BtnDeletarTodosOsItensSelecionadosDaListaClick);
			// 
			// btnDeletarItemSelecionadoDaLista
			// 
			this.btnDeletarItemSelecionadoDaLista.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDeletarItemSelecionadoDaLista.Enabled = false;
			this.btnDeletarItemSelecionadoDaLista.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnDeletarItemSelecionadoDaLista.Location = new System.Drawing.Point(200, 219);
			this.btnDeletarItemSelecionadoDaLista.Name = "btnDeletarItemSelecionadoDaLista";
			this.btnDeletarItemSelecionadoDaLista.Size = new System.Drawing.Size(133, 40);
			this.btnDeletarItemSelecionadoDaLista.TabIndex = 10;
			this.btnDeletarItemSelecionadoDaLista.Text = "Deletar Selecionado";
			this.btnDeletarItemSelecionadoDaLista.UseVisualStyleBackColor = true;
			this.btnDeletarItemSelecionadoDaLista.Click += new System.EventHandler(this.BtnDeletarItemSelecionadoDaListaClick);
			// 
			// btnPrevia
			// 
			this.btnPrevia.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnPrevia.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.btnPrevia.Location = new System.Drawing.Point(153, 315);
			this.btnPrevia.Name = "btnPrevia";
			this.btnPrevia.Size = new System.Drawing.Size(96, 44);
			this.btnPrevia.TabIndex = 11;
			this.btnPrevia.Text = "Prévia";
			this.btnPrevia.UseVisualStyleBackColor = true;
			// 
			// checkBox_Sim
			// 
			this.checkBox_Sim.AutoSize = true;
			this.checkBox_Sim.BackColor = System.Drawing.Color.Transparent;
			this.checkBox_Sim.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBox_Sim.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.checkBox_Sim.Location = new System.Drawing.Point(52, 236);
			this.checkBox_Sim.Name = "checkBox_Sim";
			this.checkBox_Sim.Size = new System.Drawing.Size(48, 21);
			this.checkBox_Sim.TabIndex = 12;
			this.checkBox_Sim.Text = "Sim";
			this.checkBox_Sim.UseVisualStyleBackColor = false;
			this.checkBox_Sim.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// checkBox_Não
			// 
			this.checkBox_Não.AutoSize = true;
			this.checkBox_Não.BackColor = System.Drawing.Color.Transparent;
			this.checkBox_Não.Checked = true;
			this.checkBox_Não.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_Não.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBox_Não.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.checkBox_Não.Location = new System.Drawing.Point(98, 236);
			this.checkBox_Não.Name = "checkBox_Não";
			this.checkBox_Não.Size = new System.Drawing.Size(52, 21);
			this.checkBox_Não.TabIndex = 13;
			this.checkBox_Não.Text = "Não";
			this.checkBox_Não.UseVisualStyleBackColor = false;
			this.checkBox_Não.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.label1.Location = new System.Drawing.Point(44, 216);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 17);
			this.label1.TabIndex = 14;
			this.label1.Text = "Operadora";
			// 
			// labelAvisoDeUso
			// 
			this.labelAvisoDeUso.AutoSize = true;
			this.labelAvisoDeUso.BackColor = System.Drawing.Color.Transparent;
			this.labelAvisoDeUso.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.labelAvisoDeUso.ForeColor = System.Drawing.Color.Red;
			this.labelAvisoDeUso.Location = new System.Drawing.Point(44, 260);
			this.labelAvisoDeUso.Name = "labelAvisoDeUso";
			this.labelAvisoDeUso.Size = new System.Drawing.Size(39, 17);
			this.labelAvisoDeUso.TabIndex = 15;
			this.labelAvisoDeUso.Text = "Aviso";
			this.labelAvisoDeUso.Visible = false;
			// 
			// labelModoDiretor
			// 
			this.labelModoDiretor.AutoSize = true;
			this.labelModoDiretor.BackColor = System.Drawing.Color.Transparent;
			this.labelModoDiretor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelModoDiretor.ForeColor = System.Drawing.Color.Red;
			this.labelModoDiretor.Location = new System.Drawing.Point(325, 6);
			this.labelModoDiretor.Name = "labelModoDiretor";
			this.labelModoDiretor.Size = new System.Drawing.Size(142, 17);
			this.labelModoDiretor.TabIndex = 16;
			this.labelModoDiretor.Text = "Modo Diretor ativado";
			this.labelModoDiretor.Visible = false;
			// 
			// UcAlarmeDeLinkIndisponivel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.labelModoDiretor);
			this.Controls.Add(this.labelAvisoDeUso);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkBox_Não);
			this.Controls.Add(this.checkBox_Sim);
			this.Controls.Add(this.btnPrevia);
			this.Controls.Add(this.btnDeletarTodosOsItensSelecionadosDaLista);
			this.Controls.Add(this.btnDeletarItemSelecionadoDaLista);
			this.Controls.Add(this.comboBoxCarrierName);
			this.Controls.Add(this.btnCloseWindow);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnSaveAndCopy);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxDowntime);
			this.Controls.Add(this.btnClearFields);
			this.Controls.Add(this.title_ExemploDeMensagem);
			this.Name = "UcAlarmeDeLinkIndisponivel";
			this.Size = new System.Drawing.Size(470, 380);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
