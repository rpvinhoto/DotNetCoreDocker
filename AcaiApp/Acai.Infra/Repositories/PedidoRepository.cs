using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Acai.Infra.Repositories
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        private readonly AcaiContext _dbContext;

        public PedidoRepository(AcaiContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ExistsSaborId(int saborId)
        {
            return _dbContext.Set<Pedido>().Any(p => p.SaborId == saborId);
        }

        public bool ExistsTamanhoId(int tamanhoId)
        {
            return _dbContext.Set<Pedido>().Any(p => p.TamanhoId == tamanhoId);
        }

        public override IEnumerable<Pedido> GetAll()
        {
            return _dbContext.Pedidos.Include(p => p.Personalizacoes).ToList();
        }

        public override Pedido GetById(int id)
        {
            var entity = _dbContext.Pedidos.Include(p => p.Personalizacoes).FirstOrDefault(p => p.Id == id);

            if (entity != null)
                _dbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }
    }
}