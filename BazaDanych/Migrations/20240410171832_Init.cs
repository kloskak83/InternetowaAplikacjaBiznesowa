using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaDanych.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SlCechyPojazdow",
                columns: table => new
                {
                    IdSlCechaPojazdu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CechaPojazdu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlCechyPojazdow", x => x.IdSlCechaPojazdu);
                });

            migrationBuilder.CreateTable(
                name: "SlMarkiPojazdow",
                columns: table => new
                {
                    IdSlMarka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaPojazdu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlMarkiPojazdow", x => x.IdSlMarka);
                });

            migrationBuilder.CreateTable(
                name: "SlSegmentyPojazdow",
                columns: table => new
                {
                    IdSlSegmentPojazdu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaSegmentuPojazdu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlSegmentyPojazdow", x => x.IdSlSegmentPojazdu);
                });

            migrationBuilder.CreateTable(
                name: "SlTypySilnikow",
                columns: table => new
                {
                    IdSlTypSilnika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaTypuSilnika = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlTypySilnikow", x => x.IdSlTypSilnika);
                });

            migrationBuilder.CreateTable(
                name: "SlTypySkrzyniBiegow",
                columns: table => new
                {
                    IdSlTypSkrzyniBiegow = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaTypuSkrzyniBiegow = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlTypySkrzyniBiegow", x => x.IdSlTypSkrzyniBiegow);
                });

            migrationBuilder.CreateTable(
                name: "Pojazdy",
                columns: table => new
                {
                    IdPojazd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSlownikMarka = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NazwaWSerwisie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdTypSilnika = table.Column<int>(type: "int", nullable: false),
                    IdTypSkrzyniBiegow = table.Column<int>(type: "int", nullable: false),
                    IdSegmentPojazdu = table.Column<int>(type: "int", nullable: false),
                    CzyMaKlimatyzacje = table.Column<bool>(type: "bit", nullable: false),
                    PojemnoscSilnika = table.Column<float>(type: "real", nullable: false),
                    MocSilnika = table.Column<float>(type: "real", nullable: false),
                    SpalanieMiejskie = table.Column<float>(type: "real", nullable: false),
                    IloscPoduszek = table.Column<int>(type: "int", nullable: false),
                    IloscDrzwi = table.Column<int>(type: "int", nullable: false),
                    CzyMaABS = table.Column<bool>(type: "bit", nullable: false),
                    CzyMaElektryczneSzyby = table.Column<bool>(type: "bit", nullable: false),
                    CzyMaElektryczneLusterka = table.Column<bool>(type: "bit", nullable: false),
                    CzyMaPodgrzewaneLusterka = table.Column<bool>(type: "bit", nullable: false),
                    CzyMaKomputerPokladowy = table.Column<bool>(type: "bit", nullable: false),
                    CzyMaCentralnyZamek = table.Column<bool>(type: "bit", nullable: false),
                    DataProdukcji = table.Column<DateOnly>(type: "date", nullable: false),
                    OpisPojazdu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojazdy", x => x.IdPojazd);
                    table.ForeignKey(
                        name: "FK_Pojazdy_SlMarkiPojazdow_IdSlownikMarka",
                        column: x => x.IdSlownikMarka,
                        principalTable: "SlMarkiPojazdow",
                        principalColumn: "IdSlMarka",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pojazdy_SlSegmentyPojazdow_IdSegmentPojazdu",
                        column: x => x.IdSegmentPojazdu,
                        principalTable: "SlSegmentyPojazdow",
                        principalColumn: "IdSlSegmentPojazdu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pojazdy_SlTypySilnikow_IdTypSilnika",
                        column: x => x.IdTypSilnika,
                        principalTable: "SlTypySilnikow",
                        principalColumn: "IdSlTypSilnika",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pojazdy_SlTypySkrzyniBiegow_IdTypSkrzyniBiegow",
                        column: x => x.IdTypSkrzyniBiegow,
                        principalTable: "SlTypySkrzyniBiegow",
                        principalColumn: "IdSlTypSkrzyniBiegow",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PojazdSlCechaPojazdu",
                columns: table => new
                {
                    PojazdyId = table.Column<int>(type: "int", nullable: false),
                    SlCechyPojazdowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PojazdSlCechaPojazdu", x => new { x.PojazdyId, x.SlCechyPojazdowId });
                    table.ForeignKey(
                        name: "FK_PojazdSlCechaPojazdu_Pojazdy_PojazdyId",
                        column: x => x.PojazdyId,
                        principalTable: "Pojazdy",
                        principalColumn: "IdPojazd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PojazdSlCechaPojazdu_SlCechyPojazdow_SlCechyPojazdowId",
                        column: x => x.SlCechyPojazdowId,
                        principalTable: "SlCechyPojazdow",
                        principalColumn: "IdSlCechaPojazdu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PojazdSlCechaPojazdu_SlCechyPojazdowId",
                table: "PojazdSlCechaPojazdu",
                column: "SlCechyPojazdowId");

            migrationBuilder.CreateIndex(
                name: "IX_Pojazdy_IdSegmentPojazdu",
                table: "Pojazdy",
                column: "IdSegmentPojazdu");

            migrationBuilder.CreateIndex(
                name: "IX_Pojazdy_IdSlownikMarka",
                table: "Pojazdy",
                column: "IdSlownikMarka");

            migrationBuilder.CreateIndex(
                name: "IX_Pojazdy_IdTypSilnika",
                table: "Pojazdy",
                column: "IdTypSilnika");

            migrationBuilder.CreateIndex(
                name: "IX_Pojazdy_IdTypSkrzyniBiegow",
                table: "Pojazdy",
                column: "IdTypSkrzyniBiegow");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PojazdSlCechaPojazdu");

            migrationBuilder.DropTable(
                name: "Pojazdy");

            migrationBuilder.DropTable(
                name: "SlCechyPojazdow");

            migrationBuilder.DropTable(
                name: "SlMarkiPojazdow");

            migrationBuilder.DropTable(
                name: "SlSegmentyPojazdow");

            migrationBuilder.DropTable(
                name: "SlTypySilnikow");

            migrationBuilder.DropTable(
                name: "SlTypySkrzyniBiegow");
        }
    }
}
