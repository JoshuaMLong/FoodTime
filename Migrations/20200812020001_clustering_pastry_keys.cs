using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTime.Migrations
{
    public partial class clustering_pastry_keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry");

            migrationBuilder.DropIndex(
                name: "IX_Pastry_PastryFillingId",
                table: "Pastry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry",
                columns: new[] { "PastryFillingId", "PastryTypeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pastry_PastryFillingId",
                table: "Pastry",
                column: "PastryFillingId");
        }
    }
}
