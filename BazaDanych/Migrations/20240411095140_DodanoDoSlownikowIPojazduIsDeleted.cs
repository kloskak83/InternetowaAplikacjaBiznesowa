using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaDanych.Migrations
{
    /// <inheritdoc />
    public partial class DodanoDoSlownikowIPojazduIsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SlTypySkrzyniBiegow",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SlTypySilnikow",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SlSegmentyPojazdow",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SlMarkiPojazdow",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SlCechyPojazdow",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pojazdy",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SlTypySkrzyniBiegow");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SlTypySilnikow");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SlSegmentyPojazdow");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SlMarkiPojazdow");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SlCechyPojazdow");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pojazdy");
        }
    }
}
