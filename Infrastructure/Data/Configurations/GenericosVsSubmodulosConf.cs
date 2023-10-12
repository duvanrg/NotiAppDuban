using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class GenericosVsSubmodulosConf : IEntityTypeConfiguration<GenericosVsSubmodulos>
    {
        public void Configure(EntityTypeBuilder<GenericosVsSubmodulos> builder)
        {
            builder.ToTable("GenericosVsSubmodulos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne (p => p.PermisosGenericos)
            .WithMany (p => p.genericosVsSubmodulos)
            .HasForeignKey(p => p.IdGenericos);

            builder.HasOne (p => p.MaestrosVsSubmodulos)
            .WithMany (p => p.GenericosVsSubmodulos)
            .HasForeignKey(p => p.IdMaestrosSubmodulos);

            builder.HasOne (p => p.rol)
            .WithMany (p => p.genericosVsSubmodulos)
            .HasForeignKey(p => p.IdRol);

            builder. Property (p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder. Property (p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}