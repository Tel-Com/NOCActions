using System;
using System.Linq;
using System.IO;

namespace NOC_Actions
{
	public class Class_Arquivos_Uc_AnaliseDeInfra
	{
//		Uc_AnaliseDeInfra
		private readonly string arquivo_analiseDeInfra_operadora = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "analiseDeInfraOperadora.txt");
		private readonly string arquivo_analiseDeInfra_unidade = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "analiseDeInfraUnidade.txt");
		private readonly string arquivo_analiseDeInfra_tipoDeAnalise = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "analiseDeInfraTipoDeAnalise.txt");
		
		public string Content_UcAnaliseDeInfra_operadora { get; private set; }
		public string Content_UcAnaliseDeInfra_unidade { get; private set; }
		public string Content_UcAnaliseDeInfra_tipoDeAnalise { get; private set; }
		
		public Class_Arquivos_Uc_AnaliseDeInfra()
		{
			GerarArquivosNaoExistentes();
			CarregarConteudos();
		}
		
		void GerarArquivosNaoExistentes()
		{
			if (!File.Exists(arquivo_analiseDeInfra_operadora))
				File.Create(arquivo_analiseDeInfra_operadora);
			
			if (!File.Exists(arquivo_analiseDeInfra_unidade))
				File.Create(arquivo_analiseDeInfra_unidade);
			
			if (!File.Exists(arquivo_analiseDeInfra_tipoDeAnalise))
				File.Create(arquivo_analiseDeInfra_tipoDeAnalise);
		}
		
		void CarregarConteudos()
		{
			Content_UcAnaliseDeInfra_operadora =
				File.ReadAllText(arquivo_analiseDeInfra_operadora);
			
			Content_UcAnaliseDeInfra_unidade =
				File.ReadAllText(arquivo_analiseDeInfra_unidade);
			
			Content_UcAnaliseDeInfra_tipoDeAnalise =
				File.ReadAllText(arquivo_analiseDeInfra_tipoDeAnalise);
		}
		
		public void SalvarOperadora(string conteudo)
		{
			File.WriteAllText(arquivo_analiseDeInfra_operadora,conteudo);
			Content_UcAnaliseDeInfra_operadora = conteudo;
		}
		
		public void SalvarUnidade(string conteudo)
		{
			File.WriteAllText(arquivo_analiseDeInfra_unidade, conteudo);
			Content_UcAnaliseDeInfra_unidade = conteudo;
		}
		
		public void SalvarTipoDeAnalise(string conteudo)
		{
			File.WriteAllText( arquivo_analiseDeInfra_tipoDeAnalise, conteudo);
			Content_UcAnaliseDeInfra_tipoDeAnalise = conteudo;
		}
		
		
		public string[] ObterOperadoras()
		{
			if (!File.Exists(arquivo_analiseDeInfra_operadora))
				return Array.Empty<string>();

			return File.ReadAllLines(arquivo_analiseDeInfra_operadora);
		}

		public string ObterUltimaOperadora()
		{
			var linhas = ObterOperadoras();
			return linhas.Length > 0 ? linhas[linhas.Length - 1] : string.Empty;
		}

		public void SalvarOperadoraComoLista(string operadora)
		{
			var linhas = ObterOperadoras().ToList();

			if (!linhas.Contains(operadora))
				linhas.Add(operadora);

			File.WriteAllLines(arquivo_analiseDeInfra_operadora, linhas);

			Content_UcAnaliseDeInfra_operadora = operadora;
		}
	}
}