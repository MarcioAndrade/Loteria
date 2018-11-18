using System;
using FluentValidation;

namespace Domain.MegaSena
{
    public class MegaSenaCEF : Entity<MegaSenaCEF>
    {
        protected MegaSenaCEF() { }

        public MegaSenaCEF(int concurso, DateTime dataSorteio, int primeiraDezena, int segundaDezena, int terceiraDezena,
                int quartaDezena, int quintaDezena, int sextaDezena, decimal arrecadacao, int ganhadoresSena, decimal rateioSena,
                int ganhadoresQuina, decimal rateioQuina, int ganhadoresQuadra, decimal rateioQuadra, string acumulado,
                decimal valorAcumulado, decimal estimativaPremio, decimal acumuladoMegaDaVirada)
        {
            Concurso = concurso;
            DataSorteio = dataSorteio;
            PrimeiraDezena = primeiraDezena;
            SegundaDezena = segundaDezena;
            TerceiraDezena = terceiraDezena;
            QuartaDezena = quartaDezena;
            QuintaDezena = quintaDezena;
            SextaDezena = sextaDezena;
            Arrecadacao = arrecadacao;
            GanhadoresSena = ganhadoresSena;
            RateioSena = rateioSena;
            GanhadoresQuina = ganhadoresQuina;
            RateioQuina = rateioQuina;
            GanhadoresQuadra = ganhadoresQuadra;
            RateioQuadra = rateioQuadra;
            Acumulado = acumulado;
            ValorAcumulado = valorAcumulado;
            EstimativaPremio = estimativaPremio;
            AcumuladoMegaDaVirada = acumuladoMegaDaVirada;
        }

        public int Concurso { get; private set; }
        public DateTime DataSorteio { get; private set; }
        public int PrimeiraDezena { get; private set; }
        public int SegundaDezena { get; private set; }
        public int TerceiraDezena { get; private set; }
        public int QuartaDezena { get; private set; }
        public int QuintaDezena { get; private set; }
        public int SextaDezena { get; private set; }
        public decimal Arrecadacao { get; private set; }
        public int GanhadoresSena { get; private set; }
        public decimal RateioSena { get; private set; }
        public int GanhadoresQuina { get; private set; }
        public decimal RateioQuina { get; private set; }
        public int GanhadoresQuadra { get; private set; }
        public decimal RateioQuadra { get; private set; }
        public string Acumulado { get; private set; }
        public decimal ValorAcumulado { get; private set; }
        public decimal EstimativaPremio { get; private set; }
        public decimal AcumuladoMegaDaVirada { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarConcurso();
            ValidarDataSorteio();
            ValidarDezenas();
            ValidarArrecadacao();
            ValidarGanhadores();
            ValidarAcumulado();
            ValidarEstimativaPremio();

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
            var dataInicial = new DateTime(1996, 03, 11, 0, 0, 0);
            var dataFinal = dataInicial.AddYears(40);
            RuleFor(c => DataSorteio)
                .InclusiveBetween(dataInicial, dataFinal)
                .WithMessage("A data do concurso deve ser válida");
        }

        private void ValidarDezenas()
        {
            RuleFor(c => PrimeiraDezena)
                .InclusiveBetween(1, 60)
                .WithMessage("A primeira dezena deve ter um valor entre 1 e 60");

            RuleFor(c => SegundaDezena)
                .InclusiveBetween(1, 60)
                .WithMessage("A segunda dezena deve ter um valor entre 1 e 60");

            RuleFor(c => TerceiraDezena)
                .InclusiveBetween(1, 60)
                .WithMessage("A terceira dezena deve ter um valor entre 1 e 60");

            RuleFor(c => QuartaDezena)
                .InclusiveBetween(1, 60)
                .WithMessage("A quarta dezena deve ter um valor entre 1 e 60");

            RuleFor(c => QuintaDezena)
                .InclusiveBetween(1, 60)
                .WithMessage("A quinta dezena deve ter um valor entre 1 e 60");

            RuleFor(c => SextaDezena)
                .InclusiveBetween(1, 60)
                .WithMessage("A sexta dezena deve ter um valor entre 1 e 60");

        }

        private void ValidarArrecadacao()
        {
            RuleFor(c => Arrecadacao)
                .GreaterThanOrEqualTo(0M)
                .WithMessage("A arrecadação deve ter um valor válido");
        }

        private void ValidarGanhadores()
        {
            RuleFor(c => GanhadoresSena)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O número de ganhadores da sena deve ser válido");

            RuleFor(c => GanhadoresQuina)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O número de ganhadores da quina deve ser válido");

            RuleFor(c => GanhadoresQuadra)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O número de ganhadores da quadra deve ser válido");

            RuleFor(c=>c.RateioSena)
                .GreaterThanOrEqualTo(0M)
                .WithMessage("O rateio entre os ganhadores da sena deve ser válido");

            RuleFor(c => c.RateioQuina)
                .GreaterThanOrEqualTo(0M)
                .WithMessage("O rateio entre os ganhadores da quina deve ser válido");

            RuleFor(c => c.RateioQuadra)
                .GreaterThanOrEqualTo(0M)
                .WithMessage("O rateio entre os ganhadores da quadra deve ser válido");
        }

        private void ValidarAcumulado()
        {
            RuleFor(c => c.Acumulado)
                .NotEmpty()
                .WithMessage("Acumlado SIM/NÃO precisa ser informado");

            RuleFor(c => ValorAcumulado)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor acumulado deve ser válido");

            RuleFor(c => AcumuladoMegaDaVirada)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor acumulado da Mega da virada deve ser válido");
        }

        private void ValidarEstimativaPremio()
        {
            RuleFor(c => EstimativaPremio)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor da estimativa de prêmio deve ser válido");
        }
    }
}
