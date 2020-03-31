using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Services;

namespace Acai.Application.AppServices
{
    public class PedidoAppService : GenericAppService<Pedido>, IPedidoAppService
    {
        public PedidoAppService(IPedidoService pedidoService) : base(pedidoService)
        {
        }
    }
}