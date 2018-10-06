using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.MegaSena
{
    public class SorteioFixo : ISorteio
    {
        private readonly IConstantes _constantes;
        private readonly int _concurso;


        public SorteioFixo(IConstantes constantes, int concurso)
        {
            _constantes = constantes;
            _concurso = concurso;
        }

        public IList<int> DezenasSorteadas { get { return new List<int> { 1, 2, 3, 4, 5, 6 }; } }
    }
}
