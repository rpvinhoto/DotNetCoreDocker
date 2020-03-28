using Acai.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Acai.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Sabor> SaborRepository { get; }

        Task Commit();
    }
}