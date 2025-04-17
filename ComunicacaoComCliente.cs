
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace NOCActions
{
	public partial class ACAO_ComunicacaoComCliente : Form
	{
		private const string RegistroChave = "SOFTWARE\\NOCActions\\Cliente";

		public ACAO_ComunicacaoComCliente()
		{
			InitializeComponent();
			OrdenarTabIndex();
			CarregarDadosCliente(); // Carregar dados ao iniciar
			// CarregarEmailsParaComboBoxPara(); // NÃO carregar os e-mails para comboBox2Para no construtor padrão
		}
		
		public ACAO_ComunicacaoComCliente(string nomeCliente, string enderecoCliente, string unidadeCliente, string razaoSocialCliente, string emailContatoCliente_01, string emailContatoCliente_02, string emailContatoCliente_03)
		{
			InitializeComponent();
			OrdenarTabIndex();
			SalvarDadosCliente(nomeCliente, enderecoCliente, unidadeCliente, razaoSocialCliente, emailContatoCliente_01, emailContatoCliente_02, emailContatoCliente_03);
			CarregarDadosCliente();
			// CarregarEmailsParaComboBoxPara(); // NÃO carregar os e-mails para comboBox2Para aqui também

			// Preenche o ComboBox "Para" com os e-mails recebidos
			PreencherComboBoxPara(emailContatoCliente_01, emailContatoCliente_02, emailContatoCliente_03);
		}

		private void PreencherComboBoxPara(string email1, string email2, string email3)
		{
			comboBox2Para.Items.Clear();

			List<string> emails = new List<string>();

			if (!string.IsNullOrWhiteSpace(email1)) emails.Add(email1.Trim());
			if (!string.IsNullOrWhiteSpace(email2)) emails.Add(email2.Trim());
			if (!string.IsNullOrWhiteSpace(email3)) emails.Add(email3.Trim());

			// Adiciona os e-mails individualmente ao ComboBox
			foreach (var email in emails.Distinct())
			{
				comboBox2Para.Items.Add(email);
			}

			// Aqui está a parte importante: define o texto do ComboBox com os e-mails concatenados
			if (emails.Any())
			{
				comboBox2Para.Text = string.Join(";", emails);
			}
			else
			{
				comboBox2Para.Text = string.Empty;
			}
		}

		private void SalvarDadosCliente(string nome, string endereco, string unidade, string razaoSocial, string email_01, string email_02, string email_03)
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistroChave);
				string dadosSalvos = key.GetValue("DadosCliente", "").ToString();
				SalvarDadoNoRegistro(key, "NomeClientes", nome);
				SalvarDadoNoRegistro(key, "Enderecos", endereco);
				SalvarDadoNoRegistro(key, "Unidades", unidade);
				SalvarDadoNoRegistro(key, "RazoesSociais", razaoSocial);
				SalvarDadoNoRegistro(key, "Emails", email_01);
				SalvarDadoNoRegistro(key, "Emails", email_02);
				SalvarDadoNoRegistro(key, "Emails", email_03);

				key.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro ao salvar os dados do cliente: " + ex.Message);
			}
		}

		private void SalvarDadoNoRegistro(RegistryKey key, string chave, string valor)
		{
			string dadosSalvos = key.GetValue(chave, "").ToString();
			List<string> listaDados = dadosSalvos.Split('|').ToList();

			if (!listaDados.Contains(valor) && !string.IsNullOrWhiteSpace(valor))
			{
				listaDados.Add(valor);
				listaDados.Sort();
				key.SetValue(chave, string.Join("|", listaDados));
			}
		}
		private void CarregarDadosCliente()
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistroChave);

				if (key != null)
				{
					// Carregar os dados certos para cada ComboBox
					CarregarDadosParaComboBox(key, "NomeClientes", comboBox1De);
					CarregarDadosParaComboBox(key, "Emails", comboBox2Para); // Carrega a lista geral de e-mails para "Para" também (será sobreescrito se vier do CONFIG)
					CarregarDadosParaComboBox(key, "Unidades", comboBox3Cc);

					key.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
			}
		}

		// Novo método para carregar os e-mails no comboBox2Para (a partir do registro)
		private void CarregarEmailsParaComboBoxPara()
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistroChave);

				if (key != null)
				{
					comboBox2Para.Items.Clear();
					CarregarListaDeEmails(key, "Emails", comboBox2Para);
					key.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro ao carregar os e-mails: " + ex.Message);
			}
		}

		// Método auxiliar específico para carregar listas de e-mails
		private void CarregarListaDeEmails(RegistryKey key, string chave, ComboBox comboBox)
		{
			string dadosSalvos = key.GetValue(chave, "").ToString();
			string[] dadosArray = dadosSalvos.Split('|');

			foreach (string dado in dadosArray)
			{
				if (!string.IsNullOrWhiteSpace(dado) && !comboBox.Items.Contains(dado))
				{
					comboBox.Items.Add(dado.Trim());
				}
			}
			comboBox.Sorted = true;
		}

		// Método auxiliar para carregar dados de uma chave específica do registro para um ComboBox
		private void CarregarDadosParaComboBox(RegistryKey key, string chave, ComboBox comboBox)
		{
			string dadosSalvos = key.GetValue(chave, "").ToString();
			string[] dadosArray = dadosSalvos.Split('|');

			foreach (string dado in dadosArray)
			{
				if (!string.IsNullOrWhiteSpace(dado) && !comboBox.Items.Contains(dado))
				{
					comboBox.Items.Add(dado.Trim());
				}
			}
			comboBox.Sorted = true;
		}

		private void OrdenarTabIndex()
		{
			comboBox1De.TabIndex = 1;
			comboBox2Para.TabIndex = 2;
			comboBox3Cc.TabIndex = 3;
			textBox1EmailAssunto.TabIndex = 4;
			richTextBox1Descricao.TabIndex = 5;
			btnPreviaEmail.TabIndex = 6;
			btnEnviar.TabIndex = 7;
			btnDeletar.TabIndex = 8;
		}

		void BtnConfiguracoesClick(object sender, EventArgs e)
		{
			CONFIG_ComunicacaoComCliente openAbrirGerenciamentoEConfiguracaoDeRegistros = new CONFIG_ComunicacaoComCliente();
			openAbrirGerenciamentoEConfiguracaoDeRegistros.ShowDialog();
			AtualizarListaClientes();
		}

		public void AtualizarListaClientes()
		{
			CarregarDadosCliente();
			// CarregarEmailsParaComboBoxPara(); // NÃO recarregar os e-mails para comboBox2Para aqui também
		}
		void BtnPreviaEmailClick(object sender, EventArgs e)
		{

		}
	}
}
