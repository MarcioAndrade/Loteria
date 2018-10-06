using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.Quina
{
    public class Aposta : IAposta
    {
        public Aposta(int concurso)
        {
            Concurso = concurso;
        }

        public int Concurso { get; private set; }

        public IEnumerable<IJogo> Jogos { get; set; }
    }
}
