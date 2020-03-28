using Acai.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acai.Infra.Context
{
    public class Seed
    {
        public void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sabor>()
                .HasData(new Sabor[]
                {
                    new Sabor
                    {
                        Id = 1,
                        Descricao = "Morango"
                    },
                    new Sabor
                    {
                        Id = 2,
                        Descricao = "Banana"
                    },
                    new Sabor
                    {
                        Id = 3,
                        Descricao = "Kiwi",
                        TempoPreparoAdicional = 5
                    }
                });
        }
    }
}