using System;
using System.Collections.Generic;
using System.Linq;

namespace Acai.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int TamanhoId { get; set; }
        public int SaborId { get; set; }
        public DateTime DataHora { get; private set; }
        public decimal ValorTotal { get; private set; }
        public double TempoPreparoTotal { get; private set; }

        public Tamanho Tamanho { get; set; }
        public Sabor Sabor { get; set; }
        public IEnumerable<PedidoPersonalizacao> Personalizacoes { get; set; }

        public Pedido()
        {
            DataHora = DateTime.Now;
        }

        public void CalcularValorTotal()
        {
            ValorTotal = Tamanho.Valor 
                + Personalizacoes.Sum(p => p.Personalizacao.ValorAdicional);
        }

        public void CalcularTempoPreparoTotal()
        {
            TempoPreparoTotal = Tamanho.TempoPreparo 
                + Sabor.TempoPreparoAdicional 
                + Personalizacoes.Sum(p => p.Personalizacao.TempoPreparoAdicional);
        }
    }
}