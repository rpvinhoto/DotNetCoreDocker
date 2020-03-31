﻿// <auto-generated />
using Acai.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Acai.Infra.Migrations
{
    [DbContext(typeof(AcaiContext))]
    partial class AcaiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Acai.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SaborId");

                    b.Property<int>("TamanhoId");

                    b.Property<double>("TempoPreparoTotal");

                    b.Property<decimal>("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("SaborId");

                    b.HasIndex("TamanhoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Acai.Domain.Entities.PedidoPersonalizacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PedidoId");

                    b.Property<int>("PersonalizacaoId");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("PersonalizacaoId");

                    b.ToTable("PedidoPersonalizacao");
                });

            modelBuilder.Entity("Acai.Domain.Entities.Personalizacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<double>("TempoPreparoAdicional");

                    b.Property<decimal>("ValorAdicional");

                    b.HasKey("Id");

                    b.ToTable("Personalizacao");

                    b.HasData(
                        new { Id = 1, Descricao = "Leite ninho", TempoPreparoAdicional = 0.0, ValorAdicional = 3m },
                        new { Id = 2, Descricao = "Granola", TempoPreparoAdicional = 0.0, ValorAdicional = 0m },
                        new { Id = 3, Descricao = "Paçoca", TempoPreparoAdicional = 3.0, ValorAdicional = 3m }
                    );
                });

            modelBuilder.Entity("Acai.Domain.Entities.Sabor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<double>("TempoPreparoAdicional");

                    b.HasKey("Id");

                    b.ToTable("Sabor");

                    b.HasData(
                        new { Id = 1, Descricao = "Morango", TempoPreparoAdicional = 0.0 },
                        new { Id = 2, Descricao = "Banana", TempoPreparoAdicional = 0.0 },
                        new { Id = 3, Descricao = "Kiwi", TempoPreparoAdicional = 5.0 }
                    );
                });

            modelBuilder.Entity("Acai.Domain.Entities.Tamanho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<double>("TempoPreparo");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Tamanho");

                    b.HasData(
                        new { Id = 1, Descricao = "Pequeno", TempoPreparo = 5.0, Valor = 10m },
                        new { Id = 2, Descricao = "Médio", TempoPreparo = 7.0, Valor = 13m },
                        new { Id = 3, Descricao = "Grande", TempoPreparo = 10.0, Valor = 15m }
                    );
                });

            modelBuilder.Entity("Acai.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("Acai.Domain.Entities.Sabor", "Sabor")
                        .WithMany("Pedidos")
                        .HasForeignKey("SaborId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Acai.Domain.Entities.Tamanho", "Tamanho")
                        .WithMany("Pedidos")
                        .HasForeignKey("TamanhoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Acai.Domain.Entities.PedidoPersonalizacao", b =>
                {
                    b.HasOne("Acai.Domain.Entities.Pedido", "Pedido")
                        .WithMany("Personalizacoes")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Acai.Domain.Entities.Personalizacao", "Personalizacao")
                        .WithMany("PedidoPersonalizacoes")
                        .HasForeignKey("PersonalizacaoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
