using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaDanych.Migrations
{
    /// <inheritdoc />
    public partial class UtworzonoKlasyZRejestremWypozyczen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "KosztWypozyczeniaDoba",
                table: "Pojazdy",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "StatusWypozyczenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaWypozyczenia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OpisPozycji = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusWypozyczenia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RejestrWypozyczens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPojazd = table.Column<int>(type: "int", nullable: false),
                    IdNazwaStatusuWypozyczenia = table.Column<int>(type: "int", nullable: false),
                    StatusWypozyczeniaId = table.Column<int>(type: "int", nullable: false),
                    IdUzytkownik = table.Column<int>(type: "int", nullable: false),
                    WypozyczenieOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WypozyczenieDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejestrWypozyczens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RejestrWypozyczens_Pojazdy_IdPojazd",
                        column: x => x.IdPojazd,
                        principalTable: "Pojazdy",
                        principalColumn: "IdPojazd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RejestrWypozyczens_StatusWypozyczenia_StatusWypozyczeniaId",
                        column: x => x.StatusWypozyczeniaId,
                        principalTable: "StatusWypozyczenia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RejestrWypozyczens_Uzytkownicy_IdUzytkownik",
                        column: x => x.IdUzytkownik,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RejestrWypozyczens_IdPojazd",
                table: "RejestrWypozyczens",
                column: "IdPojazd");

            migrationBuilder.CreateIndex(
                name: "IX_RejestrWypozyczens_IdUzytkownik",
                table: "RejestrWypozyczens",
                column: "IdUzytkownik");

            migrationBuilder.CreateIndex(
                name: "IX_RejestrWypozyczens_StatusWypozyczeniaId",
                table: "RejestrWypozyczens",
                column: "StatusWypozyczeniaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RejestrWypozyczens");

            migrationBuilder.DropTable(
                name: "StatusWypozyczenia");

            migrationBuilder.DropColumn(
                name: "KosztWypozyczeniaDoba",
                table: "Pojazdy");
        }
    }
}
