using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;

namespace Acai.Domain.Services
{
    public class SaborService : GenericService<Sabor>, ISaborService
    {
        public SaborService(IUnitOfWork uow) : base(uow.SaborRepository, uow)
        {
        }
    }
}