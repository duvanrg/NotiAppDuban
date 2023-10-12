using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class PermisosGenericosRepo : GenericRepository<PermisosGenericos>, IPermisosGenericos
    {
        private readonly ApiContext _context;


        public PermisosGenericosRepo(ApiContext context) : base(context)
        {
            _context = context;

        }

    }
}