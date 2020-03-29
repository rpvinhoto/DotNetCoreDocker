using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;

namespace Acai.Domain.Services
{
    public class ProdutoService : GenericService<Produto>, IProdutoService
    {
        public ProdutoService(IUnitOfWork uow) : base(uow.ProdutoRepository, uow)
        {
        }
    }
}