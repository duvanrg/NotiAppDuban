using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class FormatosRepo : GenericRepository<Formatos>, IFormatos
    {
        private readonly ApiContext _context;


        public FormatosRepo(ApiContext context) : base(context)
        {
            _context = context;

        }

    }
}