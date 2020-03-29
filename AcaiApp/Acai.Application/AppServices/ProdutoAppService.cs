using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Services;

namespace Acai.Application.AppServices
{
    public class ProdutoAppService : GenericAppService<Produto>, IProdutoAppService
    {
        public ProdutoAppService(IProdutoService produtoService) : base(produtoService)
        {
        }
    }
}