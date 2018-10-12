using Domain.Interfaces;

namespace Domain.LotoFacil
{
    public class Constantes : IConstantes
    {
        public int ValorMinimoDezena => 1;
        public int ValorMaximoDezena => 25;
        public int DezenasSorteadas => 15;
        public int MinimoDezenasAposta => 15;
        public int MaximoDezenasAposta => 18;
        public string TipoJogo => "Lotofácil";
    }
}
