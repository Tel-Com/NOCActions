using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace NOC_Actions
{
	public partial class Uc_AnaliseDeInfra : UserControl
	{
		private readonly Class_Arquivos_Uc_AnaliseDeInfra arquivos;
		
		public Uc_AnaliseDeInfra()
		{
			InitializeComponent();
			arquivos = new Class_Arquivos_Uc_AnaliseDeInfra();
			CarregarInformacoes();
		}
		
		private void CarregarInformacoes()
		{
			comboBox_unidadeParaAnalise.Text = arquivos.Content_UcAnaliseDeInfra_operadora;
			comboBox_unidade.Text = arquivos.Content_UcAnaliseDeInfra_unidade;
			comboBox_tipoDeAnalise.Text = arquivos.Content_UcAnaliseDeInfra_tipoDeAnalise;
		}
		
		void BtnSalvarECopiarClick(object sender, EventArgs e)
		{
			string conteudo_operadora = comboBox_unidadeParaAnalise.Text;
			arquivos.SalvarOperadora(conteudo_operadora);
			
			string conteudo_unidade = comboBox_unidade.Text;
			arquivos.SalvarUnidade(conteudo_operadora);
			
			string conteudo_tipoDeAnalise = comboBox_tipoDeAnalise.Text;
			arquivos.SalvarTipoDeAnalise(conteudo_tipoDeAnalise);
		}
	}
}