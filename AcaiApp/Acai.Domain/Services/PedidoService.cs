using Acai.Domain.Entities;
using Acai.Domain.Interfaces.Repositories;
using Acai.Domain.Interfaces.Services;
using System;
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

            var tamanho = _uow.TamanhoRepository.GetById(entity.TamanhoId);

            if (tamanho == null)
                throw new InvalidOperationException("Tamanho não encontrado.");

            var sabor = _uow.SaborRepository.GetById(entity.SaborId);

            if (sabor == null)
                throw new InvalidOperationException("Sabor não encontrado.");

            var pedido = new Pedido
            {
                Id = entity.Id,
                TamanhoId = entity.TamanhoId,
                Tamanho = tamanho,
                SaborId = entity.SaborId,
                Sabor = sabor,
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
                var personalizacao = _uow.PersonalizacaoRepository.GetById(pedidoPersonalizacao.PersonalizacaoId);

                if (personalizacao == null)
                    throw new InvalidOperationException("Personalização não encontrada.");

                personalizacoes.Add(new PedidoPersonalizacao
                {
                    Id = pedidoPersonalizacao.Id,
                    PedidoId = pedidoPersonalizacao.PedidoId,
                    PersonalizacaoId = pedidoPersonalizacao.PersonalizacaoId,
                    Personalizacao = personalizacao
                });
            }

            return personalizacoes;
        }
    }
}