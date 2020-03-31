using System.Collections.Generic;
using System.Linq;

namespace Acai.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int TamanhoId { get; set; }
        public int SaborId { get; set; }
        public decimal ValorTotal { get; private set; }
        public double TempoPreparoTotal { get; private set; }

        public Tamanho Tamanho { get; set; }
        public Sabor Sabor { get; set; }
        public IEnumerable<PedidoPersonalizacao> Personalizacoes { get; set; }

        public void CalcularValorTotal()
        {
            var valorTamanho = Tamanho?.Valor;
            var valorPersonalizacoes = Personalizacoes?.Sum(p => p.Personalizacao?.ValorAdicional);

            ValorTotal = (valorTamanho ?? 0)
                + (valorPersonalizacoes ?? 0);
        }

        public void CalcularTempoPreparoTotal()
        {
            var tempoTamanho = Tamanho?.TempoPreparo;
            var tempoSabor = Sabor?.TempoPreparoAdicional;
            var tempoPersonalizacoes = Personalizacoes?.Sum(p => p.Personalizacao?.TempoPreparoAdicional);

            TempoPreparoTotal = (tempoTamanho ?? 0)
                + (tempoSabor ?? 0)
                + (tempoPersonalizacoes ?? 0);
        }
    }
}