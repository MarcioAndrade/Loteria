using Domain.Interfaces;

namespace Domain
{
    public class Apuracao
    {
        private readonly IAposta _aposta;
        private readonly IConstantes _constantes;
        private readonly ISorteio _sorteio;

        public Apuracao(IConstantes constantes, ISorteio sorteio, IAposta aposta)
        {
            _aposta = aposta;
            _constantes = constantes;
            _sorteio = sorteio;
        }

        public IAposta ObterAcertos()
        {
            return null;
        }
    }
}
