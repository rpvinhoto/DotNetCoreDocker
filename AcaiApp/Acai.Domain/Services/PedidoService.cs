using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Acai.Domain.Services
{
    public class PedidoService : GenericService<Pedido>, IPedidoService
    {
        private readonly IUnitOfWork _uow;

        public PedidoService(IUnitOfWork uow) : base(uow.PedidoRepository, uow)
        {
            _uow = uow;
        }

        public override Pedido Add(Pedido entity)
        {
            var pedido = LoadEntity(entity);

            pedido.Tamanho = null;
            pedido.Sabor = null;
            pedido.Personalizacoes.ToList().ForEach(p => p.Personalizacao = null);

            return GetById(base.Add(pedido).Id);
        }

        public override IEnumerable<Pedido> GetAll()
        {
            var todosPedidos = base.GetAll().ToList();
            var pedidos = new List<Pedido>();

            foreach (var pedido in todosPedidos)
                pedidos.Add(LoadEntity(pedido));

            return pedidos;
        }

        public override Pedido GetById(int id)
        {
            return LoadEntity(base.GetById(id));
        }

        private Pedido LoadEntity(Pedido entity)
        {
            if (entity == null)
                return null;

            var pedido = new Pedido
            {
                Id = entity.Id,
                TamanhoId = entity.TamanhoId,
                Tamanho = _uow.TamanhoRepository.GetById(entity.TamanhoId),
                SaborId = entity.SaborId,
                Sabor = _uow.SaborRepository.GetById(entity.SaborId),
                Personalizacoes = LoadEntity(entity.Personalizacoes)
            };

            pedido.CalcularTempoPreparoTotal();
            pedido.CalcularValorTotal();

            return pedido;
        }

        private IEnumerable<PedidoPersonalizacao> LoadEntity(IEnumerable<PedidoPersonalizacao> pedidoPersonalizacoes)
        {
            var personalizacoes = new List<PedidoPersonalizacao>();

            foreach (var pedidoPersonalizacao in pedidoPersonalizacoes)
            {
                personalizacoes.Add(new PedidoPersonalizacao
                {
                    Id = pedidoPersonalizacao.Id,
                    PedidoId = pedidoPersonalizacao.PedidoId,
                    PersonalizacaoId = pedidoPersonalizacao.PersonalizacaoId,
                    Personalizacao = _uow.PersonalizacaoRepository.GetById(pedidoPersonalizacao.PersonalizacaoId)
                });
            }

            return personalizacoes;
        }
    }
}