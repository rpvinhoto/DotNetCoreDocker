using Acai.Domain.Entities;
using System;

namespace Acai.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPedidoRepository PedidoRepository { get; }
        IPersonalizacaoRepository PersonalizacaoRepository { get; }
        IPedidoPersonalizacaoRepository PedidoPersonalizacaoRepository { get; }
        ISaborRepository SaborRepository { get; }
        ITamanhoRepository TamanhoRepository { get; }

        void Commit();
    }
}