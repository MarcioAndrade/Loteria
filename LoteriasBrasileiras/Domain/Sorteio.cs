using System;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain
{
    public class Sorteio
    {
        private readonly IConstantes _constantes;
        private readonly int _concurso;

        public Sorteio(IConstantes constantes, int concurso)
        {
            _constantes = constantes;
            _concurso = concurso;
        }

        public int MyProperty { get; set; }

        public IList<int> DezenasSorteadas { get { return ObterDezenasSortedas(); } }

        public IList<int> ObterDezenasSortedas()
        {
            var retorno = new List<int>();

            for (int i = 0; retorno.Count < _constantes.DezenasSorteadas; i++)
            {
                var random = new Random(DateTime.Now.Millisecond);
                var dezenaSorteada = random.Next(_constantes.ValorMinimoDezena, _constantes.ValorMaximoDezena);

                if (!retorno.Contains(dezenaSorteada))
                    retorno.Add(dezenaSorteada);
            }

            return retorno;
        }
    }
}
