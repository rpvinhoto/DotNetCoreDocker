using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Services;

namespace Acai.Application.AppServices
{
    public class PersonalizacaoAppService : GenericAppService<Personalizacao>, IPersonalizacaoAppService
    {
        public PersonalizacaoAppService(IPersonalizacaoService personalizacaoService) : base(personalizacaoService)
        {
        }
    }
}