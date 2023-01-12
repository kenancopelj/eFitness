using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class druga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jeLiClan",
                table: "Clan");

            migrationBuilder.AddColumn<int>(
                name: "cijena",
                table: "VrstaClanarine",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cijena",
                table: "VrstaClanarine");

            migrationBuilder.AddColumn<bool>(
                name: "jeLiClan",
                table: "Clan",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
