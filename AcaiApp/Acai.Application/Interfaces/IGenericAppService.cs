using System;
using System.Collections.Generic;

namespace Acai.Application.Interfaces
{
    public interface IGenericAppService<T> : IDisposable where T : class
    {
        T Add(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}