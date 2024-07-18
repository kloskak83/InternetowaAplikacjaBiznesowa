using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaDanych.Migrations
{
    /// <inheritdoc />
    public partial class DodanoPolaDlaMenuUzupelnionoIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "MenuGornes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuGornes");
        }
    }
}
