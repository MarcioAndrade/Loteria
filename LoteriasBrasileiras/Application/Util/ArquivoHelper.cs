using System;
using System.IO;
using System.Net;
using System.Linq;
using System.IO.Compression;
using System.Collections.Generic;

namespace Application.Util
{
    public class ArquivoHelper
    {
        public static string UnzipArquivo(string pathArquivoZip, string arquivoZip, string arquivo)
        {
            try
            {
                ZipFile.ExtractToDirectory(pathArquivoZip + arquivoZip, pathArquivoZip, true);

                var arquivos = Directory.EnumerateFiles(pathArquivoZip, arquivo, SearchOption.AllDirectories);
                return arquivos.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void BaixarUltimoResultadoCEF(string urlDownload, string arquivo, string pathArquivo)
        {
            try
            {
                var myContainer = new CookieContainer();
                var request = (HttpWebRequest)WebRequest.Create(urlDownload + arquivo);
                request.MaximumAutomaticRedirections = 1;
                request.AllowAutoRedirect = true;
                request.CookieContainer = myContainer;
                var response = (HttpWebResponse)request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    using (var fileStream = new FileStream(Path.Combine(pathArquivo, arquivo), FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<List<string>> ExtrairInformacoesArquivo(string pathArquivo, int informacoesPorLinha)
        {
            var informacoes = new List<List<string>>();
            var sorteio = new List<string>();

            using (var arquivo = new StreamReader(pathArquivo))
            {
                string linha;

                while ((linha = arquivo.ReadLine()) != null)
                {
                    if (linha.StartsWith("<tr"))
                    {
                        linha = arquivo.ReadLine();
                        sorteio = new List<string>();
                        while ((linha = arquivo.ReadLine()) != null && linha != "</tr>" && !linha.StartsWith("<th"))
                        {
                            if (linha.StartsWith("<td "))
                            {
                                linha = linha.
                                    Replace("<td rowspan=\"", "").
                                    Replace("</td>", "").
                                    Replace(">", "");
                                linha = linha.Split("\"")[1];

                                if (linha != "&nbsp1")
                                    sorteio.Add(linha);
                            }
                        }

                        if (sorteio.Any() && sorteio.Count == informacoesPorLinha)
                            informacoes.Add(sorteio);
                    }
                }
            }
            return informacoes;
        }
    }
}
