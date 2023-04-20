using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class kor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "korisnik_id",
                table: "Narudzba",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_korisnik_id",
                table: "Narudzba",
                column: "korisnik_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Korisnik_korisnik_id",
                table: "Narudzba",
                column: "korisnik_id",
                principalTable: "Korisnik",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Korisnik_korisnik_id",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_korisnik_id",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "korisnik_id",
                table: "Narudzba");
        }
    }
}
