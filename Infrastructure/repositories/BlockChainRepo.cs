using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.repositories
{
    public class BlockChainRepo : GenericRepository<BlockChain>, IBlockChain
    {
        private readonly ApiContext _context;


        public BlockChainRepo(ApiContext context) : base(context)
        {
            _context = context;

        }

    }
}