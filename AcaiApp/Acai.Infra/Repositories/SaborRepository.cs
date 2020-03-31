using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Infra.Context;

namespace Acai.Infra.Repositories
{
    public class SaborRepository : GenericRepository<Sabor>, ISaborRepository
    {
        public SaborRepository(AcaiContext dbContext) : base(dbContext)
        {
        }
    }
}