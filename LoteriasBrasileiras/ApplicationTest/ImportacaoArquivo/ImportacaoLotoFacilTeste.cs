using Moq;
using Xunit;
using Domain.LotoFacil.Repository;
using Application.ImportacaoResultado.LotoFacil;

namespace ApplicationTest.ImportacaoArquivo
{
    public class ImportacaoLotoFacilTeste
    {
        [Fact(Skip = "Acertar o teste que este possa trabalhar com arquivo mockado")]
                public void ImportarArquivoTeste()
        {
            var mockLotoFacilRepository = new Mock<ILotoFacilRepository>();

            var importaLotoFacil = new ImportadorLotoFacil(null, mockLotoFacilRepository.Object);

            var jogosIportados = importaLotoFacil.ImportarArquivo(string.Empty, 0);

            Assert.Equal(1598, jogosIportados.Count);
        }
    }
}
