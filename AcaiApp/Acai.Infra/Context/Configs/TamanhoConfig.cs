using Acai.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acai.Infra.Context.Configs
{
    public class TamanhoConfig
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tamanho>().ToTable("Tamanho");
            modelBuilder.Entity<Tamanho>().HasKey(t => t.Id);
            modelBuilder.Entity<Tamanho>().Property(t => t.Id).IsRequired().UseIdentityColumn();
            modelBuilder.Entity<Tamanho>().Property(t => t.Descricao).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Tamanho>().Property(t => t.Valor).IsRequired();
            modelBuilder.Entity<Tamanho>().Property(t => t.TempoPreparo).IsRequired();
        }
    }
}