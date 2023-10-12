using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class TipoRequerimientoRepo : GenericRepository<TipoRequerimiento>, ITipoRequerimiento
    {
        private readonly ApiContext _context;
        public TipoRequerimientoRepo(ApiContext context) : base(context)
        {
            _context = context;
        }

    }
}