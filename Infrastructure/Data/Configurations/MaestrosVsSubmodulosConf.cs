using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MaestrosVsSubmodulosConf : IEntityTypeConfiguration<MaestrosVsSubmodulos>
    {
        public void Configure(EntityTypeBuilder<MaestrosVsSubmodulos> builder)
        {
            builder.ToTable("MaestrosVsSubmodulos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.ModulosMaestros)
            .WithMany(p => p.MaestrosVsSubmodulos)
            .HasForeignKey(p => p.IdMaestro);

            builder.HasOne(p => p.Submodulos)
            .WithMany(p => p.MaestrosVsSubmodulos)
            .HasForeignKey(p => p.IdSubmodulo);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}