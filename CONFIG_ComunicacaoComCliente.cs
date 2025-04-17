/*
 * Created by SharpDevelop.
 * User: fjstavares
 * Date: 26/02/2025
 * Time: 15:54
 */

using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Mail;

namespace NOCActions
{
	// Formulário de configuração de comunicação com o cliente
	public partial class CONFIG_ComunicacaoComCliente : Form
	{
		private Timer timer; // Timer usado para gerar um ID único
		private ToolTip toolTip = new ToolTip(); // ToolTip para exibir informações adicionais ao passar o mouse

		// Construtor inicial que configura o formulário e carrega dados essenciais
		public CONFIG_ComunicacaoComCliente()
		{
			InitializeComponent(); // Inicializa os componentes do formulário
			OrdenarTabIndex(); // Organiza a navegação entre os controles com a tecla Tab
			TimerGeneratorReload(); // Inicia o timer que gera o ID único
			CarregarInformacoesDeRegistro(); // Carrega os dados salvos no registro do Windows
			//            this.listBox_ClientesAdicionados.MouseMove += new MouseEventHandler(ListBox_ClientesAdicionados_MouseMove); // Evento de movimentação do mouse no ListBox

			// Carrega a lista de clientes previamente salvos no arquivo local
			CarregarListaLocalmente();

			// Configura o evento para quando um item for selecionado no ListBox
			//            this.listBox_ClientesAdicionados.SelectedIndexChanged += listBox_ClientesAdicionados_SelectedIndexChanged;
		}

		// Construtor que preenche os campos do formulário com valores passados como parâmetros
		public CONFIG_ComunicacaoComCliente(string V1, string V2, string V3, string V4, string V5, string V6, string V7)
		{
			InitializeComponent(); // Inicializa os componentes do formulário
			comboNomeCliente.Text = V1;
			comboEnderecoCliente.Text = V2;
			comboUnidadeDoCliente.Text = V3;
			comboRazaoSocialCliente.Text = V4;
			comboEmailContratoCliente_01.Text = V5;
			comboEmailContratoCliente_02.Text = V6;
			comboEmailContratoCliente_03.Text = V7;
		}

		// Método que salva as informações do formulário no registro do Windows
		private void SalvarInformacoesDoFormulario()
		{
			try
			{
				// Cria ou abre a chave de registro onde as informações do cliente serão armazenadas
				RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\NOCActions\Cliente");

				// Salva os dados de cada campo (ComboBox) na chave do registro
				SalvarDadoNaLista(key, "NomeClientes", comboNomeCliente.Text);
				SalvarDadoNaLista(key, "Enderecos", comboEnderecoCliente.Text);
				SalvarDadoNaLista(key, "Unidades", comboUnidadeDoCliente.Text);
				SalvarDadoNaLista(key, "RazoesSociais", comboRazaoSocialCliente.Text);
				SalvarDadoNaLista(key, "Emails", comboEmailContratoCliente_01.Text);

				key.Close(); // Fecha a chave do registro após salvar os dados
			}
			catch (Exception ex)
			{
				// Exibe mensagem de erro caso haja uma falha ao salvar
				MessageBox.Show("Erro ao salvar os dados: " + ex.Message);
			}
		}

		// Método auxiliar para salvar um dado de lista (campo específico) no registro
		private void SalvarDadoNaLista(RegistryKey KeyDown, string chave, string valor)
		{
			string dadosSalvos = KeyDown.GetValue(chave, "").ToString();
			List<string> lista = dadosSalvos.Split('|').ToList(); // Divide os dados existentes em uma lista de strings

			// Adiciona o valor à lista se não estiver presente e não for vazio
			if (!lista.Contains(valor) && !string.IsNullOrWhiteSpace(valor))
			{
				lista.Add(valor); // Adiciona o novo valor à lista
				lista.Sort(); // Ordena a lista alfabeticamente
				KeyDown.SetValue(chave, string.Join("|", lista.ToArray())); // Atualiza a chave de registro com a lista ordenada
			}
		}

		// Método que carrega as informações do registro para os campos do formulário
		private void CarregarInformacoesDeRegistro()
		{
			try
			{
				// Abre a chave de registro onde as informações do cliente estão armazenadas
				RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\NOCActions\Cliente");

				if (key != null)
				{
					// Carrega as listas de clientes, endereços, etc., para os ComboBox do formulário
					CarregarListaNoComboBox(key, "NomeClientes", comboNomeCliente);
					CarregarListaNoComboBox(key, "Enderecos", comboEnderecoCliente);
					CarregarListaNoComboBox(key, "Unidades", comboUnidadeDoCliente);
					CarregarListaNoComboBox(key, "RazoesSociais", comboRazaoSocialCliente);
					CarregarListaNoComboBox(key, "Emails", comboEmailContratoCliente_01);

					key.Close(); // Fecha a chave do registro após carregar os dados
				}
			}
			catch (Exception ex)
			{
				// Exibe mensagem de erro caso haja uma falha ao carregar os dados
				MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
			}
		}

		// Método que carrega uma lista de itens de uma chave do registro para um ComboBox
		private void CarregarListaNoComboBox(RegistryKey key, string chave, ComboBox comboBox)
		{
			string dados = key.GetValue(chave, "").ToString();
			string[] itens = dados.Split('|'); // Separa os dados em um array de strings

			comboBox.Items.Clear(); // Limpa os itens do ComboBox antes de adicionar os novos

			// Adiciona cada item ao ComboBox, se não estiver vazio
			foreach (string item in itens)
			{
				if (!string.IsNullOrWhiteSpace(item))
				{
					comboBox.Items.Add(item); // Adiciona o item ao ComboBox
				}
			}

			comboBox.Sorted = true; // Ordena os itens do ComboBox
		}

		// Organiza os índices de Tab para os controles do formulário (para navegação com a tecla Tab)
		private void OrdenarTabIndex()
		{
			comboNomeCliente.TabIndex = 0;
			comboEnderecoCliente.TabIndex = 1;
			comboUnidadeDoCliente.TabIndex = 2;
			comboRazaoSocialCliente.TabIndex = 3;
			btnSalvar.TabIndex = 4;
			btnExcluir.TabIndex = 5;
			btnSair.TabIndex = 6;
		}

		// Inicia o timer para gerar um ID único
		private void TimerGeneratorReload()
		{
			timer = new Timer(); // Cria uma nova instância do timer
			timer.Interval = 100; // Define o intervalo do timer como 100 milissegundos
			timer.Tick += Timer_Tick; // Define o evento que será acionado a cada "tick" do timer
			timer.Start(); // Inicia o timer
		}

		// Gera um ID único baseado em um GUID e exibe no campo de texto
		private void GerarIDUnico()
		{
			string uniqueID = "T&C" + Guid.NewGuid().ToString("N").Substring(0, 10); // Gera um ID único de 10 caracteres
			maskedTextBox1UserID.Text = uniqueID; // Exibe o ID no campo de texto
		}

		// Evento chamado a cada "tick" do timer, que chama a geração do ID único
		private void Timer_Tick(object sender, EventArgs e)
		{
			GerarIDUnico(); // Gera um ID único
			timer.Stop(); // Para o timer após gerar o ID
		}

		// Método que lida com o evento de clicar no botão "Salvar"
		void BtnSalvarClick(object sender, EventArgs e)
		{
			SalvarInformacoesDoFormulario(); // Salva as informações do formulário no registro

			// Coleta os dados preenchidos nos campos
			string nomeCliente = comboNomeCliente.Text;
			string enderecoCliente = comboEnderecoCliente.Text;
			string unidadeCliente = comboUnidadeDoCliente.Text;
			string razaoSocialCliente = comboRazaoSocialCliente.Text;
			string emailContatoCliente_01 = comboEmailContratoCliente_01.Text;
			string emailContatoCliente_02 = comboEmailContratoCliente_02.Text;
			string emailContatoCliente_03 = comboEmailContratoCliente_03.Text;

			// Verifica se os campos obrigatórios estão preenchidos
			if (!string.IsNullOrWhiteSpace(comboNomeCliente.Text) &&
			    !string.IsNullOrWhiteSpace(comboRazaoSocialCliente.Text) &&
			    !string.IsNullOrWhiteSpace(comboEnderecoCliente.Text) &&
			    !string.IsNullOrWhiteSpace(comboEmailContratoCliente_01.Text) &&
			    !string.IsNullOrWhiteSpace(comboEmailContratoCliente_02.Text) &&
			    !string.IsNullOrWhiteSpace(comboEmailContratoCliente_03.Text))
			{
				// Formata o texto para exibir no ListBox
				string textoCliente = string.Format("Cliente: {0} | Razão Social: {1} | Endereço: {2} | E-mail p/ Contato: {3} | {4} | {5}", nomeCliente, razaoSocialCliente, enderecoCliente, emailContatoCliente_01, emailContatoCliente_02, emailContatoCliente_03).ToUpper();

				// Adiciona o item ao ListBox, se não estiver presente
				if (!string.IsNullOrWhiteSpace(textoCliente) && !listBox_ClientesAdicionados.Items.Contains(textoCliente))
				{
					listBox_ClientesAdicionados.Items.Add(textoCliente); // Adiciona ao ListBox
					SalvarListaLocalmente(); // Salva a lista localmente
				}
			}
			else
			{
				// Exibe um erro caso os campos obrigatórios não estejam preenchidos
				MessageBox.Show("Por favor, preencha todos os campos obrigatórios antes de adicionar o cliente.",
				                "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			
			//            teste de concatenação dos emails
			EmailsConcatenados = string.Format("{0};{1};{2}", emailContatoCliente_01, emailContatoCliente_02, emailContatoCliente_03);
			
		}

		// Método que salva a lista de clientes localmente em um arquivo de texto
		private void SalvarListaLocalmente()
		{
			try
			{
				string caminhoArquivoLista = "lista_de_clientes_salvos.txt"; // Caminho do arquivo onde a lista será salva

				// Abre o arquivo e escreve cada item do ListBox, um por linha
				using (StreamWriter sw = new StreamWriter(caminhoArquivoLista, false))
				{
					foreach (var item in listBox_ClientesAdicionados.Items)
					{
						sw.WriteLine(item.ToString()); // Escreve cada item no arquivo
					}
				}
			}
			catch (Exception ex)
			{
				// Exibe uma mensagem de erro caso falhe ao salvar o arquivo
				MessageBox.Show("Erro ao salvar os dados no arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Método que carrega a lista de clientes de um arquivo de texto para o ListBox
		private void CarregarListaLocalmente()
		{
			try
			{
				string caminhoArquivoLista = "lista_de_clientes_salvos.txt"; // Caminho do arquivo onde a lista está salva

				// Verifica se o arquivo existe
				if (File.Exists(caminhoArquivoLista))
				{
					// Lê o arquivo e adiciona os itens ao ListBox
					string[] clientes = File.ReadAllLines(caminhoArquivoLista);
					foreach (var cliente in clientes)
					{
						listBox_ClientesAdicionados.Items.Add(cliente); // Adiciona ao ListBox
					}
				}
			}
			catch (Exception ex)
			{
				// Exibe uma mensagem de erro caso falhe ao carregar o arquivo
				MessageBox.Show("Erro ao carregar a lista de clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		public string EmailsConcatenados { get; private set; }
		
	}
}
