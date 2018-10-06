using Xunit;
using Domain.MegaSena;

namespace Domain.Teste.MegaSena
{
    public class TesteSorteio
    {
        [Fact]
        public void ObterDezenasSorteadasMegaSena()
        {
            var sorteio = new Sorteio(new Constantes(), 2018);

            Assert.Equal(6, sorteio.DezenasSorteadas.Count);
        }
    }
}
