using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Infra.Context;

namespace Acai.Infra.Repositories
{
    public class SaborRepository : GenericRepository<Sabor>, ISaborRepository
    {
        //private readonly AcaiContext _dbContext;

        public SaborRepository(AcaiContext dbContext) : base(dbContext)
        {
            //ToDo _dbContext = dbContext;
        }
    }
}