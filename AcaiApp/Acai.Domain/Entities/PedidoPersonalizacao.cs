namespace Acai.Domain.Entities
{
    public class PedidoPersonalizacao
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int PersonalizacaoId { get; set; }

        public Pedido Pedido { get; set; }
        public Personalizacao Personalizacao { get; set; }
    }
}