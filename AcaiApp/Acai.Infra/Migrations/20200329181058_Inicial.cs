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
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TamanhoId = table.Column<int>(nullable: false),
                    SaborId = table.Column<int>(nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    TempoPreparoTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Sabor_SaborId",
                        column: x => x.SaborId,
                        principalTable: "Sabor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Tamanho_TamanhoId",
                        column: x => x.TamanhoId,
                        principalTable: "Tamanho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoPersonalizacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<int>(nullable: false),
                    PersonalizacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoPersonalizacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoPersonalizacao_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoPersonalizacao_Personalizacao_PersonalizacaoId",
                        column: x => x.PersonalizacaoId,
                        principalTable: "Personalizacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Pedido_SaborId",
                table: "Pedido",
                column: "SaborId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_TamanhoId",
                table: "Pedido",
                column: "TamanhoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPersonalizacao_PedidoId",
                table: "PedidoPersonalizacao",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPersonalizacao_PersonalizacaoId",
                table: "PedidoPersonalizacao",
                column: "PersonalizacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoPersonalizacao");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Personalizacao");

            migrationBuilder.DropTable(
                name: "Sabor");

            migrationBuilder.DropTable(
                name: "Tamanho");
        }
    }
}
