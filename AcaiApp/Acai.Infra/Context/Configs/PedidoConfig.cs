using Acai.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acai.Infra.Context.Configs
{
    public class PedidoConfig
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().ToTable("Pedido");
            modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
            modelBuilder.Entity<Pedido>().Property(p => p.Id).IsRequired().UseIdentityColumn();
            modelBuilder.Entity<Pedido>().HasOne(p => p.Produto).WithMany(pe => pe.Pedidos).IsRequired();
            modelBuilder.Entity<Pedido>().Property(p => p.DataHora).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Pedido>().Property(p => p.ValorTotal).IsRequired();
            modelBuilder.Entity<Pedido>().Property(p => p.TempoPreparoTotal).IsRequired();
        }
    }
}