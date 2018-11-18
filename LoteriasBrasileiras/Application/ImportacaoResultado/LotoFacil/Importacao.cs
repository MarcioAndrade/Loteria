using Domain.LotoFacil;
using System.Collections.Generic;

namespace Application.ImportacaoResultado.LotoFacil
{
    public class Importacao
    {
        public Importacao()
        {
            Validos = new List<LotoFacilCEF>();
            Rejeitados = new List<LotoFacilCEF>();
        }

        public IList<LotoFacilCEF> Validos { get; set; }
        public IList<LotoFacilCEF> Rejeitados { get; set; }
    }
}
