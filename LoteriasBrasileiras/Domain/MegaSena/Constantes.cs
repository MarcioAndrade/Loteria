using Domain.Interfaces;

namespace Domain.MegaSena
{
    public class Constantes : IConstantes
    {
        public int ValorMinimoDezena => 1;
        public int ValorMaximoDezena => 60;
        public int DezenasSorteadas => 6;
        public int MinimoDezenasAposta => 6;
        public int MaximoDezenasAposta => 15;
        public string TipoJogo => "Mega Sena";
    }
}
