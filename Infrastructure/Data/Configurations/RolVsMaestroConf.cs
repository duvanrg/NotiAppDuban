using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class RolVsMaestroConf : IEntityTypeConfiguration<RolVsMaestro>
    {
        public void Configure(EntityTypeBuilder<RolVsMaestro> builder)
        {
            builder.ToTable("RolVsMaestro");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne (p => p.Rol)
            .WithMany (p => p.rolVsMaestros)
            .HasForeignKey(p => p.IdRol);

            builder.HasOne (p => p.ModulosMaestros)
            .WithMany (p => p.rolVsMaestros)
            .HasForeignKey(p => p.IdMaestro);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}