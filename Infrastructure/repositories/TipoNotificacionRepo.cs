using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class TipoNotificacionRepo : GenericRepository<TipoNotificacion>, ITipoNotificacion
    {
        private readonly ApiContext _context;


        public TipoNotificacionRepo(ApiContext context) : base(context)
        {
            _context = context;

        }

    }
}