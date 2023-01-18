using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class novaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slika_base64",
                table: "Suplement");

            migrationBuilder.AddColumn<byte[]>(
                name: "slika_suplement_bytes",
                table: "Suplement",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "slika_suplement_fs",
                table: "Suplement",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slika_suplement_bytes",
                table: "Suplement");

            migrationBuilder.DropColumn(
                name: "slika_suplement_fs",
                table: "Suplement");

            migrationBuilder.AddColumn<byte[]>(
                name: "slika_base64",
                table: "Suplement",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
