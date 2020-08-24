using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTime.API.Migrations
{
    public partial class clustered_index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pastry_PastryFillingId_PastryTypeId",
                table: "Pastry",
                columns: new[] { "PastryFillingId", "PastryTypeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry");

            migrationBuilder.DropIndex(
                name: "IX_Pastry_PastryFillingId_PastryTypeId",
                table: "Pastry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry",
                columns: new[] { "PastryFillingId", "PastryTypeId" });
        }
    }
}
