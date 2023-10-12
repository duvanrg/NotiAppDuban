using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class GenericosVsSubmodulosRepo : GenericRepository<GenericosVsSubmodulos>, IGenericosVsSubmodulos
    {
        private readonly ApiContext _context;


        public GenericosVsSubmodulosRepo(ApiContext context) : base(context)
        {
            _context = context;

        }

    }
}