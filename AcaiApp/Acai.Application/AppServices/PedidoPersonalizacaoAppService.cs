using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Services;

namespace Acai.Application.AppServices
{
    public class PedidoPersonalizacaoAppService : GenericAppService<PedidoPersonalizacao>, IPedidoPersonalizacaoAppService
    {
        public PedidoPersonalizacaoAppService(IPedidoPersonalizacaoService pedidoPersonalizacaoService) : base(pedidoPersonalizacaoService)
        {
        }
    }
}