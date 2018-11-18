using System;
using System.IO;
using System.Net;
using System.Linq;
using System.IO.Compression;

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
    }
}
