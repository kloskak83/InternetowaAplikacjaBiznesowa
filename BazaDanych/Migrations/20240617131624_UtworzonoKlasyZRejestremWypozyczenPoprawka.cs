using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaDanych.Migrations
{
    /// <inheritdoc />
    public partial class UtworzonoKlasyZRejestremWypozyczenPoprawka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RejestrWypozyczens_StatusWypozyczenia_StatusWypozyczeniaId",
                table: "RejestrWypozyczens");

            migrationBuilder.DropIndex(
                name: "IX_RejestrWypozyczens_StatusWypozyczeniaId",
                table: "RejestrWypozyczens");

            migrationBuilder.DropColumn(
                name: "StatusWypozyczeniaId",
                table: "RejestrWypozyczens");

            migrationBuilder.CreateIndex(
                name: "IX_RejestrWypozyczens_IdNazwaStatusuWypozyczenia",
                table: "RejestrWypozyczens",
                column: "IdNazwaStatusuWypozyczenia");

            migrationBuilder.AddForeignKey(
                name: "FK_RejestrWypozyczens_StatusWypozyczenia_IdNazwaStatusuWypozyczenia",
                table: "RejestrWypozyczens",
                column: "IdNazwaStatusuWypozyczenia",
                principalTable: "StatusWypozyczenia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RejestrWypozyczens_StatusWypozyczenia_IdNazwaStatusuWypozyczenia",
                table: "RejestrWypozyczens");

            migrationBuilder.DropIndex(
                name: "IX_RejestrWypozyczens_IdNazwaStatusuWypozyczenia",
                table: "RejestrWypozyczens");

            migrationBuilder.AddColumn<int>(
                name: "StatusWypozyczeniaId",
                table: "RejestrWypozyczens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RejestrWypozyczens_StatusWypozyczeniaId",
                table: "RejestrWypozyczens",
                column: "StatusWypozyczeniaId");

            migrationBuilder.AddForeignKey(
                name: "FK_RejestrWypozyczens_StatusWypozyczenia_StatusWypozyczeniaId",
                table: "RejestrWypozyczens",
                column: "StatusWypozyczeniaId",
                principalTable: "StatusWypozyczenia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
