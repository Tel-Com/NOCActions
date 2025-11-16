using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace NOC_Actions
{
	public partial class UcAlarmeDeLinkIndisponivel : UserControl
	{
		private readonly string Uc_AlarmeDeLinkIndisponivel_arquivoOperadora  = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "registroDeOperadoraEmArquivo.txt");
		
		public UcAlarmeDeLinkIndisponivel()
		{
			InitializeComponent();
			CarregarComboBoxItems();
		}
		
		private string ObterSaudacao()
		{
			int hora = DateTime.Now.Hour;
			
			if (hora >= 5 && hora < 12)
				return "bom dia";
			else if (hora >= 12 && hora < 18)
				return "boa tarde";
			else
				return "boa noite";
		}
		
		private string GetCustomerNotificationMessage()
		{
			string getValueCarrierName = comboBoxCarrierName.Text;
			string getValueHorario_Queda = textBoxDowntime.Text;
			return "Prezados, " + ObterSaudacao() + "! Identificamos que o link da operadora "
				+ getValueCarrierName + " está indisponível às " + getValueHorario_Queda
				+ ". Daremos sequência ao acionamento junto ao fornecedor.";
		}
		
		private void SalvarArquivoOperadoraDoCliente()
		{
			string adicionarOperadoraDoClienteEmLista = comboBoxCarrierName.Text.Trim();

			if (!string.IsNullOrWhiteSpace(adicionarOperadoraDoClienteEmLista) && !comboBoxCarrierName.Items.Contains(adicionarOperadoraDoClienteEmLista))
			{
				comboBoxCarrierName.Items.Add(adicionarOperadoraDoClienteEmLista);
				comboBoxCarrierName.Text = "";

				RegistrarNoArquivo(comboBoxCarrierName, Uc_AlarmeDeLinkIndisponivel_arquivoOperadora);
				
			}
		}

		private void RegistrarNoArquivo(ComboBox comboBox, string caminhoArquivo)
		{
			try
			{
				File.WriteAllLines(caminhoArquivo, comboBox.Items.Cast<string>());
			} catch (Exception ex) {
				MessageBox.Show("Erro ao realizar este procedimento. \n\n" + ex.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void CarregarComboBoxItems()
		{
			if (File.Exists(Uc_AlarmeDeLinkIndisponivel_arquivoOperadora))
			{
				string[] itens = File.ReadAllLines(Uc_AlarmeDeLinkIndisponivel_arquivoOperadora);
				comboBoxCarrierName.Items.AddRange(itens);
			}
		}

		private void DeletarInformesSelecionado()
		{
			if (comboBoxCarrierName.SelectedItem == null)
			{
				MessageBox.Show("Nenhum item selecionado para excluir.");
				return;
			}

			string itemSelecionado = comboBoxCarrierName.SelectedItem.ToString();
			comboBoxCarrierName.Items.Remove(itemSelecionado);

			// Atualiza o arquivo com os itens restantes
			File.WriteAllLines(Uc_AlarmeDeLinkIndisponivel_arquivoOperadora, comboBoxCarrierName.Items.Cast<string>());

			MessageBox.Show("Item removido com sucesso!");
		}

		
		private void DeletarListaDeInformesCompleta()
		{
			if (comboBoxCarrierName.Items.Count == 0)
			{
				MessageBox.Show("A lista já está vazia.");
				return;
			}

			if (MessageBox.Show("Deseja realmente apagar toda a lista?",
			                    "Confirmação",
			                    MessageBoxButtons.YesNo,
			                    MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				comboBoxCarrierName.Items.Clear();
				File.WriteAllText(Uc_AlarmeDeLinkIndisponivel_arquivoOperadora, "");
				
				MessageBox.Show("Lista completamente apagada!");
			}
		}

		
		void BtnDeletarTodosOsItensSelecionadosDaListaClick(object sender, EventArgs e)
		{
			DeletarListaDeInformesCompleta();
		}

		void BtnDeletarItemSelecionadoDaListaClick(object sender, EventArgs e)
		{
			DeletarInformesSelecionado();
		}

		
		void BtnCloseWindowClick(object sender, EventArgs e)
		{
			CloseWindow();
		}
		
		void BtnClearFieldsClick(object sender, EventArgs e)
		{
			ClearField();
		}
		
		void BtnSaveAndCopyClick(object sender, EventArgs e)
		{
			
			string msn = GetCustomerNotificationMessage();
			Clipboard.SetText(msn);
			SalvarArquivoOperadoraDoCliente();
			ClearField();
		}
		
		void ClearField()
		{
			comboBoxCarrierName.Text = "";
			textBoxDowntime.Text = "";
		}
		
		void CloseWindow()
		{
			this.FindForm().Close();
		}
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_Sim.Checked) {
				DesativarElementosNoFormTemporariamente(true);
			}
		}
		void CheckBox2CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox_Não.Checked) {
				checkBox_Sim.Checked = false;
				DesativarElementosNoFormTemporariamente(false);
			}
		}
		
		void DesativarElementosNoFormTemporariamente(bool modoAtivo)
		{
			if (modoAtivo) {
				checkBox_Não.Checked = false;
				btnDeletarItemSelecionadoDaLista.Enabled = true;
				btnDeletarTodosOsItensSelecionadosDaLista.Enabled = true;
				
				labelModoDiretor.Visible = true;
				btnSaveAndCopy.Enabled = false;
				btnClearFields.Enabled = false;
				btnPrevia.Enabled = false;
				textBoxDowntime.Enabled = false;
				
				labelAvisoDeUso.Visible = true;
				labelAvisoDeUso.Text = "Deletar Lista: Esta ação apagará todos os itens da lista.\nDeletar Selecionado: Esta ação apagará apenas o item atualmente\nselecionado.";
			}
			else
			{
				checkBox_Sim.Checked = false;
				btnDeletarItemSelecionadoDaLista.Enabled = false;
				btnDeletarTodosOsItensSelecionadosDaLista.Enabled = false;
				
				labelModoDiretor.Visible = false;
				labelAvisoDeUso.Visible = false;
				
				btnSaveAndCopy.Enabled = true;
				btnClearFields.Enabled = true;
				btnPrevia.Enabled = true;
				textBoxDowntime.Enabled = true;
			}
		}
	}
}