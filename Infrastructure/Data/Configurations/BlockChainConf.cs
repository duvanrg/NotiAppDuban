using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class BlockChainConf : IEntityTypeConfiguration<BlockChain>
    {
        public void Configure(EntityTypeBuilder<BlockChain> builder)
        {
            builder.ToTable("BlockChain");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property (p => p.HashGenerado)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne (p => p.Auditoria)
            .WithMany (p => p.BlockChains)
            .HasForeignKey(p => p.IdAuditoria);

            builder.HasOne (p => p.TipoNotificacion)
            .WithMany (p => p.BlockChains)
            .HasForeignKey(p => p.IdNotificacion);

            builder.HasOne (p => p.HiloRespuestaNotificacion)
            .WithMany (p => p.BlockChains)
            .HasForeignKey(p => p.IdHiloRespuesta);
            
            builder. Property (p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder. Property (p => p.FechaModificacion)
            .HasColumnType("datetime");
        }
    }
}