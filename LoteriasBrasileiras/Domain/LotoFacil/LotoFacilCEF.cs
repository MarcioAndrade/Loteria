using System;
using FluentValidation;

namespace Domain.LotoFacil
{
    public class LotoFacilCEF : Entity<LotoFacilCEF>
    {
        protected LotoFacilCEF() { }

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
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarConcurso();
            ValidarDataSorteio();
            ValidarBolas();
            ValidarArrecadacao();
            ValidarGanhadores();
            ValidarAcumulado();
            ValidarEstimativaPremio();
            ValidarAcumuladoEspecial();

            ValidationResult = Validate(this);
        }

        private void ValidarConcurso()
        {
            RuleFor(c => Concurso)
                .InclusiveBetween(1, 10000)
                .WithMessage("O concurso deve ter um número válido");
        }

        private void ValidarDataSorteio()
        {
            var dataInicial = new DateTime(2003, 09, 29, 0, 0, 0);
            var dataFinal = dataInicial.AddYears(30);
            RuleFor(c => DataSorteio)
                .InclusiveBetween(dataInicial, dataFinal)
                .WithMessage("A data do concurso deve ser válida");
        }

        private void ValidarBolas()
        {
            RuleFor(c => Bola01)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 01 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola02)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 02 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola03)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 03 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola04)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 04 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola05)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 05 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola06)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 06 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola07)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 07 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola08)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 08 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola09)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 09 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola10)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 10 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola11)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 11 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola12)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 12 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola13)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 13 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola14)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 14 deve ter um valor entre 1 e 25");

            RuleFor(c => Bola15)
                .InclusiveBetween(1, 25)
                .WithMessage("A bola 15 deve ter um valor entre 1 e 25");

        }

        private void ValidarArrecadacao()
        {
            RuleFor(c => Arrecadacao)
                .GreaterThanOrEqualTo(0M)
                .WithMessage("A arrecadação deve ter um valor válido");
        }

        private void ValidarGanhadores()
        {
            RuleFor(c => Ganhadores11)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O número de ganhadores de 11 de dezenas deve ser válido");

            RuleFor(c => Ganhadores12)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O número de ganhadores de 12 de dezenas deve ser válido");

            RuleFor(c => Ganhadores13)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O número de ganhadores de 13 de dezenas deve ser válido");

            RuleFor(c => Ganhadores14)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O número de ganhadores de 14 de dezenas deve ser válido");

            RuleFor(c => Ganhadores15)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O número de ganhadores de 15 de dezenas deve ser válido");
        }

        private void ValidarAcumulado()
        {
            RuleFor(c => Acumulado)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor acumulado deve ser válido");
        }

        private void ValidarEstimativaPremio()
        {
            RuleFor(c => EstimativaPremio)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor da estimativa de prêmio deve ser válido");
        }

        private void ValidarAcumuladoEspecial()
        {
            RuleFor(c => AcumuladoEspecial)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor acumulado especial deve ser válido");
        }
    }
}
