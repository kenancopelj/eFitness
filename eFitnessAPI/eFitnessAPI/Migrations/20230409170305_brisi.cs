using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class brisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suplement_Narudzba_narudzbaId",
                table: "Suplement");

            migrationBuilder.RenameColumn(
                name: "narudzbaId",
                table: "Suplement",
                newName: "narudzbaID");

            migrationBuilder.RenameIndex(
                name: "IX_Suplement_narudzbaId",
                table: "Suplement",
                newName: "IX_Suplement_narudzbaID");

            migrationBuilder.AlterColumn<int>(
                name: "narudzbaID",
                table: "Suplement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Suplement_Narudzba_narudzbaID",
                table: "Suplement",
                column: "narudzbaID",
                principalTable: "Narudzba",
                principalColumn: "narudzbaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suplement_Narudzba_narudzbaID",
                table: "Suplement");

            migrationBuilder.RenameColumn(
                name: "narudzbaID",
                table: "Suplement",
                newName: "narudzbaId");

            migrationBuilder.RenameIndex(
                name: "IX_Suplement_narudzbaID",
                table: "Suplement",
                newName: "IX_Suplement_narudzbaId");

            migrationBuilder.AlterColumn<int>(
                name: "narudzbaId",
                table: "Suplement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Suplement_Narudzba_narudzbaId",
                table: "Suplement",
                column: "narudzbaId",
                principalTable: "Narudzba",
                principalColumn: "narudzbaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
