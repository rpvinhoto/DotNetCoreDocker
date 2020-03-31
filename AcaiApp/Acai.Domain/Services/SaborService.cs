using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;

namespace Acai.Domain.Services
{
    public class SaborService : GenericService<Sabor>, ISaborService
    {
        private readonly IUnitOfWork _uow;

        public SaborService(IUnitOfWork uow) : base(uow.SaborRepository, uow)
        {
            _uow = uow;
        }

        public override void Delete(Sabor entity)
        {
            if (_uow.PedidoRepository.ExistsSaborId(entity.Id))
                throw new System.InvalidOperationException("Registro não pode ser excluído pois está vinculado a um pedido.");

            base.Delete(entity);
        }
    }
}