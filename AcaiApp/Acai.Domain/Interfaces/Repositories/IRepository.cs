using System;
using System.Collections.Generic;

namespace Acai.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Add(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}