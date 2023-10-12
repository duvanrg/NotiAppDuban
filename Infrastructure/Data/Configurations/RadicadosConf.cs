using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class RadicadosConf : IEntityTypeConfiguration<Radicados>
    {
        public void Configure(EntityTypeBuilder<Radicados> builder)
        {
            builder.ToTable("Radicados");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder. Property (p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder. Property (p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}