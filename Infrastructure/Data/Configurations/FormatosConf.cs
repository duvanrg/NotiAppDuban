using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class FormatosConf : IEntityTypeConfiguration<Formatos>
    {
        public void Configure(EntityTypeBuilder<Formatos> builder)
        {
            builder.ToTable("Formatos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property (p => p.NombreFormato)
            .IsRequired()
            .HasMaxLength(50);

            builder. Property (p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder. Property (p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}