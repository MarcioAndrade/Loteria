using System;

namespace Application.ViewModel
{
    public class MegaSenaViewModel
    {
        public int Concurso { get; set; }
        public DateTime DataSorteio { get; set; }
        public int PrimeiraDezena { get; set; }
        public int SegundaDezena { get; set; }
        public int TerceiraDezena { get; set; }
        public int QuartaDezena { get; set; }
        public int QuintaDezena { get; set; }
        public int SextaDezena { get; set; }
        public decimal Arrecadacao { get; set; }
        public int GanhadoresSena { get; set; }
        public decimal RateioSena { get; set; }
        public int GanhadoresQuina { get; set; }
        public decimal RateioQuina { get; set; }
        public int GanhadoresQuadra { get; set; }
        public decimal RateioQuadra { get; set; }
        public string Acumulado { get; set; }
        public decimal ValorAcumulado { get; set; }
        public decimal EstimativaPremio { get; set; }
        public decimal AcumuladoMegaDaVirada { get; set; }
    }
}
