using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaDanych.Migrations
{
    /// <inheritdoc />
    public partial class PonowneSlCechaPojazduManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SlCechyPojazdow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CechaPojazdu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlCechyPojazdow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PojazdSlCechaPojazdu",
                columns: table => new
                {
                    PojazdsIdPojazd = table.Column<int>(type: "int", nullable: false),
                    SlCechaPojazdusId = table.Column<int>(type: "int", nullable: false),
                    PojazdyId = table.Column<int>(type: "int", nullable: false),
                    SlCechyPojazdowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PojazdSlCechaPojazdu", x => new { x.PojazdsIdPojazd, x.SlCechaPojazdusId });
                    table.ForeignKey(
                        name: "FK_PojazdSlCechaPojazdu_Pojazdy_PojazdsIdPojazd",
                        column: x => x.PojazdsIdPojazd,
                        principalTable: "Pojazdy",
                        principalColumn: "IdPojazd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PojazdSlCechaPojazdu_SlCechyPojazdow_SlCechaPojazdusId",
                        column: x => x.SlCechaPojazdusId,
                        principalTable: "SlCechyPojazdow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PojazdSlCechaPojazdu_SlCechaPojazdusId",
                table: "PojazdSlCechaPojazdu",
                column: "SlCechaPojazdusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PojazdSlCechaPojazdu");

            migrationBuilder.DropTable(
                name: "SlCechyPojazdow");
        }
    }
}
