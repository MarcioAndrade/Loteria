using Xunit;
using Domain.Quina;

namespace Domain.Teste.Quina
{
    public class TesteJogo
    {
        [Fact]
        public void RealizaApostaValidaCom06Dezenas()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, null, null, null, null, null, null, null, null, null, null);

            Assert.True(jogo.EhValido());
        }

        [Fact]
        public void RealizaApostaValidaCom15Dezenas()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, 52, 53, 54, 55, 56, 57, 58, 59, 60);

            Assert.True(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena01ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(0, 2, 3, 4, 5, null, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena01ComNumeroAcimaRange()
        {
            var jogo = new Jogo(81, 2, 3, 4, 5, null, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena02ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 0, 3, 4, 5, null, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena02ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 81, 3, 4, 5, 6, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena03ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 0, 4, 5, null, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena03ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 81, 4, 5, null, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena04ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 0, 5, null, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena04ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 81, 5, null, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena05ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 0, null, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena05ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 81, null, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena06ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 0, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena06ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 81, null, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena07ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, 0, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena07ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, 81, null, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena08ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, 0, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena08ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, 81, null, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena09ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, 0, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena09ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, 81, null, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena10ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, 0, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena10ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, 81, null, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena11ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, null, 0, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena11ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, null, 81, null, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena12ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, null, null, 0, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena12ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, null, null, 81, null, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena13ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, null, null, null, 0, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena13ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, null, null, null, 81, null, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena14ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, null, null, null, null, 0, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena14ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, null, null, null, null, 81, null);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena15ComNumeroAbaixoRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, null, null, null, null, null, 0);

            Assert.False(jogo.EhValido());
        }

        [Fact]
        public void FalhaAoApostarDezena15ComNumeroAcimaRange()
        {
            var jogo = new Jogo(1, 2, 3, 4, 5, 6, null, null, null, null, null, null, null, null, 81);

            Assert.False(jogo.EhValido());
        }
    }
}
