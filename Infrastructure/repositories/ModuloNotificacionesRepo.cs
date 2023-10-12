using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class ModuloNotificacionesRepo : GenericRepository<ModuloNotificaciones>, IModuloNotificaciones
    {
        private readonly ApiContext _context;
        public ModuloNotificacionesRepo(ApiContext context) : base(context)
        {
            _context = context;
        }

    }
}