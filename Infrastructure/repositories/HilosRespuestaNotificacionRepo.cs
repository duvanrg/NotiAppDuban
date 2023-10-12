using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class HilosRespuestaNotificacionRepo : GenericRepository<HiloRespuestaNotificacion>, IHilosRespuestaNotificacion
    {
        private readonly ApiContext _context;


        public HilosRespuestaNotificacionRepo(ApiContext context) : base(context)
        {
            _context = context;

        }

    }
}