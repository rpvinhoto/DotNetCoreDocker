using Acai.Domain.Interfaces.Repositories;
using Acai.Infra.Context;

namespace Acai.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AcaiContext _dbContext;

        private IPedidoRepository _pedidoRepository;
        private IPersonalizacaoRepository _personalizacaoRepository;
        private IPedidoPersonalizacaoRepository _pedidoPersonalizacaoRepository;
        private ISaborRepository _saborRepository;
        private ITamanhoRepository _tamanhoRepository;

        public UnitOfWork(AcaiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPedidoRepository PedidoRepository => _pedidoRepository = _pedidoRepository ?? new PedidoRepository(_dbContext);
        public IPersonalizacaoRepository PersonalizacaoRepository => _personalizacaoRepository = _personalizacaoRepository ?? new PersonalizacaoRepository(_dbContext);
        public IPedidoPersonalizacaoRepository PedidoPersonalizacaoRepository => _pedidoPersonalizacaoRepository = _pedidoPersonalizacaoRepository ?? new PedidoPersonalizacaoRepository(_dbContext);
        public ISaborRepository SaborRepository => _saborRepository = _saborRepository ?? new SaborRepository(_dbContext);
        public ITamanhoRepository TamanhoRepository => _tamanhoRepository = _tamanhoRepository ?? new TamanhoRepository(_dbContext);

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}