using Xunit;
using Application.ImportacaoResultado.LotoFacil;

namespace ApplicationTest.ImportacaoArquivo
{
    public class ImportacaoLotoFacilTeste
    {
        [Fact]
        public void ImportarArquivoTeste()
        {
            var importaLotoFacil = new ImportadorLotoFacil();

            var arquivo = importaLotoFacil.ImportarArquivo(null);
        }
    }
}
