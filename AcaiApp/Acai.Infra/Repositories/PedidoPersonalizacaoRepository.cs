using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Infra.Context;

namespace Acai.Infra.Repositories
{
    public class PedidoPersonalizacaoRepository : GenericRepository<PedidoPersonalizacao>, IPedidoPersonalizacaoRepository
    {
        public PedidoPersonalizacaoRepository(AcaiContext dbContext) : base(dbContext)
        {
        }
    }
}