using Acai.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acai.Infra.Context.Configs
{
    public class ProdutoPersonalizacaoConfig
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoPersonalizacao>()
                .ToTable("ProdutoPersonalizacao");

            modelBuilder.Entity<ProdutoPersonalizacao>()
                .HasKey(pp => pp.Id);

            modelBuilder.Entity<ProdutoPersonalizacao>()
                .HasOne(pp => pp.Produto)
                .WithMany(p => p.ProdutoPersonalizacoes)
                .HasForeignKey(pp => pp.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProdutoPersonalizacao>()
                .HasOne(pp => pp.Personalizacao)
                .WithMany(p => p.ProdutoPersonalizacoes)
                .HasForeignKey(pp => pp.PersonalizacaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}