using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acai.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personalizacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    ValorAdicional = table.Column<decimal>(nullable: false),
                    TempoPreparoAdicional = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personalizacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sabor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    TempoPreparoAdicional = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sabor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tamanho",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    TempoPreparo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamanho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TamanhoId = table.Column<int>(nullable: false),
                    SaborId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Sabor_SaborId",
                        column: x => x.SaborId,
                        principalTable: "Sabor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_Tamanho_TamanhoId",
                        column: x => x.TamanhoId,
                        principalTable: "Tamanho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    TempoPreparoTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoPersonalizacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(nullable: false),
                    PersonalizacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoPersonalizacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoPersonalizacao_Personalizacao_PersonalizacaoId",
                        column: x => x.PersonalizacaoId,
                        principalTable: "Personalizacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoPersonalizacao_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Personalizacao",
                columns: new[] { "Id", "Descricao", "TempoPreparoAdicional", "ValorAdicional" },
                values: new object[,]
                {
                    { 1, "Leite ninho", 0.0, 3m },
                    { 2, "Granola", 0.0, 0m },
                    { 3, "Paçoca", 3.0, 3m }
                });

            migrationBuilder.InsertData(
                table: "Sabor",
                columns: new[] { "Id", "Descricao", "TempoPreparoAdicional" },
                values: new object[,]
                {
                    { 1, "Morango", 0.0 },
                    { 2, "Banana", 0.0 },
                    { 3, "Kiwi", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Tamanho",
                columns: new[] { "Id", "Descricao", "TempoPreparo", "Valor" },
                values: new object[,]
                {
                    { 1, "Pequeno", 5.0, 10m },
                    { 2, "Médio", 7.0, 13m },
                    { 3, "Grande", 10.0, 15m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ProdutoId",
                table: "Pedido",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_SaborId",
                table: "Produto",
                column: "SaborId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_TamanhoId",
                table: "Produto",
                column: "TamanhoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPersonalizacao_PersonalizacaoId",
                table: "ProdutoPersonalizacao",
                column: "PersonalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPersonalizacao_ProdutoId",
                table: "ProdutoPersonalizacao",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "ProdutoPersonalizacao");

            migrationBuilder.DropTable(
                name: "Personalizacao");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Sabor");

            migrationBuilder.DropTable(
                name: "Tamanho");
        }
    }
}
