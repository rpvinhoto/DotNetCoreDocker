using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Infra.Context;

namespace Acai.Infra.Repositories
{
    public class PersonalizacaoRepository : GenericRepository<Personalizacao>, IPersonalizacaoRepository
    {
        public PersonalizacaoRepository(AcaiContext dbContext) : base(dbContext)
        {
        }
    }
}