using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eFitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class okokorpe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suplement_Narudzba_narudzbaID",
                table: "Suplement");

            migrationBuilder.DropIndex(
                name: "IX_Suplement_narudzbaID",
                table: "Suplement");

            migrationBuilder.DropColumn(
                name: "narudzbaID",
                table: "Suplement");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Narudzba",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    narudzbaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Narudzba_narudzbaID",
                        column: x => x.narudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "narudzbaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_narudzbaID",
                table: "Item",
                column: "narudzbaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.AddColumn<int>(
                name: "narudzbaID",
                table: "Suplement",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Narudzba",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Suplement_narudzbaID",
                table: "Suplement",
                column: "narudzbaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suplement_Narudzba_narudzbaID",
                table: "Suplement",
                column: "narudzbaID",
                principalTable: "Narudzba",
                principalColumn: "narudzbaID");
        }
    }
}
