using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class RadicadosRepo : GenericRepository<Radicados>, IRadicados
    {
        private readonly ApiContext _context;


        public RadicadosRepo(ApiContext context) : base(context)
        {
            _context = context;

        }

    }
}