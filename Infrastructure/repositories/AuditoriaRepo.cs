using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class AuditoriaRepo : GenericRepository<Auditoria>, IAuditoria
    {
        private readonly ApiContext _context;


        public AuditoriaRepo(ApiContext context) : base(context)
        {
            _context = context;
        }

    }
}