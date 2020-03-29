using Acai.Application.Interfaces;
using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Services;

namespace Acai.Application.AppServices
{
    public class ProdutoPersonalizacaoAppService : GenericAppService<ProdutoPersonalizacao>, IProdutoPersonalizacaoAppService
    {
        public ProdutoPersonalizacaoAppService(IProdutoPersonalizacaoService produtoPersonalizacaoService) : base(produtoPersonalizacaoService)
        {
        }
    }
}