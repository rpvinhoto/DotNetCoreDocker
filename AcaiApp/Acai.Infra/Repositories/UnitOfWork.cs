using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Infra.Context;
using System.Threading.Tasks;

namespace Acai.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AcaiContext _dbContext;

        public IRepository<Sabor> SaborRepository { get; }

        public UnitOfWork(AcaiContext dbContext)
        {
            _dbContext = dbContext;
            SaborRepository = new SaborRepository(_dbContext);
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}