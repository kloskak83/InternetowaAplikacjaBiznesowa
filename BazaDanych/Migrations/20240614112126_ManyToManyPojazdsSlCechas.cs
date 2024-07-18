using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaDanych.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyPojazdsSlCechas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PojazdSlCechaPojazdu_Pojazdy_PojazdyId",
                table: "PojazdSlCechaPojazdu");

            migrationBuilder.DropForeignKey(
                name: "FK_PojazdSlCechaPojazdu_SlCechyPojazdow_SlCechyPojazdowId",
                table: "PojazdSlCechaPojazdu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PojazdSlCechaPojazdu",
                table: "PojazdSlCechaPojazdu");

            migrationBuilder.DropIndex(
                name: "IX_PojazdSlCechaPojazdu_SlCechyPojazdowId",
                table: "PojazdSlCechaPojazdu");

            migrationBuilder.AddColumn<int>(
                name: "PojazdsIdPojazd",
                table: "PojazdSlCechaPojazdu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SlCechaPojazdusId",
                table: "PojazdSlCechaPojazdu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PojazdSlCechaPojazdu",
                table: "PojazdSlCechaPojazdu",
                columns: new[] { "PojazdsIdPojazd", "SlCechaPojazdusId" });

            migrationBuilder.CreateIndex(
                name: "IX_PojazdSlCechaPojazdu_SlCechaPojazdusId",
                table: "PojazdSlCechaPojazdu",
                column: "SlCechaPojazdusId");

            migrationBuilder.AddForeignKey(
                name: "FK_PojazdSlCechaPojazdu_Pojazdy_PojazdsIdPojazd",
                table: "PojazdSlCechaPojazdu",
                column: "PojazdsIdPojazd",
                principalTable: "Pojazdy",
                principalColumn: "IdPojazd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PojazdSlCechaPojazdu_SlCechyPojazdow_SlCechaPojazdusId",
                table: "PojazdSlCechaPojazdu",
                column: "SlCechaPojazdusId",
                principalTable: "SlCechyPojazdow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PojazdSlCechaPojazdu_Pojazdy_PojazdsIdPojazd",
                table: "PojazdSlCechaPojazdu");

            migrationBuilder.DropForeignKey(
                name: "FK_PojazdSlCechaPojazdu_SlCechyPojazdow_SlCechaPojazdusId",
                table: "PojazdSlCechaPojazdu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PojazdSlCechaPojazdu",
                table: "PojazdSlCechaPojazdu");

            migrationBuilder.DropIndex(
                name: "IX_PojazdSlCechaPojazdu_SlCechaPojazdusId",
                table: "PojazdSlCechaPojazdu");

            migrationBuilder.DropColumn(
                name: "PojazdsIdPojazd",
                table: "PojazdSlCechaPojazdu");

            migrationBuilder.DropColumn(
                name: "SlCechaPojazdusId",
                table: "PojazdSlCechaPojazdu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PojazdSlCechaPojazdu",
                table: "PojazdSlCechaPojazdu",
                columns: new[] { "PojazdyId", "SlCechyPojazdowId" });

            migrationBuilder.CreateIndex(
                name: "IX_PojazdSlCechaPojazdu_SlCechyPojazdowId",
                table: "PojazdSlCechaPojazdu",
                column: "SlCechyPojazdowId");

            migrationBuilder.AddForeignKey(
                name: "FK_PojazdSlCechaPojazdu_Pojazdy_PojazdyId",
                table: "PojazdSlCechaPojazdu",
                column: "PojazdyId",
                principalTable: "Pojazdy",
                principalColumn: "IdPojazd",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PojazdSlCechaPojazdu_SlCechyPojazdow_SlCechyPojazdowId",
                table: "PojazdSlCechaPojazdu",
                column: "SlCechyPojazdowId",
                principalTable: "SlCechyPojazdow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
