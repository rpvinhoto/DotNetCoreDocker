using Acai.Application.Interfaces;
using Acai.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Acai.Application.AppServices
{
    public class GenericAppService<T> : IGenericAppService<T> where T : class
    {
        private readonly IGenericService<T> _genericService;

        public GenericAppService(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        public void Add(T entity)
        {
            _genericService.Add(entity);
        }

        public void Delete(T entity)
        {
            _genericService.Delete(entity);
        }

        public void Dispose()
        {
            _genericService.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return _genericService.GetAll();
        }

        public T GetById(int id)
        {
            return _genericService.GetById(id);
        }

        public void Update(T entity)
        {
            _genericService.Update(entity);
        }
    }
}