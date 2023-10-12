using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipoNotificacionConf : IEntityTypeConfiguration<TipoNotificacion>
    {
        public void Configure(EntityTypeBuilder<TipoNotificacion> builder)
        {
            builder.ToTable("TipoNotificacion");
            builder.HasKey(e => e.Id);
            builder.Property (e => e.Id);

            builder.Property (p => p.NombreTipo)
            .IsRequired()
            .HasMaxLength(80);
            
            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}