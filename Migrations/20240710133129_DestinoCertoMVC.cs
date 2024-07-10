using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DestinoCertoMVC.Migrations
{
    public partial class DestinoCertoMVC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pacotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Origem = table.Column<string>(nullable: true),
                    Destino = table.Column<string>(nullable: true),
                    Atrativos = table.Column<string>(nullable: true),
                    Saida = table.Column<DateTime>(nullable: false),
                    Retorno = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pacotes_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pacotes_UsuarioId",
                table: "pacotes",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pacotes");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
