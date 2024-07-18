using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaDanych.Migrations
{
    /// <inheritdoc />
    public partial class DodanoPolaDlaMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuGornes",
                columns: table => new
                {
                    IdMenuGorne = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NaglowekIntranet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NazwaPortal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypPolaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGornes", x => x.IdMenuGorne);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuGornes");
        }
    }
}
