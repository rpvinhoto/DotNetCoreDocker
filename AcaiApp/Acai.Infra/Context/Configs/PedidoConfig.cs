using Acai.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acai.Infra.Context.Configs
{
    public class PedidoConfig
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .ToTable("Pedido");

            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Id)
                .IsRequired()
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Pedido>()
                .Property(p => p.ValorTotal)
                .IsRequired();

            modelBuilder.Entity<Pedido>()
                .Property(p => p.TempoPreparoTotal)
                .IsRequired();

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Tamanho)
                .WithMany(t => t.Pedidos)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Sabor)
                .WithMany(s => s.Pedidos)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}