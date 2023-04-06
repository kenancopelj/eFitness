using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class addkorisnikuclanarinu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "korisnik_id",
                table: "Clanarina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clanarina_korisnik_id",
                table: "Clanarina",
                column: "korisnik_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clanarina_Korisnik_korisnik_id",
                table: "Clanarina",
                column: "korisnik_id",
                principalTable: "Korisnik",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clanarina_Korisnik_korisnik_id",
                table: "Clanarina");

            migrationBuilder.DropIndex(
                name: "IX_Clanarina_korisnik_id",
                table: "Clanarina");

            migrationBuilder.DropColumn(
                name: "korisnik_id",
                table: "Clanarina");
        }
    }
}
