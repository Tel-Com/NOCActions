using System;
using System.Windows.Forms;
using NOC_Actions;
using System.Linq;
using System.IO;

namespace NOC_Actions
{
	public partial class UcRegistroDeOcorrenciaInterna : UserControl
	{
		private readonly string arquivo_unidadeSemNecessidadeDeRegistroTecnico = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "unidadeSemNecessidadeDeRegistroTecnico.txt");
		
		private readonly string arquivo_operadoraDaUnidade = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "operadoraDaUnidade.txt");
		
		public UcRegistroDeOcorrenciaInterna()
		{
			InitializeComponent();
		}
		
		void BtnSaveAndCopyClick(object sender, EventArgs e)
		{
			string texto = textBox_UnidadeContrato.Text.Trim();
			string texto2 = textBox_OperadoraDaUnidade.Text.Trim();
			listBox_RegistroDeOcorrencia.Items.Add("Contrato/unidade: " +texto+ " Operadora: " +texto2);
		}
		
		
		
		
		
	}
}