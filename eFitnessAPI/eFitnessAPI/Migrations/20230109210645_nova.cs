using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class nova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clanarina_Clan_clan_id",
                table: "Clanarina");

            migrationBuilder.DropIndex(
                name: "IX_Clanarina_clan_id",
                table: "Clanarina");

            migrationBuilder.DropColumn(
                name: "clan_id",
                table: "Clanarina");

            migrationBuilder.AddColumn<int>(
                name: "clanarina_id",
                table: "Clan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clan_clanarina_id",
                table: "Clan",
                column: "clanarina_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clan_Clanarina_clanarina_id",
                table: "Clan",
                column: "clanarina_id",
                principalTable: "Clanarina",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clan_Clanarina_clanarina_id",
                table: "Clan");

            migrationBuilder.DropIndex(
                name: "IX_Clan_clanarina_id",
                table: "Clan");

            migrationBuilder.DropColumn(
                name: "clanarina_id",
                table: "Clan");

            migrationBuilder.AddColumn<int>(
                name: "clan_id",
                table: "Clanarina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clanarina_clan_id",
                table: "Clanarina",
                column: "clan_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clanarina_Clan_clan_id",
                table: "Clanarina",
                column: "clan_id",
                principalTable: "Clan",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
