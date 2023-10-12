using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class RolRepo : GenericRepository<Rol>, IRol
    {
        private readonly ApiContext _context;
        public RolRepo(ApiContext context) : base(context)
        {
            _context = context;
        }

    }
}