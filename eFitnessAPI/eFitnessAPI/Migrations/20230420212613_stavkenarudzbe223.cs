using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class stavkenarudzbe223 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "AktivacijskiToken");

            migrationBuilder.AddColumn<bool>(
                name: "kupljeno",
                table: "Narudzba",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Korisnik",
                table: "AktivacijskiToken",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kupljeno",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "Korisnik",
                table: "AktivacijskiToken");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "AktivacijskiToken",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
