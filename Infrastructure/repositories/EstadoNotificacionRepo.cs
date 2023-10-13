using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class EstadoNotificacionRepo : GenericRepository<EstadoNotificacion>
    {
        private readonly ApiContext _context;


        public EstadoNotificacionRepo(ApiContext context) : base(context)
        {
            _context = context;

        }

    }
}