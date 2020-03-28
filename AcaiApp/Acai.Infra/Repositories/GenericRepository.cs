using Acai.Domain.Interfaces.Repositories;
using Acai.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Acai.Infra.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AcaiContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AcaiContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}