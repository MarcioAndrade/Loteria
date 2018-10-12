using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.LotoFacil
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

        public IList<int> DezenasSorteadas { get { return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }; } }
    }
}
