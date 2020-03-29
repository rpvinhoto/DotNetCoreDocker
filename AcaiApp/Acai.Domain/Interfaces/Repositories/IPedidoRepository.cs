using Acai.Domain.Entities;

namespace Acai.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        bool ExistsTamanhoId(int tamanhoId);
        bool ExistsSaborId(int saborId);
    }
}