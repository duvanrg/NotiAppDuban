using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class EstadoNotificacionRepo : GenericRepository<EstadoNotificacion>, IEstadoNotificacion
    {
        private readonly ApiContext _context;


        public EstadoNotificacionRepo(ApiContext context) : base(context)
        {
            _context = context;

        }

    }
}