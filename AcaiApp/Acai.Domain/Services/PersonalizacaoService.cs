using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;

namespace Acai.Domain.Services
{
    public class PersonalizacaoService : GenericService<Personalizacao>, IPersonalizacaoService
    {
        public PersonalizacaoService(IUnitOfWork uow) : base(uow.PersonalizacaoRepository, uow)
        {
        }
    }
}