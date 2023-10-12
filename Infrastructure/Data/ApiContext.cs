using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<BlockChain> BlockChains { get; set; }
        public DbSet<EstadoNotificacion> EstadoNotificaciones { get; set; }
        public DbSet<Formatos> Formatos { get; set; }
        public DbSet<GenericosVsSubmodulos> GenericosVsSubmodulos { get; set; }
        public DbSet<HiloRespuestaNotificacion> HiloRespuestaNotificaciones { get; set; }
        public DbSet<MaestrosVsSubmodulos> MaestrosVsSubmodulos { get; set; }
        public DbSet<ModuloNotificaciones> ModuloNotificaciones { get; set; }
        public DbSet<ModulosMaestros> ModulosMaestros { get; set; }
        public DbSet<PermisosGenericos> PermisosGenericos { get; set; }
        public DbSet<Radicados> Radicados { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolVsMaestro> RolesVsMaestros { get; set; }
        public DbSet<Submodulos> Submodulos { get; set; }
        public DbSet<TipoNotificacion> TipoNotificaciones { get; set; }
        public DbSet<TipoRequerimiento> TipoRequerimientos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}