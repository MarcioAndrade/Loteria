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

            var jogosIportados = importaLotoFacil.ImportarArquivo(0);
        }
    }
}
