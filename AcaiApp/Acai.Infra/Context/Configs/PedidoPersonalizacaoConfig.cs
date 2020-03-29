using Acai.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acai.Infra.Context.Configs
{
    public class PedidoPersonalizacaoConfig
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoPersonalizacao>()
                .ToTable("PedidoPersonalizacao");

            modelBuilder.Entity<PedidoPersonalizacao>()
                .HasKey(pp => pp.Id);

            modelBuilder.Entity<PedidoPersonalizacao>()
                .HasOne(pp => pp.Pedido)
                .WithMany(p => p.Personalizacoes)
                .HasForeignKey(pp => pp.PedidoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PedidoPersonalizacao>()
                .HasOne(pp => pp.Personalizacao)
                .WithMany(p => p.PedidoPersonalizacoes)
                .HasForeignKey(pp => pp.PersonalizacaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}