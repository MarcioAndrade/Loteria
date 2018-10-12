using System;
using FluentValidation;
using Domain.Interfaces;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Domain.LotoFacil
{
    public class Jogo : Entity<Jogo>, IJogo
    {
        public Jogo(int dezena_01, int dezena_02, int dezena_03, int dezena_04, int dezena_05,
            int dezena_06, int dezena_07, int dezena_08, int dezena_09, int dezena_10,
            int dezena_11, int dezena_12, int dezena_13, int dezena_14, int dezena_15,
            int? dezena_16, int? dezena_17, int? dezena_18)
        {
            Id = Guid.NewGuid();
            Dezena_01 = dezena_01;
            Dezena_02 = dezena_02;
            Dezena_03 = dezena_03;
            Dezena_04 = dezena_04;
            Dezena_05 = dezena_05;
            Dezena_06 = dezena_06;
            Dezena_07 = dezena_07;
            Dezena_08 = dezena_08;
            Dezena_09 = dezena_09;
            Dezena_10 = dezena_10;
            Dezena_11 = dezena_11;
            Dezena_12 = dezena_12;
            Dezena_13 = dezena_13;
            Dezena_14 = dezena_14;
            Dezena_15 = dezena_15;
            Dezena_16 = dezena_16;
            Dezena_17 = dezena_17;
            Dezena_18 = dezena_18;
        }

        public int Dezena_01 { get; private set; }
        public int Dezena_02 { get; private set; }
        public int Dezena_03 { get; private set; }
        public int Dezena_04 { get; private set; }
        public int Dezena_05 { get; private set; }
        public int Dezena_06 { get; private set; }
        public int Dezena_07 { get; private set; }
        public int Dezena_08 { get; private set; }
        public int Dezena_09 { get; private set; }
        public int Dezena_10 { get; private set; }
        public int Dezena_11 { get; private set; }
        public int Dezena_12 { get; private set; }
        public int Dezena_13 { get; private set; }
        public int Dezena_14 { get; private set; }
        public int Dezena_15 { get; private set; }
        public int? Dezena_16 { get; private set; }
        public int? Dezena_17 { get; private set; }
        public int? Dezena_18 { get; private set; }

        public override bool EhValido()
        {
            Validar();

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        public int? Acertos { get; set; }
        public string Premiacao
        {
            get
            {
                if (Acertos.HasValue)
                {
                    switch (Acertos.Value)
                    {
                        case 11: return "11 acertos";
                        case 12: return "12 acertos";
                        case 13: return "13 acertos";
                        case 14: return "14 acertos";
                        case 15: return "15 acertos";
                    }
                }
                return string.Empty;
            }
        }

        public IList<int> Dezenas
        {
            get
            {
                var _dezenas = new List<int>
                    {
                        Dezena_01, Dezena_02, Dezena_03, Dezena_04, Dezena_05,
                        Dezena_06, Dezena_07, Dezena_08, Dezena_09, Dezena_10,
                        Dezena_11, Dezena_12, Dezena_12, Dezena_14, Dezena_15
                    };

                if (Dezena_16.HasValue)
                    _dezenas.Add(Dezena_16.Value);

                if (Dezena_17.HasValue)
                    _dezenas.Add(Dezena_17.Value);

                if (Dezena_18.HasValue)
                    _dezenas.Add(Dezena_18.Value);

                _dezenas.Sort();

                return _dezenas;
            }
        }

        private void Validar()
        {
            RuleFor(d => d.Dezena_01)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 01 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_02)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 02 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_03)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 03 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_04)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 04 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_05)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 05 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_06)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 06 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_07)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 07 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_08)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 08 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_09)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 09 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_10)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 10 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_11)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 11 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_12)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 12 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_13)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 13 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_14)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 14 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_15)
                .ExclusiveBetween(0, 26)
                    .WithMessage("A dezena 15 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_16)
                .ExclusiveBetween(0, 26).When(e => e.Dezena_16.HasValue)
                    .WithMessage("A dezena 15 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_17)
                .ExclusiveBetween(0, 26).When(e => e.Dezena_17.HasValue)
                    .WithMessage("A dezena 15 deve ter um número entre 01 e 25");

            RuleFor(d => d.Dezena_18)
                .ExclusiveBetween(0, 26).When(e => e.Dezena_18.HasValue)
                    .WithMessage("A dezena 15 deve ter um número entre 01 e 25");
        }
    }
}
