using Domain.MegaSena;
using Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    public class MegaSenaMapping : EntityTypeConfiguration<MegaSenaCEF>
    {
        public override void Map(EntityTypeBuilder<MegaSenaCEF> builder)
        {
            builder.ToTable("MegaSenaCEF");

            builder.HasKey(e => e.Id);

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.Property(e => e.Concurso)
              .IsRequired();

            builder.Property(e => e.DataSorteio)
              .IsRequired();

            builder.Property(e => e.PrimeiraDezena)
              .IsRequired();

            builder.Property(e => e.SegundaDezena)
              .IsRequired();

            builder.Property(e => e.TerceiraDezena)
              .IsRequired();

            builder.Property(e => e.QuartaDezena)
              .IsRequired();

            builder.Property(e => e.QuintaDezena)
              .IsRequired();

            builder.Property(e => e.SextaDezena)
              .IsRequired();

            builder.Property(e => e.Arrecadacao)
              .IsRequired();

            builder.Property(e => e.GanhadoresSena)
              .IsRequired();

            builder.Property(e => e.RateioSena)
              .IsRequired();

            builder.Property(e => e.GanhadoresQuina)
              .IsRequired();

            builder.Property(e => e.RateioQuina)
              .IsRequired();

            builder.Property(e => e.GanhadoresQuadra)
              .IsRequired();

            builder.Property(e => e.RateioQuadra)
              .IsRequired();

            builder.Property(e => e.Acumulado)
              .IsRequired();

            builder.Property(e => e.ValorAcumulado)
              .IsRequired();

            builder.Property(e => e.EstimativaPremio)
              .IsRequired();

            builder.Property(e => e.AcumuladoMegaDaVirada)
              .IsRequired();
        }
    }
}
