using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class MaestrosVsSubmodulosRepo : GenericRepository<MaestrosVsSubmodulos>, IMaestrosVsSubmodulos
    {
        private readonly ApiContext _context;
        public MaestrosVsSubmodulosRepo(ApiContext context) : base(context)
        {
            _context = context;
        }

    }
}