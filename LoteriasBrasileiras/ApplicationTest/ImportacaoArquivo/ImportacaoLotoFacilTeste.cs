using Moq;
using Xunit;
using System;
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

            Assert.Throws<ArgumentException>(() => importaLotoFacil.ImportarArquivo(string.Empty, 0));
        }
    }
}
