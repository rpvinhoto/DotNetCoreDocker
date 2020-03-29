using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Infra.Context;

namespace Acai.Infra.Repositories
{
    public class ProdutoPersonalizacaoRepository : GenericRepository<ProdutoPersonalizacao>, IProdutoPersonalizacaoRepository
    {
        public ProdutoPersonalizacaoRepository(AcaiContext dbContext) : base(dbContext)
        {
        }
    }
}