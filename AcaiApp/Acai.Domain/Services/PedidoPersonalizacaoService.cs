using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;

namespace Acai.Domain.Services
{
    public class PedidoPersonalizacaoService : GenericService<PedidoPersonalizacao>, IPedidoPersonalizacaoService
    {
        public PedidoPersonalizacaoService(IUnitOfWork uow) : base(uow.PedidoPersonalizacaoRepository, uow)
        {
        }
    }
}