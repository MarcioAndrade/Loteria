using Domain.LotoFacil;
using Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    public class LotoFacilMapping : EntityTypeConfiguration<LotoFacilCEF>
    {
        public override void Map(EntityTypeBuilder<LotoFacilCEF> builder)
        {
            builder.ToTable("LotoFacilCEF");

            builder.Property(e => e.Id)
               .HasColumnType("varchar(40)")
               .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.Property(e => e.Concurso)
              .IsRequired();

            builder.Property(e => e.DataSorteio)
              .IsRequired();

            builder.Property(e => e.Bola01)
              .IsRequired();

            builder.Property(e => e.Bola02)
              .IsRequired();

            builder.Property(e => e.Bola03)
              .IsRequired();

            builder.Property(e => e.Bola04)
              .IsRequired();

            builder.Property(e => e.Bola05)
              .IsRequired();

            builder.Property(e => e.Bola06)
              .IsRequired();

            builder.Property(e => e.Bola07)
              .IsRequired();

            builder.Property(e => e.Bola08)
              .IsRequired();

            builder.Property(e => e.Bola09)
              .IsRequired();

            builder.Property(e => e.Bola10)
              .IsRequired();

            builder.Property(e => e.Bola11)
              .IsRequired();

            builder.Property(e => e.Bola12)
              .IsRequired();

            builder.Property(e => e.Bola13)
              .IsRequired();

            builder.Property(e => e.Bola14)
              .IsRequired();

            builder.Property(e => e.Bola15)
              .IsRequired();

            builder.Property(e => e.Arrecadacao)
              .IsRequired();

            builder.Property(e => e.Ganhadores15)
              .IsRequired();

            builder.Property(e => e.Ganhadores14)
              .IsRequired();

            builder.Property(e => e.Ganhadores13)
              .IsRequired();

            builder.Property(e => e.Ganhadores12)
              .IsRequired();

            builder.Property(e => e.Ganhadores11)
              .IsRequired();

            builder.Property(e => e.ValorRateio15)
              .IsRequired();

            builder.Property(e => e.ValorRateio14)
              .IsRequired();

            builder.Property(e => e.ValorRateio13)
              .IsRequired();

            builder.Property(e => e.ValorRateio12)
              .IsRequired();

            builder.Property(e => e.ValorRateio11)
              .IsRequired();

            builder.Property(e => e.Acumulado)
              .IsRequired();

            builder.Property(e => e.EstimativaPremio)
              .IsRequired();

            builder.Property(e => e.AcumuladoEspecial)
              .IsRequired();
        }
    }
}
