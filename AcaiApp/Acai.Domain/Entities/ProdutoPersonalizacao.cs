namespace Acai.Domain.Entities
{
    public class ProdutoPersonalizacao
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int PersonalizacaoId { get; set; }

        public Produto Produto { get; set; }
        public Personalizacao Personalizacao { get; set; }
    }
}