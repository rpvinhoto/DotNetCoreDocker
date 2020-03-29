using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;

namespace Acai.Domain.Services
{
    public class ProdutoPersonalizacaoService : GenericService<ProdutoPersonalizacao>, IProdutoPersonalizacaoService
    {
        public ProdutoPersonalizacaoService(IUnitOfWork uow) : base(uow.ProdutoPersonalizacaoRepository, uow)
        {
        }
    }
}