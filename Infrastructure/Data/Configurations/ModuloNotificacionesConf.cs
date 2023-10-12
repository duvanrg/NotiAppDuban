using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ModuloNotificacionesConf : IEntityTypeConfiguration<ModuloNotificaciones>
    {
        public void Configure(EntityTypeBuilder<ModuloNotificaciones> builder)
        {
            builder.ToTable("ModuloNotificaciones");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.AsuntoNotificacion)
            .IsRequired()
            .HasMaxLength(80);

            builder.HasOne(p => p.TipoNotificacion)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdTipoNotificacion);

            builder.HasOne(p => p.Radicados)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdRadicado);

            builder.HasOne(p => p.EstadoNotificacion)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdEstadoNotificacion);

            builder.HasOne(p => p.HiloRespuestaNotificacion)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdHiloNotificacion);

            builder.HasOne(p => p.Formatos)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdFormato);

            builder.HasOne(p => p.TipoRequerimiento)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdRequerimiento);

            builder.Property(p => p.TextoNotificacion)
            .IsRequired()
            .HasMaxLength(2000);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}