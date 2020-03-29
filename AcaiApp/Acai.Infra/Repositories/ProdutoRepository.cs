using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Infra.Context;

namespace Acai.Infra.Repositories
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AcaiContext dbContext) : base(dbContext)
        {
        }
    }
}