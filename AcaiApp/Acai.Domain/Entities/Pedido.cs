using System;

namespace Acai.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public DateTime DataHora { get; set; }
        public decimal ValorTotal { get; set; }
        public double TempoPreparoTotal { get; set; }

        public Produto Produto { get; set; }
    }
}