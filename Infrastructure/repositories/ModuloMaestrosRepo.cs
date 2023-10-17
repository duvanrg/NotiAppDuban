using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class ModuloMaestrosRepo : GenericRepository<ModulosMaestros>, IModuloMaestros
    {
        private readonly ApiContext _context;
        public ModuloMaestrosRepo(ApiContext context) : base(context)
        {
            _context = context;
        }

    }
}