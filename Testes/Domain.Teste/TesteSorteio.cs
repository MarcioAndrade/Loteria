using Xunit;
using Domain.MegaSena;

namespace Domain.Teste
{
    public class TesteSorteio
    {
        [Fact]
        public void ObterDezenasSorteadasMegaSena()
        {
            var sorteio = new Sorteio(new ConstantesMegaSena(), 2018);

            Assert.Equal(6, sorteio.ObterDezenasSortedas().Count);
        }
    }
}
