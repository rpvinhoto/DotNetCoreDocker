using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Acai.Domain.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _uow;

        public GenericService(IRepository<T> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public virtual T Add(T entity)
        {
            var createdEntity = _repository.Add(entity);
            _uow.Commit();

            return createdEntity;
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
            _uow.Commit();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
            _uow.Commit();
        }
    }
}