using Domain.MegaSena;
using System.Collections.Generic;

namespace Application.ImportacaoResultado.MegaSena
{
    public class Importacao
    {
        public Importacao()
        {
            Validos = new List<MegaSenaCEF>();
            Rejeitados = new List<MegaSenaCEF>();
        }

        public IList<MegaSenaCEF> Validos { get; set; }
        public IList<MegaSenaCEF> Rejeitados { get; set; }
    }
}
