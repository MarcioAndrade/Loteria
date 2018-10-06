using Domain.Interfaces;

namespace Domain.Quina
{
    public class Constantes : IConstantes
    {
        public int ValorMinimoDezena => 1;
        public int ValorMaximoDezena => 80;
        public int DezenasSorteadas => 5;
        public int MinimoDezenasAposta => 5;
        public int MaximoDezenasAposta => 15;
        public string TipoJogo => "Quina";
    }
}
