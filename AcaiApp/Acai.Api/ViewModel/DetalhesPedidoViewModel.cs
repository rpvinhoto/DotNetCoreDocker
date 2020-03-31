using Acai.Domain.Entities;
using System.Collections.Generic;

namespace Acai.Api.ViewModel
{
    public class DetalhesPedidoViewModel
    {
        public string Tamanho { get; set; }
        public string Sabor { get; set; }
        public decimal Valor { get; set; }
        public IEnumerable<DetalhesPersonalizacaoViewModel> Personalizacoes { get; set; }
        public double TempoPreparoTotal { get; set; }
        public decimal ValorTotal { get; set; }

        public DetalhesPedidoViewModel(Pedido pedido)
        {
            if (pedido != null)
            {
                Tamanho = pedido.Tamanho.Descricao;
                Sabor = pedido.Sabor.Descricao;
                Valor = pedido.Tamanho.Valor;
                Personalizacoes = CarregarPersonalizacoes(pedido.Personalizacoes);
                TempoPreparoTotal = pedido.TempoPreparoTotal;
                ValorTotal = pedido.ValorTotal;
            }
        }

        private IEnumerable<DetalhesPersonalizacaoViewModel> CarregarPersonalizacoes(IEnumerable<PedidoPersonalizacao> pedidoPersonalizacoes)
        {
            if (pedidoPersonalizacoes == null)
                return null;

            var personalizacoes = new List<DetalhesPersonalizacaoViewModel>();

            foreach (var personalizacao in pedidoPersonalizacoes)
                personalizacoes.Add(new DetalhesPersonalizacaoViewModel(personalizacao.Personalizacao));

            return personalizacoes;
        }
    }
}
