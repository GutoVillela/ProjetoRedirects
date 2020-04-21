using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Redirects
{
    public partial class Form1 : Form
    {
        #region Construtor
        public Form1()
        {
            InitializeComponent();
            this._cancelarProcessamento = new CancellationTokenSource();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Caminho do Sitemap Antigo no Computador do Usuário
        /// </summary>
        private string _caminhoSitemapAntigo;

        /// <summary>
        /// Caminho do Sitemap Atual no Computador do Usuário
        /// </summary>
        private string _caminhoSitemapAtual;

        /// <summary>
        /// Token de Cancelamento responsável pelo cancelamento da tarefa caso o usuário clique no botão Cancelar
        /// </summary>
        private CancellationTokenSource _cancelarProcessamento;

        /// <summary>
        /// Indica qual função o botão de processamento adotará ao ser clicado pelo usuário (acesse esta informação somente pela propriedade FuncaoBotaoProcessamento, NUNCA diretamente por este atributo)
        /// </summary>
        private BotaoProcessamento _funcaoBotaoProcessamento;
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade que indica a função atual do botão de processamento na tela
        /// </summary>
        private BotaoProcessamento FuncaoBotaoProcessamento
        {
            get
            {
                return _funcaoBotaoProcessamento;
            }

            set
            {
                FormatarBotaoDeProcessamento(value);
                _funcaoBotaoProcessamento = value;
            }
        }
        #endregion

        #region Eventos
        private void btnBuscarSitemapAntigo_Click(object sender, EventArgs e)
        {
            if (openFileDialogSitemap.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(_caminhoSitemapAtual))
                {
                    if (_caminhoSitemapAtual == openFileDialogSitemap.FileName)
                    {
                        MessageBox.Show("Não é possível comparar o mesmo arquivo! Escolha arquivos diferentes para continuar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                _caminhoSitemapAntigo = openFileDialogSitemap.FileName;
                string nomeDoArquivo = openFileDialogSitemap.FileName.Substring(openFileDialogSitemap.FileName.LastIndexOf("\\")).Replace("\\", "");
                lblSitemapUrlAntigo.Text = nomeDoArquivo;
            }
        }

        private void btnBuscarSitemapAtual_Click(object sender, EventArgs e)
        {
            if (openFileDialogSitemap.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(_caminhoSitemapAntigo))
                {
                    if (_caminhoSitemapAntigo == openFileDialogSitemap.FileName)
                    {
                        MessageBox.Show("Não é possível comparar o mesmo arquivo! Escolha arquivos diferentes para continuar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                _caminhoSitemapAtual = openFileDialogSitemap.FileName;
                string nomeDoArquivo = openFileDialogSitemap.FileName.Substring(openFileDialogSitemap.FileName.LastIndexOf("\\")).Replace("\\", "");
                lblSitemapUrlAtual.Text = nomeDoArquivo;
            }
        }

        private async void btnGerarRedirects_Click(object sender, EventArgs e)
        {
            if(FuncaoBotaoProcessamento == BotaoProcessamento.IniciarProcessamento)
            {
                if (string.IsNullOrEmpty(_caminhoSitemapAntigo) || string.IsNullOrEmpty(_caminhoSitemapAtual))
                {
                    MessageBox.Show("Defina os dois arquivos de sitemap para continuar!", "Operação não pôde continuar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mudar função deste botão para Cancelar
                FuncaoBotaoProcessamento = BotaoProcessamento.CancelarProcessamento;

                //Acompanhar progresso da tarefa
                Progress<ProgressoDaTarefa> progressoDaTarefa = new Progress<ProgressoDaTarefa>();
                progressoDaTarefa.ProgressChanged += ProgressoDaTarefa_ProgressChanged;
                var assitirProgresso = System.Diagnostics.Stopwatch.StartNew();

                try
                {
                    //Iniciar processamento da Tarefa
                    await IniciarProcessamentoAsync(progressoDaTarefa, _cancelarProcessamento.Token);
                }
                catch (OperationCanceledException)
                {
                    this.UseWaitCursor = false;
                    _cancelarProcessamento = new CancellationTokenSource();
                    pgbProgresso.Value = 0;
                    lblEtapaAtual.Text = "Operação Cancelada pelo Usuário!";
                    lblEtapaAtual.BackColor = Color.LightPink;
                    FuncaoBotaoProcessamento = BotaoProcessamento.IniciarProcessamento;
                }
                catch (Exception erro)
                {
                    this.UseWaitCursor = false;
                    MessageBox.Show("Aconteceu um erro: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pgbProgresso.Value = 0;
                    lblEtapaAtual.Text = "Aconteceu um erro! Tente novamente";
                    lblEtapaAtual.BackColor = Color.LightPink;
                    FuncaoBotaoProcessamento = BotaoProcessamento.IniciarProcessamento;
                }

                assitirProgresso.Stop();
            }
            else if(FuncaoBotaoProcessamento == BotaoProcessamento.CancelarProcessamento)
            {
                _cancelarProcessamento.Cancel();
            }
        }

        private void ProgressoDaTarefa_ProgressChanged(object sender, ProgressoDaTarefa e)
        {
            pgbProgresso.Value = e.Progresso;
            lblEtapaAtual.Text = e.EtapaAtual;

            if(e.Progresso < 100)
            {
                this.UseWaitCursor = true;
                FuncaoBotaoProcessamento = BotaoProcessamento.CancelarProcessamento;
                lblEtapaAtual.BackColor = Color.LightGray;
            }
            else
            {
                this.UseWaitCursor = false;
                FuncaoBotaoProcessamento = BotaoProcessamento.IniciarProcessamento;
                lblEtapaAtual.BackColor = Color.LightGreen;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que inicia processamento do 
        /// </summary>
        /// <returns></returns>
        private async Task IniciarProcessamentoAsync(IProgress<ProgressoDaTarefa> pProgresso, CancellationToken pCancelarTarefa)
        {
            ProgressoDaTarefa reportarProgresso = new ProgressoDaTarefa();
            List<Redirect> redirects = new List<Redirect>();

            //Lendo arquivos XML e recuperando URLs
            reportarProgresso.Progresso = 10;
            reportarProgresso.EtapaAtual = "Lendo arquivos XML...";
            pProgresso.Report(reportarProgresso);
            List<string> urlsSitemapAntigo = await GerarListaDeUrlsAsync(_caminhoSitemapAntigo, chkRemoverSubdominio.Checked, pCancelarTarefa);
            List<string> urlsSitemapAtual = await GerarListaDeUrlsAsync(_caminhoSitemapAtual, chkRemoverSubdominio.Checked, pCancelarTarefa);

            //Removendo ocorrências idênticas entre URLs do site atual e site antigo
            reportarProgresso.Progresso = 20;
            reportarProgresso.EtapaAtual = "Removendo ocorrências idênticas...";
            pProgresso.Report(reportarProgresso);
            urlsSitemapAntigo = urlsSitemapAntigo.Except(urlsSitemapAtual).ToList();


            //Buscando semelhanças
            reportarProgresso.Progresso = 30;
            reportarProgresso.EtapaAtual = "Gerando Redirects...";
            pProgresso.Report(reportarProgresso);
            int qtdRedirectsFeitos = await Task.Run(() => GerarRedirects(urlsSitemapAntigo, urlsSitemapAtual, out redirects, pCancelarTarefa));
            MessageBox.Show("Redirects feitos: " + qtdRedirectsFeitos);


            //Salvando arquivo com redirects
            reportarProgresso.Progresso = 90;
            reportarProgresso.EtapaAtual = "Salvando arquivo...";
            pProgresso.Report(reportarProgresso);
            await EscreverArquivoAsync(redirects);

            //Finalizando operação
            reportarProgresso.Progresso = 100;
            reportarProgresso.EtapaAtual = "Redirects gerados com sucesso";
            pProgresso.Report(reportarProgresso);
        }

        /// <summary>
        /// Lê um arquivo XML de Sitemap e retorna uma lista com os URLs encontrados
        /// </summary>
        /// <param name="pCaminhoSitemap">Caminho do Sitemap no Computador do Usuário</param>
        /// <param name="pRemoverSubdominio">Define se o subdomínio será removido das URLs</param>
        /// <param name="pCancelarTarefa">Token de Cancelamento que indica quando a tarefa deve ser abortada</param>
        /// <returns>Lista de string com URLs encontradas no Sitemap</returns>
        private async Task<List<string>> GerarListaDeUrlsAsync(string pCaminhoSitemap, bool pRemoverSubdominio, CancellationToken pCancelarTarefa)
        {
            List<string> listaDeUrls = new List<string>();

            //Exemplo de ocorrência de URL no sitemap: <loc>https://site.com.br/</loc>
            Regex expressaoRegular = new Regex(@"\<loc\>(?<url>[\s\S]*?)\</loc\>");

            try
            {
                using (StreamReader leitorDoArquivo = new StreamReader(pCaminhoSitemap))
                {
                    string conteudoDoArquivo = await leitorDoArquivo.ReadToEndAsync();
                    MatchCollection ocorrencias = expressaoRegular.Matches(conteudoDoArquivo);

                    foreach (Match ocorrencia in ocorrencias)
                    {
                        // Cancelar tarefa assim que solicitado pelo usuário
                        pCancelarTarefa.ThrowIfCancellationRequested();

                        string url = ocorrencia.Groups["url"].ToString();

                        if (pRemoverSubdominio)
                            url = url.Replace(".cintracomunicacao", "");

                        listaDeUrls.Add(url);
                    }
                }

                return listaDeUrls;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        /// <summary>
        /// Gerar redirects com base nas listas de URLs fornecidas
        /// </summary>
        /// <param name="pUrlsSitemapAntigo">Lista de URLs do Sitemap antigo</param>
        /// <param name="pUrlsSitemapAtual">Lista de URLs do Sitemap atual</param>
        /// <param name="pRedirects">Lista de Redirects para ser preenchido</param>
        /// <param name="pCancelarTarefa">Token de Cancelamento que indica quando a tarefa deve ser abortada</param>
        /// <returns>Retorna quantidade de Redirects</returns>
        private int GerarRedirects(List<string> pUrlsSitemapAntigo, List<string> pUrlsSitemapAtual, out List<Redirect> pRedirects, CancellationToken pCancelarTarefa)
        {
            List<Redirect> redirects = new List<Redirect>();

            #region Buscando URLs com final idêntico
            foreach (string urlAntiga in pUrlsSitemapAntigo)
            {
                // Cancelar tarefa assim que solicitado pelo usuário
                pCancelarTarefa.ThrowIfCancellationRequested();

                string urlAntigaFormatada = urlAntiga;

                //Se o último caractere da URL for uma barra, ela deve ser subtraída
                if (urlAntigaFormatada.Last().Equals('/'))
                {
                    urlAntigaFormatada = urlAntigaFormatada.Remove(urlAntigaFormatada.Length - 1);
                }

                urlAntigaFormatada = urlAntigaFormatada.Substring(urlAntigaFormatada.LastIndexOf("/"));

                foreach (string urlNova in pUrlsSitemapAtual)
                {
                    string urlNovaFormatada = urlNova;

                    //Se o último caractere da URL for uma barra, ela deve ser subtraída
                    if (urlNovaFormatada.Last().Equals('/'))
                    {
                        urlNovaFormatada = urlNovaFormatada.Remove(urlNovaFormatada.Length - 1);
                    }

                    urlNovaFormatada = urlNovaFormatada.Substring(urlNovaFormatada.LastIndexOf("/"));

                    if (urlAntigaFormatada.Contains(urlNovaFormatada))
                    {
                        redirects.Add(new Redirect()
                        {
                            De = urlAntiga,
                            Para = urlNova
                        });
                        break;
                    }
                    else
                    {
                        redirects.Add(new Redirect()
                        {
                            De = urlAntiga,
                            Para = BuscarUrlMaisSimilar(urlAntiga, pUrlsSitemapAtual)
                        });
                        break;
                    }
                }

            }
            #endregion

            pRedirects = redirects;
            return redirects.Count;
        }

        /// <summary>
        /// Busca a ocorrência mais similar de uma URL dentro de uma lista de URLs
        /// </summary>
        /// <param name="pUrl1">URL para ser comparada</param>
        /// <param name="pListaDeUrls">Lista de URLs aonde será efetuada a busca de similaridade</param>
        /// <returns>Retorna a URL mais similar encontrada na lista de URLs fornecida</returns>
        private string BuscarUrlMaisSimilar(string pUrl1, List<string> pListaDeUrls)
        {
            double maiorSimilaridade = 0;
            string urlMaisSimilar = string.Empty;

            foreach (string url in pListaDeUrls)
            {
                double similaridadeAtual = VerificarSimilaridade(pUrl1, url);
                if (similaridadeAtual > maiorSimilaridade)
                {
                    maiorSimilaridade = similaridadeAtual;
                    urlMaisSimilar = url;
                }
            }

            return urlMaisSimilar;
        }

        /// <summary>
        /// Verifica o quão parecidos são dois textos e retorna uma porcentagem de similaridade
        /// </summary>
        /// <param name="pTexto1">String com texto 1</param>
        /// <param name="pTexto2">String com texto 2</param>
        /// <returns>Retorna porcentagem de similaridade (entre 0 e 1) aonde 0 significa que os textos não se parecem e 1 representa que os textos são idênticos</returns>
        private double VerificarSimilaridade(string pTexto1, string pTexto2)
        {
            List<string> pares1 = ObterParesDeLetras(pTexto1.ToUpper());
            List<string> pares2 = ObterParesDeLetras(pTexto2.ToUpper());

            int intersecao = 0;
            int uniao = pares1.Count + pares2.Count;

            for (int i = 0; i < pares1.Count; i++)
            {
                for (int j = 0; j < pares2.Count; j++)
                {
                    if (pares1[i] == pares2[j])
                    {
                        intersecao++;
                        pares2.RemoveAt(j);//Must remove the match to prevent "GGGG" from appearing to match "GG" with 100% success

                        break;
                    }
                }
            }

            return (2.0 * intersecao) / uniao;
        }

        /// <summary>
        /// Obtém todos os pares de letras de um texto
        /// </summary>
        /// <param name="pTexto">Texto do qual se deseja obter os pares de letras</param>
        /// <returns>Retorna uma lista com todos os pares de letras obtidos</returns>
        private List<string> ObterParesDeLetras(string pTexto)
        {
            List<string> paresDeLetras = new List<string>();

            // Dividir texto em palavras
            string[] palavras = Regex.Split(pTexto, @"\s");

            // Percorrer todas as palavras
            for (int i = 0; i < palavras.Length; i++)
            {
                if (!string.IsNullOrEmpty(palavras[i]))
                {
                    // Buscar todos os pares de letras da palavra
                    String[] paresNaPalavra = ParesDeLetras(palavras[i]);

                    for (int j = 0; j < paresNaPalavra.Length; j++)
                    {
                        paresDeLetras.Add(paresNaPalavra[j]);
                    }
                }
            }

            return paresDeLetras;
        }

        /// <summary>
        /// Busca todos os pares de letras (ocorrência de cada duas letras consecutivas)
        /// em uma palavra
        /// </summary>
        /// <param name="pPalavra">Palavra do qual se deseja obter os pares de letras</param>
        /// <returns>Retorna um vetor de string com todos os pares de letras encontrados na palavra</returns>
        private string[] ParesDeLetras(string pPalavra)
        {
            int numPares = pPalavra.Length - 1;

            string[] paresDeLetras = new string[numPares];

            for (int i = 0; i < numPares; i++)
            {
                paresDeLetras[i] = pPalavra.Substring(i, 2);
            }

            return paresDeLetras;
        }

        /// <summary>
        /// Escreve um arquivo com todos os redirects gerados
        /// </summary>
        /// <param name="pListaDeRedirects">Lista de redirects gerados</param>
        /// <returns></returns>
        private async Task EscreverArquivoAsync(List<Redirect> pListaDeRedirects)
        {
            string caminhoArquivo = "C:\\Redirects.txt";

            if (saveFileDialogSitemap.ShowDialog() == DialogResult.OK)
            {
                caminhoArquivo = saveFileDialogSitemap.FileName;
            }

            using (StreamWriter escritorDeArquivo = File.CreateText(caminhoArquivo))
            {
                foreach (Redirect redirect in pListaDeRedirects)
                {
                    await escritorDeArquivo.WriteLineAsync(redirect.De + "\t" + redirect.Para);
                }
            }
        }

        /// <summary>
        /// Formata a aparência do botão de processamento para assumir a função de Iniciar ou Cancelar o processamento
        /// </summary>
        /// <param name="pFuncaoBotao"></param>
        private void FormatarBotaoDeProcessamento(BotaoProcessamento pFuncaoBotao)
        {
            if(pFuncaoBotao == BotaoProcessamento.IniciarProcessamento)
            {
                btnGerarRedirects.BackColor = SystemColors.Highlight;
                btnGerarRedirects.Text = "Gerar Redirects";
                btnGerarRedirects.Image = Properties.Resources.icone_gerar_redirect;
            }
            else if(pFuncaoBotao == BotaoProcessamento.CancelarProcessamento)
            {
                btnGerarRedirects.BackColor = Color.Firebrick;
                btnGerarRedirects.Text = "Cancelar";
                btnGerarRedirects.Image = Properties.Resources.icone_cancelar;
            }
        }
        #endregion

        /// <summary>
        /// Enum que define se o botão de processamento adotará a função de Iniciar ou Cancelar o processamento
        /// </summary>
        private enum BotaoProcessamento
        {
            IniciarProcessamento,

            CancelarProcessamento
        }
    }
}
