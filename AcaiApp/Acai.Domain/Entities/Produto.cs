using System.Collections.Generic;

namespace Acai.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public int TamanhoId { get; set; }
        public int SaborId { get; set; }

        public Tamanho Tamanho { get; set; }
        public Sabor Sabor { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
        public IEnumerable<Personalizacao> Personalizacoes { get; set; }
    }
}