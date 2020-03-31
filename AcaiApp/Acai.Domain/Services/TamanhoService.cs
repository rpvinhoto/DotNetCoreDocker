using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;

namespace Acai.Domain.Services
{
    public class TamanhoService : GenericService<Tamanho>, ITamanhoService
    {
        private readonly IUnitOfWork _uow;

        public TamanhoService(IUnitOfWork uow) : base(uow.TamanhoRepository, uow)
        {
            _uow = uow;
        }

        public override void Delete(Tamanho entity)
        {
            if (_uow.PedidoRepository.ExistsTamanhoId(entity.Id))
                throw new System.InvalidOperationException("Registro não pode ser excluído pois está vinculado a um pedido.");

            base.Delete(entity);
        }
    }
}