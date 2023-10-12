using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class RolVsMaestroRepo : GenericRepository<RolVsMaestro>, IRolVsMaestro
    {
        private readonly ApiContext _context;
        public RolVsMaestroRepo(ApiContext context) : base(context)
        {
            _context = context;
        }

    }
}