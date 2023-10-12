using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PermisosGenericosConf : IEntityTypeConfiguration<PermisosGenericos>
    {
        public void Configure(EntityTypeBuilder<PermisosGenericos> builder)
        {
            builder.ToTable("PermisosGenericos");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property (p => p.NombrePermiso)
            .IsRequired()
            .HasMaxLength(50);
            
            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}