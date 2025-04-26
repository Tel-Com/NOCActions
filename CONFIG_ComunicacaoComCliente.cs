using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace NOCActions
{
	// Formulário de configuração de comunicação com o cliente
	public partial class CONFIG_ComunicacaoComCliente : Form
	{
		private ACAO_ComunicacaoComCliente form_comunicacaoComCliente;  // Referência para o formulário principal
		
		// Caminhos dos arquivos que armazenam os e-mails
		private string arquivo_email_remetente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "email_usuario_remetente.txt");
		private string arquivo_email_empresarialCc = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "email_usuario_empresarial_copy.txt");
		private string arquivo_informacoes_do_contrato_do_cliente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "informacoes_do_contrato_do_cliente.txt");
		private string arquivo_email_cliente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "email_de_clientes.txt");

		// Construtor do formulário de configuração
		// Recebe o formulário principal e carrega os e-mails salvos nos ComboBoxes
		public CONFIG_ComunicacaoComCliente(ACAO_ComunicacaoComCliente form)
		{
			InitializeComponent();  // Inicializa os componentes do formulário
			form_comunicacaoComCliente = form;  // Armazena a referência do formulário principal
			CarregarEmailsSalvosNosComboBox();  // Carrega os e-mails previamente salvos ao abrir o formulário
			
			CarregarEmailsDeRemetentesSalvos();
			
		}

		// Evento de clique do botão de salvar
		// Concatena os e-mails e os adiciona ao ComboBox do formulário principal, além de salvar no arquivo
		void BtnSalvarClick(object sender, EventArgs e)
		{
			// Obtém os e-mails dos campos do formulário
			string emailDestinatario1 = comboEmailContratoCliente_01.Text;
			string emailDestinatario2 = comboEmailContratoCliente_02.Text;
			string emailDestinatario3 = comboEmailContratoCliente_03.Text;

			// Concatena os e-mails, separando-os por ponto e vírgula e removendo os vazios
			string concatenarEmails = string.Join(";", new[] {
			                                      	emailDestinatario1,
			                                      	emailDestinatario2,
			                                      	emailDestinatario3
			                                      }.Where(email => !string.IsNullOrWhiteSpace(email)));

			// Verifica se existem e-mails concatenados e os adiciona ao ComboBox do formulário principal
			if (!string.IsNullOrWhiteSpace(concatenarEmails))
			{
				form_comunicacaoComCliente.AdicionarEmailsConcatenados(concatenarEmails);
			}

			// Salva os e-mails no arquivo
			SalvarEmailsNoArquivo(concatenarEmails);
			this.Close();  // Fecha o formulário de configuração
		}

		/// <summary>
		/// Métodos e processos de funcionamento destinado aos E-mails de Usuário Padrão e Usuário Empresarial / Corporativo
		/// <summary/>
		
//		Método usuário Remetente
		private void EmailRemente(string email)
		{
			try {
				string newUsuarioRemetenteArquivo = Path.GetDirectoryName(arquivo_email_remetente);
				
				if (!Directory.Exists(newUsuarioRemetenteArquivo))
				{
					Directory.CreateDirectory(newUsuarioRemetenteArquivo);
				}
				
				File.AppendAllText(arquivo_email_remetente, email + Environment.NewLine);
				
			} catch (Exception ex)
			{
				// Caso ocorra algum erro, exibe uma mensagem de erro
				MessageBox.Show("Erro ao salvar o e-mail do remetente: " + ex.Message);
			}
		}
		
		void BtnSalvarRemetenteClick(object sender, EventArgs e)
		{
			string email_usuario_remetnete = comboBox_Remetente.Text;
			EmailRemente(email_usuario_remetnete);
			
			comboBox_Remetente.Text = string.Empty;
		}
		
		private void CarregarEmailsDeRemetentesSalvos()
		{
			if(File.Exists(arquivo_email_remetente))
			{
				var remetentes = File.ReadAllLines(arquivo_email_remetente)
					.Where(l => !string.IsNullOrWhiteSpace(l))
					.Distinct() // Para evitar e-mails duplicados
					.ToList();
				
				foreach (var remetente in remetentes) {
					if(!comboBox_Remetente.Items.Contains(remetente))
					{
						comboBox_Remetente.Items.Add(remetente);
					}
				}
			}
		}
		
		
//		break
		
		// Salva os e-mails concatenados no arquivo
		// Cria o diretório caso não exista e adiciona os e-mails ao arquivo
		private void SalvarEmailsNoArquivo(string email)
		{
			try
			{
				string newDirectory = Path.GetDirectoryName(arquivo_email_cliente);
				// Cria o diretório se ele não existir
				if (!Directory.Exists(newDirectory))
				{
					Directory.CreateDirectory(newDirectory);
				}

				// Adiciona os e-mails ao arquivo de texto
				File.AppendAllText(arquivo_email_cliente, email + Environment.NewLine);
			}
			catch (Exception ex)
			{
				// Caso ocorra erro ao salvar, exibe uma mensagem de erro
				MessageBox.Show("Erro ao salvar o e-mail: " + ex.Message);
			}
		}

		// Carrega os e-mails salvos no arquivo para os ComboBoxes
		// Os e-mails são adicionados sem duplicação
		private void CarregarEmailsSalvosNosComboBox()
		{
			// Verifica se o arquivo de e-mails existe
			if (File.Exists(arquivo_email_cliente))
			{
				// Lê todas as linhas do arquivo e remove as linhas vazias
				var linhas = File.ReadAllLines(arquivo_email_cliente)
					.Where(l => !string.IsNullOrWhiteSpace(l))
					.ToList();

				// Adiciona os e-mails no ComboBox, sem duplicar
				foreach (var email in linhas)
				{
					// Verifica se o e-mail já está presente e, caso não, o adiciona ao ComboBox correspondente
					if (!comboEmailContratoCliente_01.Items.Contains(email))
						comboEmailContratoCliente_01.Items.Add(email);
					if (!comboEmailContratoCliente_02.Items.Contains(email))
						comboEmailContratoCliente_02.Items.Add(email);
					if (!comboEmailContratoCliente_03.Items.Contains(email))
						comboEmailContratoCliente_03.Items.Add(email);
				}
			}
		}

	}
}
