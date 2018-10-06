using Xunit;
using Domain.Quina;

namespace Domain.Teste.Quina
{
    public class TesteSorteio
    {
        [Fact]
        public void ObterDezenasSorteadasQuina()
        {
            var sorteio = new Sorteio(new Constantes(), 2018);

            Assert.Equal(5, sorteio.DezenasSorteadas.Count);
        }
    }
}
