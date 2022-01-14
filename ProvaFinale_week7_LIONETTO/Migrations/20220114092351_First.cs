using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvaFinale_week7_LIONETTO.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CodiceFiscale = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CodiceFiscale);
                });

            migrationBuilder.CreateTable(
                name: "Polizza",
                columns: table => new
                {
                    NumeroPolizza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataStipula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImportoAssicurazione = table.Column<float>(type: "real", nullable: false),
                    RataMensile = table.Column<float>(type: "real", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "nchar(16)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PercentualeCopertura = table.Column<int>(type: "int", nullable: true),
                    Targa = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Cilindrata = table.Column<int>(type: "int", nullable: true),
                    AnniAssicurato = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polizza", x => x.NumeroPolizza);
                    table.ForeignKey(
                        name: "FkCliente",
                        column: x => x.CodiceFiscale,
                        principalTable: "Cliente",
                        principalColumn: "CodiceFiscale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polizza_CodiceFiscale",
                table: "Polizza",
                column: "CodiceFiscale");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polizza");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
