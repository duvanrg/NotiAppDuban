using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class SubmodulosRepo : GenericRepository<Submodulos>, ISubmodulos
    {
        private readonly ApiContext _context;


        public SubmodulosRepo(ApiContext context) : base(context)
        {
            _context = context;

        }

    }
}