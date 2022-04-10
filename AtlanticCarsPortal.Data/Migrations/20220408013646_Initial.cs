using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtlanticCarsPortal.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    KMPerLiter = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    TankCapacity = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    QtdTankLiter = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    AverageSpeed = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    CarType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AverageSpeed", "CarType", "KMPerLiter", "Model", "Price", "QtdTankLiter", "TankCapacity" },
                values: new object[,]
                {
                    { 1, 205m, 1, 12m, "Toyota Corolla", 140000m, 20m, 50m },
                    { 2, 167m, 1, 12.9m, "Chevrolet Onix", 75000m, 30m, 54m },
                    { 3, 180m, 1, 12.9m, "Chevrolet Prisma", 65000m, 35m, 54m },
                    { 4, 177m, 2, 11.1m, "Volkswagen Gol", 73000m, 35m, 55m },
                    { 5, 185m, 1, 11.1m, "Volkswagen Voyage", 85000m, 35m, 55m },
                    { 6, 187m, 1, 10.1m, "Fiat Palio", 55000m, 25m, 48m },
                    { 7, 184m, 3, 10.1m, "Fiat Argo", 80000m, 15m, 48m },
                    { 8, 195m, 1, 10.1m, "Fiat Toro", 180000m, 40m, 60m },
                    { 9, 180m, 1, 9m, "Toyota Hilux", 285000m, 40m, 80m },
                    { 10, 180m, 1, 9m, "Toyota SW4", 386000m, 40m, 80m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
