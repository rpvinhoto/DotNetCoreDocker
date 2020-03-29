using System.Collections.Generic;

namespace Acai.Domain.Entities
{
    public class Tamanho
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public double TempoPreparo { get; set; }

        public IEnumerable<Pedido> Pedidos { get; set; }
    }
}