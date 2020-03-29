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

            modelBuilder.Entity<Tamanho>()
                .HasData(new Tamanho[]
                {
                    new Tamanho
                    {
                        Id = 1,
                        Descricao = "Pequeno",
                        TempoPreparo = 5,
                        Valor = 10
                    },
                    new Tamanho
                    {
                        Id = 2,
                        Descricao = "Médio",
                        TempoPreparo = 7,
                        Valor = 13
                    },
                    new Tamanho
                    {
                        Id = 3,
                        Descricao = "Grande",
                        TempoPreparo = 10,
                        Valor = 15
                    }
                });

            modelBuilder.Entity<Personalizacao>()
                .HasData(new Personalizacao[]
                {
                    new Personalizacao
                    {
                        Id = 1,
                        Descricao = "Leite ninho",
                        TempoPreparoAdicional = 0,
                        ValorAdicional = 3
                    },
                    new Personalizacao
                    {
                        Id = 2,
                        Descricao = "Granola",
                        TempoPreparoAdicional = 0,
                        ValorAdicional = 0
                    },
                    new Personalizacao
                    {
                        Id = 3,
                        Descricao = "Paçoca",
                        TempoPreparoAdicional = 3,
                        ValorAdicional = 3
                    }
                });
        }
    }
}