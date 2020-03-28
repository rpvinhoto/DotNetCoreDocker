using Acai.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acai.Infra.Context.Configs
{
    public class ProdutoConfig
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Produto>().Property(p => p.Id).IsRequired().UseIdentityColumn();
            modelBuilder.Entity<Produto>().HasOne(p => p.Tamanho).WithMany(t => t.Produtos).IsRequired();
            modelBuilder.Entity<Produto>().HasOne(p => p.Sabor).WithMany(s => s.Produtos).IsRequired();

        }
    }
}