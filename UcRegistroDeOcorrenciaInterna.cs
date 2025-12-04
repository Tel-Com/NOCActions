using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace NOC_Actions
{
	public partial class UcRegistroDeOcorrenciaInterna : UserControl
	{
		private readonly string arquivo_todas_as_informacoes = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "registroOcorrencias.txt");
		
		public UcRegistroDeOcorrenciaInterna()
		{
			InitializeComponent();
			listBox_RegistroDeOcorrencia.MouseDoubleClick += ListBox_RegistroDeOcorrencia_MouseDoubleClick;
			LoadContentList();
		}
		
		void BtnSaveAndCopyClick(object sender, EventArgs e)
		{
			string textContratoUnidade = textBox_UnidadeContrato.Text.Trim();
			string textOperadoraDoContratoUnidade = textBox_OperadoraDaUnidade.Text.Trim();
			string textObservacaoContratoUnidade = textBox_observacaoDoContrato.Text.Trim();

			string itemList =
				"> Unidade: " + textContratoUnidade +
				" | Operadora: " + textOperadoraDoContratoUnidade +
				" | Observação: " + textObservacaoContratoUnidade;
			
			listBox_RegistroDeOcorrencia.Items.Add(
				itemList
			);

			string linhaArquivo =
				textContratoUnidade + "|" +
				textOperadoraDoContratoUnidade + "|" +
				textObservacaoContratoUnidade;
			
			File.AppendAllText(arquivo_todas_as_informacoes, linhaArquivo + Environment.NewLine);
		}
		
		void SelectedIndexOnListBoxToShowInformation(string message)
		{
			MessageBox.Show(message);
		}
		
		void ListBox_RegistroDeOcorrencia_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			
			if (listBox_RegistroDeOcorrencia.SelectedItem != null)
			{
				SelectedIndexOnListBoxToShowInformation(listBox_RegistroDeOcorrencia.SelectedItem.ToString());
			}
		}
		
		void LoadContentList()
		{
			if (File.Exists(arquivo_todas_as_informacoes))
			{
				foreach (var linha in File.ReadAllLines(arquivo_todas_as_informacoes))
				{
					var partes = linha.Split('|');
					if (partes.Length == 3)
					{
						string unidade = partes[0];
						string operadora = partes[1];
						string observacao = partes[2];

						listBox_RegistroDeOcorrencia.Items.Add(
							"> Contrato/unidade: " + unidade +
							" | Operadora: " + operadora +
							" | Observação: " + observacao
						);

					}
				}
			}
		}
	}
}