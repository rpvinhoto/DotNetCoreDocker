using System.Collections.Generic;

namespace Acai.Domain.Entities
{
    public class Personalizacao
    {
        public int Id { get; set; }
        public decimal ValorAdicional { get; set; }
        public double TempoPreparoAdicional { get; set; }

        public virtual IEnumerable<ProdutoPersonalizacao> ProdutoPersonalizacoes { get; set; }
    }
}