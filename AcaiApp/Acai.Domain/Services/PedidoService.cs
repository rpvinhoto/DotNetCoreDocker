using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;

namespace Acai.Domain.Services
{
    public class PedidoService : GenericService<Pedido>, IPedidoService
    {
        public PedidoService(IUnitOfWork uow) : base(uow.PedidoRepository, uow)
        {
        }
    }
}