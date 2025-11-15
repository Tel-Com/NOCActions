using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace NOC_Actions
{
	public partial class Config_UcDetalharFaturaDoCliente : UserControl
	{
		private string caminhoArquivoOperadora = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "operadora.txt");
		private string caminhoArquivoStatus = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "statusDoCaso.txt");
		
		public Config_UcDetalharFaturaDoCliente()
		{
			InitializeComponent();
			CarregarOperadoraSalva();
		}
		void BtnSalvarOperadoraClick(object sender, EventArgs e)
		{
			SalvarItensNoArquivo_Operadora();
		}
		
		private void SalvarItensNoArquivo_Operadora()
		{
			
			string adicionarOperadoraEmLista = comboBox_TipoDeOperadoraComPendencia.Text.Trim();
			
			if(!string.IsNullOrWhiteSpace(adicionarOperadoraEmLista) && !comboBox_TipoDeOperadoraComPendencia.Items.Contains(adicionarOperadoraEmLista) )
			{
				comboBox_TipoDeOperadoraComPendencia.Items.Add(adicionarOperadoraEmLista);
				comboBox_TipoDeOperadoraComPendencia.Text = "";
				RegistrarNoArquivo();
				
			} else
			{
				MessageBox.Show("Essa operadora já foi adicionada ou o campo está vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void RegistrarNoArquivo()
		{
			try
			{
				File.WriteAllLines(caminhoArquivoOperadora, comboBox_TipoDeOperadoraComPendencia.Items.Cast<string>());
				
			} catch (Exception ex)
			{
				MessageBox.Show(string.Format("Erro ao salvar os dados: {0}", ex.Message), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		private void CarregarOperadoraSalva()
		{
			
			if (File.Exists(caminhoArquivoOperadora))
			{
				string[] operadora =  File.ReadAllLines(caminhoArquivoOperadora);
				comboBox_TipoDeOperadoraComPendencia.Items.AddRange(operadora);
			}
		}
	}
}