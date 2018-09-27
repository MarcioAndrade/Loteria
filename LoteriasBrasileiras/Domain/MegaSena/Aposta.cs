using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.MegaSena
{
    public class Aposta : IAposta
    {
        public Aposta(int concurso)
        {
            Concurso = concurso;
            Jogos = new List<Jogo>();
        }

        public int Concurso { get; private set; }

        public IEnumerable<IJogo> Jogos { get; set; }
    }
}
