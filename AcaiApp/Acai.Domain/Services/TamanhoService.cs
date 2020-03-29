using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;

namespace Acai.Domain.Services
{
    public class TamanhoService : GenericService<Tamanho>, ITamanhoService
    {
        public TamanhoService(IUnitOfWork uow) : base(uow.TamanhoRepository, uow)
        {
        }
    }
}