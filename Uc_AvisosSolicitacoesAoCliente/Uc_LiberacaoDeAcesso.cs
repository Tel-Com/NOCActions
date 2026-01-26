using NOC_Actions.Uc_AvisosSolicitacoesAoCliente;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NOC_Actions
{
    /// <summary>
    /// UserControl responsável pela solicitação de liberação de acesso
    /// para visitas técnicas, incluindo persistência de dados,
    /// geração de mensagem e gerenciamento dos registros salvos.
    /// </summary>
    public partial class Uc_LiberacaoDeAcesso : UserControl
    {
        #region Constantes / Arquivos

        /// <summary>
        /// Caminho base da pasta AppData do usuário.
        /// </summary>
        private static readonly string AppDataPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// Mapeamento entre ComboBox e seus respectivos arquivos de persistência.
        /// </summary>
        private readonly Dictionary<ComboBox, string> _persistencias;

        #endregion

        #region Construtor

        /// <summary>
        /// Inicializa o UserControl, configura persistências
        /// e carrega os dados salvos previamente.
        /// </summary>
        public Uc_LiberacaoDeAcesso()
        {
            InitializeComponent();
            InicializarPersistencias();
            CarregarDadosIniciais();

            btnAmplicarTexto.Click += btnAmplicarTexto_Click;
        }

        #endregion

        #region Inicialização

        /// <summary>
        /// Define os arquivos de persistência associados
        /// a cada ComboBox do formulário.
        /// </summary>
        private void InicializarPersistencias()
        {
            _persistencias = new Dictionary<ComboBox, string>
            {
                { comboBox_operadoraResponsavel, CriarCaminho("operadoraSolicitacaoVisita.txt") },
                { comboBox_previaoDeChegada, CriarCaminho("previsaoDeChegadaTecnica.txt") },
                { comboBox_unidadeParaLiberacaoDeAcesso, CriarCaminho("unidadeRespectivaParaVisita.txt") },
                { comboBox_enderecoDaUnidadeResponsavel, CriarCaminho("unidadeEnderecoParaVisitaTecnica.txt") }
            };
        }

        /// <summary>
        /// Cria o caminho completo do arquivo dentro do AppData.
        /// </summary>
        /// <param name="nomeArquivo">Nome do arquivo a ser criado.</param>
        /// <returns>Caminho completo do arquivo.</returns>
        private static string CriarCaminho(string nomeArquivo) =>
            Path.Combine(AppDataPath, nomeArquivo);

        /// <summary>
        /// Carrega os dados persistidos em disco
        /// para os respectivos ComboBox.
        /// </summary>
        private void CarregarDadosIniciais()
        {
            foreach (var item in _persistencias)
                CarregarItens(item.Value, item.Key);
        }

        #endregion

        #region Persistência

        /// <summary>
        /// Salva um novo item digitado no ComboBox
        /// e persiste os dados no arquivo correspondente.
        /// </summary>
        private static void SalvarItem(ComboBox comboBox, string caminhoArquivo)
        {
            var valor = comboBox.Text?.Trim();

            if (string.IsNullOrWhiteSpace(valor) || comboBox.Items.Contains(valor))
                return;

            comboBox.Items.Add(valor);
            File.WriteAllLines(caminhoArquivo, comboBox.Items.Cast<string>());
        }

        /// <summary>
        /// Carrega os itens de um arquivo para um ComboBox,
        /// removendo duplicidades e valores vazios.
        /// </summary>
        private static void CarregarItens(string caminhoArquivo, ComboBox comboBox)
        {
            if (!File.Exists(caminhoArquivo))
                return;

            comboBox.Items.Clear();
            comboBox.Items.AddRange(
                File.ReadAllLines(caminhoArquivo)
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .Distinct()
                    .ToArray()
            );
        }

        #endregion

        #region Botões Principais

        /// <summary>
        /// Salva os dados preenchidos, gera a mensagem
        /// e copia o conteúdo para a área de transferência.
        /// </summary>
        private void btnSalvarECopiar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            foreach (var item in _persistencias)
                SalvarItem(item.Key, item.Value);

            Clipboard.SetText(GerarMensagem());

            MostrarMensagem("Itens salvos e mensagem copiada para a área de transferência.");
            LimparCampos();
        }

        /// <summary>
        /// Gera a mensagem e exibe no RichTextBox.
        /// </summary>
        private void btnGerarAlerta_Click(object sender, EventArgs e)
        {
            richTextBox_mensagemASerEncaminhadaAoCliente.Text = GerarMensagem();
        }

        #endregion

        #region Validação

        /// <summary>
        /// Valida se todos os campos obrigatórios
        /// foram preenchidos corretamente.
        /// </summary>
        private bool ValidarCampos()
        {
            foreach (var comboBox in _persistencias.Keys)
            {
                if (string.IsNullOrWhiteSpace(comboBox.Text))
                {
                    MostrarMensagem(
                        "Preencha todos os campos antes de continuar.",
                        MessageBoxIcon.Warning
                    );
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Mensagem

        /// <summary>
        /// Gera a mensagem final a ser enviada ao cliente
        /// com base nos dados preenchidos.
        /// </summary>
        private string GerarMensagem()
        {
            string equipeTecnica = string.IsNullOrWhiteSpace(textBox_nomeEquipeTecnica.Text) &&
                                   string.IsNullOrWhiteSpace(textBox_credenciaisDePessoaFisica.Text)
                ? string.Empty
                : $"Equipe técnica: {textBox_nomeEquipeTecnica.Text} | {textBox_credenciaisDePessoaFisica.Text}\n";

            return
                $"Prezados, {ObterSaudacao()}.\n\n" +
                $"Faço parte do NOC da Tel&Com e solicito liberação de acesso para visita técnica.\n\n" +
                $"Operadora responsável: {comboBox_operadoraResponsavel.Text}\n" +
                $"Unidade: {comboBox_unidadeParaLiberacaoDeAcesso.Text}\n" +
                $"Endereço: {comboBox_enderecoDaUnidadeResponsavel.Text}\n" +
                equipeTecnica +
                $"Previsão de chegada: {comboBox_previaoDeChegada.Text}\n\n" +
                $"Atenciosamente,\nNOC - Tel&Com";
        }

        /// <summary>
        /// Retorna a saudação adequada conforme o horário atual.
        /// </summary>
        private static string ObterSaudacao()
        {
            int hora = DateTime.Now.Hour;
            return hora < 12 ? "bom dia" : hora < 18 ? "boa tarde" : "boa noite";
        }

        #endregion

        #region Exclusão

        /// <summary>
        /// Exclui os itens selecionados dos ComboBox
        /// e de seus respectivos arquivos.
        /// </summary>
        private void bntExcluirSelecionado_Click(object sender, EventArgs e)
        {
            bool excluiu = false;

            foreach (var item in _persistencias)
                excluiu |= ExcluirSelecionado(item.Key, item.Value);

            MostrarMensagem(
                excluiu
                    ? "Item(ns) selecionado(s) excluído(s) com sucesso."
                    : "Selecione ao menos um item válido para exclusão.",
                excluiu ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );
        }

        /// <summary>
        /// Remove todos os itens persistidos
        /// após confirmação do usuário.
        /// </summary>
        private void btnExcluirTodosOsCampos_Click(object sender, EventArgs e)
        {
            if (!ConfirmarAcao(
                "Tem certeza que deseja excluir TODOS os itens?\n\nEssa ação não poderá ser desfeita."))
                return;

            bool excluiu = false;

            foreach (var item in _persistencias)
                excluiu |= LimparComboBoxEArquivo(item.Key, item.Value);

            MostrarMensagem(
                excluiu
                    ? "Todos os itens foram excluídos com sucesso."
                    : "Não havia itens cadastrados para exclusão.",
                excluiu ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );
        }

        /// <summary>
        /// Exclui o item selecionado de um ComboBox
        /// e do arquivo associado.
        /// </summary>
        private static bool ExcluirSelecionado(ComboBox comboBox, string caminhoArquivo)
        {
            var valor = comboBox.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(valor) || !File.Exists(caminhoArquivo))
                return false;

            var linhas = File.ReadAllLines(caminhoArquivo).ToList();
            if (!linhas.Remove(valor))
                return false;

            File.WriteAllLines(caminhoArquivo, linhas);
            comboBox.Items.Remove(valor);
            comboBox.Text = "";

            return true;
        }

        /// <summary>
        /// Remove todos os itens do ComboBox
        /// e exclui o arquivo correspondente.
        /// </summary>
        private static bool LimparComboBoxEArquivo(ComboBox comboBox, string caminhoArquivo)
        {
            if (comboBox.Items.Count == 0 && !File.Exists(caminhoArquivo))
                return false;

            comboBox.Items.Clear();
            comboBox.Text = "";

            if (File.Exists(caminhoArquivo))
                File.Delete(caminhoArquivo);

            return true;
        }

        #endregion

        #region Utilidades

        /// <summary>
        /// Limpa todos os campos do formulário.
        /// </summary>
        private void LimparCampos()
        {
            textBox_nomeEquipeTecnica.Clear();
            textBox_credenciaisDePessoaFisica.Clear();
            richTextBox_mensagemASerEncaminhadaAoCliente.Clear();

            foreach (var comboBox in _persistencias.Keys)
                comboBox.Text = "";
        }

        /// <summary>
        /// Abre a janela de ampliação da mensagem gerada.
        /// </summary>
        private void btnAmplicarTexto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox_mensagemASerEncaminhadaAoCliente.Text))
                return;

            new AmpliarMensagemDeTexto_LiberacaoDeAcesso(
                richTextBox_mensagemASerEncaminhadaAoCliente.Text
            ).ShowDialog();
        }

        /// <summary>
        /// Exibe uma mensagem padrão para o usuário.
        /// </summary>
        private static void MostrarMensagem(string texto, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(texto, "NOC - Tel&Com", MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Solicita confirmação do usuário antes de executar ações críticas.
        /// </summary>
        private static bool ConfirmarAcao(string texto)
        {
            return MessageBox.Show(
                texto,
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ) == DialogResult.Yes;
        }

        #endregion

        #region Close

        /// <summary>
        /// Fecha o formulário pai do UserControl.
        /// </summary>
        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            FindForm()?.Close();
        }

        #endregion
    }
}
