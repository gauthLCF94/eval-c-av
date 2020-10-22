using Microsoft.EntityFrameworkCore.Migrations;

namespace Venezia.Migrations
{
    public partial class AddFuel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelType",
                schema: "venezia",
                table: "voitures");

            migrationBuilder.AddColumn<int>(
                name: "FuelTypeID",
                schema: "venezia",
                table: "voitures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fuel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuel", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_voitures_FuelTypeID",
                schema: "venezia",
                table: "voitures",
                column: "FuelTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_voitures_Fuel_FuelTypeID",
                schema: "venezia",
                table: "voitures",
                column: "FuelTypeID",
                principalTable: "Fuel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_voitures_Fuel_FuelTypeID",
                schema: "venezia",
                table: "voitures");

            migrationBuilder.DropTable(
                name: "Fuel");

            migrationBuilder.DropIndex(
                name: "IX_voitures_FuelTypeID",
                schema: "venezia",
                table: "voitures");

            migrationBuilder.DropColumn(
                name: "FuelTypeID",
                schema: "venezia",
                table: "voitures");

            migrationBuilder.AddColumn<int>(
                name: "FuelType",
                schema: "venezia",
                table: "voitures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
