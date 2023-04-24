using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class removeisAktiviran : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAktiviran",
                table: "Korisnik");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAktiviran",
                table: "Korisnik",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
