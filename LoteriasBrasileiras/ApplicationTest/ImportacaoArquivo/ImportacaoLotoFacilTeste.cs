using Moq;
using Xunit;
using Domain.LotoFacil.Repository;
using Application.ImportacaoResultado.LotoFacil;

namespace ApplicationTest.ImportacaoArquivo
{
    public class ImportacaoLotoFacilTeste
    {
        [Fact]
        public void ImportarArquivoTeste()
        {
            var mockLotoFacilRepository = new Mock<ILotoFacilRepository>();

            var importaLotoFacil = new ImportadorLotoFacil(null, mockLotoFacilRepository.Object);

            var jogosIportados = importaLotoFacil.ImportarArquivo(0);

            Assert.Equal(1598, jogosIportados.Count);
        }
    }
}
