using Acai.Domain.Entities;
using System;

namespace Acai.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPedidoRepository PedidoRepository { get; }
        IPersonalizacaoRepository PersonalizacaoRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IProdutoPersonalizacaoRepository ProdutoPersonalizacaoRepository { get; }
        ISaborRepository SaborRepository { get; }
        ITamanhoRepository TamanhoRepository { get; }

        void Commit();
    }
}