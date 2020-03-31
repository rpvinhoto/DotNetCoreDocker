using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Services;

namespace Acai.Application.AppServices
{
    public class TamanhoAppService : GenericAppService<Tamanho>, ITamanhoAppService
    {
        public TamanhoAppService(ITamanhoService tamanhoService) : base(tamanhoService)
        {
        }
    }
}