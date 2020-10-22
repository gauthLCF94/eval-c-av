using Microsoft.EntityFrameworkCore.Migrations;

namespace Venezia.Migrations
{
    public partial class UpdateCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.EnsureSchema(
                name: "venezia");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "voitures",
                newSchema: "venezia");

            migrationBuilder.RenameColumn(
                name: "Mark",
                schema: "venezia",
                table: "voitures",
                newName: "Marque");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "venezia",
                table: "voitures",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_voitures",
                schema: "venezia",
                table: "voitures",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_voitures",
                schema: "venezia",
                table: "voitures");

            migrationBuilder.RenameTable(
                name: "voitures",
                schema: "venezia",
                newName: "Car");

            migrationBuilder.RenameColumn(
                name: "Marque",
                table: "Car",
                newName: "Mark");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Car",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "ID");
        }
    }
}
