using System;

namespace Domain.LotoFacil
{
    public class LotoFacilCEF : Entity<LotoFacilCEF>
    {
        public LotoFacilCEF
            (
                int concurso, DateTime dataSorteio, int bola01, int bola02, int bola03,
                int bola04, int bola05, int bola06, int bola07, int bola08,
                int bola09, int bola10, int bola11, int bola12, int bola13,
                int bola14, int bola15, decimal arrecadacao, int ganhadores15, int ganhadores14,
                int ganhadores13, int ganhadores12, int ganhadores11, decimal valorRateio15, decimal valorRateio14,
                decimal valorRateio13, decimal valorRateio12, decimal valorRateio11, decimal acumulado, decimal estimativaPremio,
                decimal acumuladoEspecial
            )
        {
            Id = Guid.NewGuid();
            Concurso = concurso;
            DataSorteio = dataSorteio;
            Bola01 = bola01;
            Bola02 = bola02;
            Bola03 = bola03;
            Bola04 = bola04;
            Bola05 = bola05;
            Bola06 = bola06;
            Bola07 = bola07;
            Bola08 = bola08;
            Bola09 = bola09;
            Bola10 = bola10;
            Bola11 = bola11;
            Bola12 = bola12;
            Bola13 = bola13;
            Bola14 = bola14;
            Bola15 = bola15;
            Arrecadacao = arrecadacao;
            Ganhadores15 = ganhadores15;
            Ganhadores14 = ganhadores14;
            Ganhadores13 = ganhadores13;
            Ganhadores12 = ganhadores12;
            Ganhadores11 = ganhadores11;
            ValorRateio15 = valorRateio15;
            ValorRateio14 = valorRateio14;
            ValorRateio13 = valorRateio13;
            ValorRateio12 = valorRateio12;
            ValorRateio11 = valorRateio11;
            Acumulado = acumulado;
            EstimativaPremio = estimativaPremio;
            AcumuladoEspecial = acumuladoEspecial;
        }

        public int Concurso { get; private set; }
        public DateTime DataSorteio { get; private set; }
        public int Bola01 { get; private set; }
        public int Bola02 { get; private set; }
        public int Bola03 { get; private set; }
        public int Bola04 { get; private set; }
        public int Bola05 { get; private set; }
        public int Bola06 { get; private set; }
        public int Bola07 { get; private set; }
        public int Bola08 { get; private set; }
        public int Bola09 { get; private set; }
        public int Bola10 { get; private set; }
        public int Bola11 { get; private set; }
        public int Bola12 { get; private set; }
        public int Bola13 { get; private set; }
        public int Bola14 { get; private set; }
        public int Bola15 { get; private set; }
        public decimal Arrecadacao { get; private set; }
        public int Ganhadores15 { get; private set; }
        public int Ganhadores14 { get; private set; }
        public int Ganhadores13 { get; private set; }
        public int Ganhadores12 { get; private set; }
        public int Ganhadores11 { get; private set; }
        public decimal ValorRateio15 { get; private set; }
        public decimal ValorRateio14 { get; private set; }
        public decimal ValorRateio13 { get; private set; }
        public decimal ValorRateio12 { get; private set; }
        public decimal ValorRateio11 { get; private set; }
        public decimal Acumulado { get; private set; }
        public decimal EstimativaPremio { get; private set; }
        public decimal AcumuladoEspecial { get; private set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}
