using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Infra.Context;

namespace Acai.Infra.Repositories
{
    public class TamanhoRepository : GenericRepository<Tamanho>, ITamanhoRepository
    {
        public TamanhoRepository(AcaiContext dbContext) : base(dbContext)
        {
        }
    }
}