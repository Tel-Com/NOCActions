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
        
        // Caminhos dos arquivos que armazenam as informações
        private string arquivoEmailRemetente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "email_usuario_remetente.txt");
        private string arquivoEmailCorporativoCc = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "email_usuario_empresarial_copy.txt");
        private string arquivoInformacoesContratoCliente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "informacoes_do_contrato_do_cliente.txt");
        private string arquivoEmailCliente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "email_de_clientes.txt");

        // Construtor do formulário de configuração
        public CONFIG_ComunicacaoComCliente(ACAO_ComunicacaoComCliente form)
        {
            InitializeComponent();  // Inicializa os componentes do formulário
            form_comunicacaoComCliente = form;  // Armazena a referência do formulário principal
            CarregarEmailsSalvosNosComboBox();  // Carrega os e-mails previamente salvos ao abrir o formulário
            CarregarEmailsDeRemetentesSalvos();
            CarregarEmailCorporativoEmCopy();
            CarregarInformacoesDoContratoDoCliente();
        }

        // Evento de clique do botão de salvar
        void BtnSalvarClick(object sender, EventArgs e)
        {
            // Obtém os e-mails dos campos do formulário
            string emailDestinatario1 = comboEmailContratoCliente_01.Text;
            string emailDestinatario2 = comboEmailContratoCliente_02.Text;
            string emailDestinatario3 = comboEmailContratoCliente_03.Text;

            // Concatena os e-mails, separando-os por ponto e vírgula e removendo os vazios
            string concatenarEmails = string.Join(";", new[] { emailDestinatario1, emailDestinatario2, emailDestinatario3 }
                .Where(email => !string.IsNullOrWhiteSpace(email)));

            // Verifica se existem e-mails concatenados e os adiciona ao ComboBox do formulário principal
            if (!string.IsNullOrWhiteSpace(concatenarEmails))
            {
                form_comunicacaoComCliente.AdicionarEmailsConcatenados(concatenarEmails);
            }

            // Salva os e-mails no arquivo
            SalvarEmailsNoArquivo(concatenarEmails);
            InformacoesDoContratoDoCliente();
            
            this.Close();  // Fecha o formulário de configuração
        }

        /// <summary>
        /// Métodos relacionados ao envio de e-mails e à gestão de arquivos
        /// </summary>
        
        // Salva o e-mail do remetente
        private void SalvarEmailRemetente(string email)
        {
            try
            {
                string diretorio = Path.GetDirectoryName(arquivoEmailRemetente);
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                File.AppendAllText(arquivoEmailRemetente, email + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o e-mail do remetente: " + ex.Message);
            }
        }
        
        // Evento de clique do botão para salvar e-mail do remetente
        void BtnSalvarRemetenteClick(object sender, EventArgs e)
        {
            string emailRemetente = comboBox_Remetente.Text;
            SalvarEmailRemetente(emailRemetente);
            comboBox_Remetente.Text = string.Empty;
        }

        // Carrega os e-mails de remetente salvos no arquivo
        private void CarregarEmailsDeRemetentesSalvos()
        {
            if (File.Exists(arquivoEmailRemetente))
            {
                var remetentes = File.ReadAllLines(arquivoEmailRemetente)
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .Distinct()  // Evita e-mails duplicados
                    .ToList();

                foreach (var remetente in remetentes)
                {
                    if (!comboBox_Remetente.Items.Contains(remetente))
                    {
                        comboBox_Remetente.Items.Add(remetente);
                    }
                }
            }
        }

        // Salva o e-mail corporativo em cópia
        private void SalvarEmailCorporativoCopy(string emailCorporativo)
        {
            try
            {
                string diretorio = Path.GetDirectoryName(arquivoEmailCorporativoCc);
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                File.AppendAllText(arquivoEmailCorporativoCc, emailCorporativo + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o e-mail corporativo: " + ex.Message);
            }
        }

        // Evento de clique do botão para salvar o e-mail corporativo em cópia
        void BtnSalvarEmailCorporativoEmCopyClick(object sender, EventArgs e)
        {
            string emailCorporativo = comboBox_EmailCorporativoEmCopy.Text;
            SalvarEmailCorporativoCopy(emailCorporativo);
            comboBox_EmailCorporativoEmCopy.Text = string.Empty;
        }

        // Carrega os e-mails corporativos em cópia salvos no arquivo
        private void CarregarEmailCorporativoEmCopy()
        {
            if (File.Exists(arquivoEmailCorporativoCc))
            {
                var emailsCopy = File.ReadAllLines(arquivoEmailCorporativoCc)
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .Distinct()
                    .ToList();

                foreach (var email in emailsCopy)
                {
                    if (!comboBox_EmailCorporativoEmCopy.Items.Contains(email))
                    {
                        comboBox_EmailCorporativoEmCopy.Items.Add(email);
                    }
                }
            }
        }

        /// <summary>
        /// Métodos relacionados às informações do contrato do cliente
        /// </summary>
        
        private string arquivoNomeCliente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "nome_cliente.txt");
        private string arquivoEnderecoCliente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "endereco_cliente.txt");
        private string arquivoUnidadeCliente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "unidade_cliente.txt");
        private string arquivoRazaoSocialCliente = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "razao_social_cliente.txt");

        // Salva as informações do contrato do cliente
        private void InformacoesDoContratoDoCliente()
        {
            try
            {
                SalvarInformacoesEmArquivo(arquivoNomeCliente, comboNomeCliente.Text.Trim());
                SalvarInformacoesEmArquivo(arquivoEnderecoCliente, comboEnderecoCliente.Text.Trim());
                SalvarInformacoesEmArquivo(arquivoUnidadeCliente, comboUnidadeDoCliente.Text.Trim());
                SalvarInformacoesEmArquivo(arquivoRazaoSocialCliente, comboRazaoSocialCliente.Text.Trim());
                
                // Limpa os campos após salvar
                LimparCamposContratoCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar as informações do cliente: " + ex.Message);
            }
        }

        // Salva as informações em arquivo
        private void SalvarInformacoesEmArquivo(string caminhoArquivo, string conteudo)
        {
            if (!string.IsNullOrWhiteSpace(conteudo))
            {
                string diretorio = Path.GetDirectoryName(caminhoArquivo);
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                File.AppendAllText(caminhoArquivo, conteudo + Environment.NewLine);
            }
        }

        // Limpa os campos de informações do contrato do cliente
        private void LimparCamposContratoCliente()
        {
            comboNomeCliente.Text = string.Empty;
            comboEnderecoCliente.Text = string.Empty;
            comboUnidadeDoCliente.Text = string.Empty;
            comboRazaoSocialCliente.Text = string.Empty;
        }

        // Carrega as informações do contrato do cliente
        private void CarregarInformacoesDoContratoDoCliente()
        {
            CarregarInformacaoEmComboBox(arquivoNomeCliente, comboNomeCliente);
            CarregarInformacaoEmComboBox(arquivoEnderecoCliente, comboEnderecoCliente);
            CarregarInformacaoEmComboBox(arquivoUnidadeCliente, comboUnidadeDoCliente);
            CarregarInformacaoEmComboBox(arquivoRazaoSocialCliente, comboRazaoSocialCliente);
        }

        // Carrega informações de um arquivo para o ComboBox
        private void CarregarInformacaoEmComboBox(string caminhoArquivo, ComboBox comboBox)
        {
            if (File.Exists(caminhoArquivo))
            {
                var linhas = File.ReadAllLines(caminhoArquivo)
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .Distinct()
                    .ToList();

                foreach (var linha in linhas)
                {
                    if (!comboBox.Items.Contains(linha))
                    {
                        comboBox.Items.Add(linha);
                    }
                }
            }
        }

        /// <summary>
        /// Métodos relacionados aos e-mails dos clientes
        /// </summary>
        
        // Salva os e-mails no arquivo de clientes
        private void SalvarEmailsNoArquivo(string email)
        {
            try
            {
                string diretorio = Path.GetDirectoryName(arquivoEmailCliente);
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                File.AppendAllText(arquivoEmailCliente, email + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o e-mail: " + ex.Message);
            }
        }

        // Carrega os e-mails salvos nos ComboBoxes
        private void CarregarEmailsSalvosNosComboBox()
        {
            if (File.Exists(arquivoEmailCliente))
            {
                var emails = File.ReadAllLines(arquivoEmailCliente)
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .ToList();

                foreach (var email in emails)
                {
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
