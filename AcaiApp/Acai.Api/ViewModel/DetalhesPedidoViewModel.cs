using System.Collections.Generic;

namespace Acai.Api.ViewModel
{
    public class DetalhesPedidoViewModel
    {
        public int TamanhoId { get; set; }
        public int SaborId { get; set; }
        public decimal ValorTotal { get; set; }
        public double TempoPreparoTotal { get; set; }
        public IEnumerable<PedidoPersonalizacaoViewModel> Personalizacoes { get; set; }
    }
}
