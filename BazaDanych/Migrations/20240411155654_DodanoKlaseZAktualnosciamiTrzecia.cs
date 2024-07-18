using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaDanych.Migrations
{
    /// <inheritdoc />
    public partial class DodanoKlaseZAktualnosciamiTrzecia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktualnosci",
                columns: table => new
                {
                    AktualnosciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DataAktualnosci = table.Column<DateOnly>(type: "date", nullable: false),
                    Naglowek = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SciezkaDoZdjecia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktualnosci", x => x.AktualnosciId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktualnosci");
        }
    }
}
