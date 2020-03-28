using Acai.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acai.Infra.Context.Configs
{
    public class SaborConfig
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sabor>().ToTable("Sabor");
            modelBuilder.Entity<Sabor>().HasKey(s => s.Id);
            modelBuilder.Entity<Sabor>().Property(s => s.Id).IsRequired().UseIdentityColumn();
            modelBuilder.Entity<Sabor>().Property(s => s.Descricao).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Sabor>().Property(s => s.TempoPreparoAdicional).IsRequired();
        }
    }
}