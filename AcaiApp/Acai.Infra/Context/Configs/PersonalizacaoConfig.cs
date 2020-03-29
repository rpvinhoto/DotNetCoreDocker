using Acai.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acai.Infra.Context.Configs
{
    public class PersonalizacaoConfig
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personalizacao>()
                .ToTable("Personalizacao");

            modelBuilder.Entity<Personalizacao>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Personalizacao>()
                .Property(p => p.Id)
                .IsRequired()
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Personalizacao>()
                .Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Personalizacao>()
                .Property(p => p.TempoPreparoAdicional)
                .IsRequired();

            modelBuilder.Entity<Personalizacao>()
                .Property(p => p.ValorAdicional)
                .IsRequired();
        }
    }
}