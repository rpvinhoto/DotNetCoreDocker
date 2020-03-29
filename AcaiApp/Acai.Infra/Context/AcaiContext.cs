using Acai.Domain.Entities;
using Acai.Infra.Context.Configs;
using Microsoft.EntityFrameworkCore;

namespace Acai.Infra.Context
{
    public class AcaiContext : DbContext
    {
        public AcaiContext(DbContextOptions<AcaiContext> options) : base(options)
        {

        }

        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Personalizacao> Personalizacoes { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Sabor> Sabores { get; set; }
        public virtual DbSet<Tamanho> Tamanhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PedidoConfig().Run(modelBuilder);
            new PersonalizacaoConfig().Run(modelBuilder);
            new ProdutoConfig().Run(modelBuilder);
            new SaborConfig().Run(modelBuilder);
            new TamanhoConfig().Run(modelBuilder);

            new Seed().Run(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}