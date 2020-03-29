using System;
using System.ComponentModel.DataAnnotations;

namespace Acai.Api.ViewModel
{
    public class PedidoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ProdutoId é um campo obrigatório.")]
        public int ProdutoId { get; set; }

        public DateTime DataHora { get; set; }
        public decimal ValorTotal { get; set; }
        public double TempoPreparoTotal { get; set; }
    }
}