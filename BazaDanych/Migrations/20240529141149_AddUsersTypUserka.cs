using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaDanych.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersTypUserka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SlTypUzytkownik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUprawnienia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OpisUprawnieniaUzytkownika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlTypUzytkownik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TelefonKontaktowy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ZamieszkanieAdres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZamieszkanieMiasto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZamieszkanieKodPoczotwy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    KorespondencyjnyAdres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    KorespondencyjnyMiasto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    KoresponedncyjnyKodPocztowy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FirmaNazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FirmaNip = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    FirmaAdres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FirmaMiasto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FirmaKodPocztowy = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdSlTypUzytkownika = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_SlTypUzytkownik_IdSlTypUzytkownika",
                        column: x => x.IdSlTypUzytkownika,
                        principalTable: "SlTypUzytkownik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_IdSlTypUzytkownika",
                table: "Uzytkownicy",
                column: "IdSlTypUzytkownika");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "SlTypUzytkownik");
        }
    }
}
