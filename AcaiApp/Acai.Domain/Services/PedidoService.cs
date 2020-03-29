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

        public override void Add(Pedido entity)
        {
            entity.Tamanho = _uow.TamanhoRepository.GetById(entity.TamanhoId);
            entity.Sabor = _uow.SaborRepository.GetById(entity.SaborId);
            entity.Personalizacoes.ToList().ForEach(p => p.Personalizacao = _uow.PersonalizacaoRepository.GetById(p.PersonalizacaoId));

            entity.CalcularTempoPreparoTotal();
            entity.CalcularValorTotal();

            entity.Tamanho = null;
            entity.Sabor = null;
            entity.Personalizacoes.ToList().ForEach(p => p.Personalizacao = null);

            base.Add(entity);
        }
    }
}