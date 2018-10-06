using Xunit;
using System.Linq;
using Domain.Quina;
using System.Collections.Generic;

namespace Domain.Teste.Quina
{
    public class TestaApuracao
    {
        private readonly Apuracao _apuracao;
        private readonly Aposta _aposta;

        public TestaApuracao()
        {
            var sorteioFixo = new SorteioFixo(new Constantes(), 2018);

            _aposta = new Aposta(2018)
            {
                Jogos = new List<Jogo>
                {
                    new Jogo(1, 2, 3, 4, 5, null, null, null, null, null, null, null, null, null, null),
                    new Jogo(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16),
                    new Jogo(3, 4, 5, 6, 7, 8, null, null, null, null, null, null, null, null, null),
                    new Jogo(4, 5, 6, 7, 8, 9, null, null, null, null, null, null, null, null, null),
                    new Jogo(60, 59, 58, 57, 56, 55, null, null, null, null, null, null, null, null, null)
                }
            };

            _apuracao = new Apuracao(new Constantes(), sorteioFixo, _aposta);
        }

        [Fact]
        public void ObterApuracao_Jogo_Um_Cinco_Acertos()
        {
            Assert.Equal(5, _aposta.Jogos.ToList()[0].Acertos);
        }

        [Fact]
        public void ObterApuracao_Jogo_Um_Premiacao_Quina()
        {
            Assert.Equal("Quina", _aposta.Jogos.ToList()[0].Premiacao);
        }

        [Fact]
        public void ObterApuracao_Jogo_Dois_Quatro_Acertos()
        {
            Assert.Equal(4, _aposta.Jogos.ToList()[1].Acertos);
        }

        [Fact]
        public void ObterApuracao_Jogo_Dois_Premiacao_Quina()
        {
            Assert.Equal("Quadra", _aposta.Jogos.ToList()[1].Premiacao);
        }

        [Fact]
        public void ObterApuracao_Jogo_Tres_Tres_Acertos()
        {
            Assert.Equal(3, _aposta.Jogos.ToList()[2].Acertos);
        }

        [Fact]
        public void ObterApuracao_Jogo_Tres_Premiacao_Terno()
        {
            Assert.Equal("Terno", _aposta.Jogos.ToList()[2].Premiacao);
        }

        [Fact]
        public void ObterApuracao_Jogo_Quatro_Dois_Acertos()
        {
            Assert.Equal(2, _aposta.Jogos.ToList()[3].Acertos);
        }

        [Fact]
        public void ObterApuracao_Jogo_Quatro_Premiacao_Duque()
        {
            Assert.Equal("Duque", _aposta.Jogos.ToList()[3].Premiacao);
        }

        [Fact]
        public void ObterApuracao_Jogo_Cinco_Zero_Acertos()
        {
            Assert.Null(_aposta.Jogos.ToList()[4].Acertos);
        }

        [Fact]
        public void ObterApuracao_Jogo_Cinco_Premiacao_Nula()
        {
            Assert.Equal(string.Empty, _aposta.Jogos.ToList()[4].Premiacao);
        }
    }
}
