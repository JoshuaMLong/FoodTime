using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTime.Migrations
{
    public partial class pastryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastries_PastryTypes_PastryTypeId",
                table: "Pastries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PastryTypes",
                table: "PastryTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pastries",
                table: "Pastries");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pastries");

            migrationBuilder.RenameTable(
                name: "PastryTypes",
                newName: "PastryType");

            migrationBuilder.RenameTable(
                name: "Pastries",
                newName: "Pastry");

            migrationBuilder.RenameIndex(
                name: "IX_Pastries_PastryTypeId",
                table: "Pastry",
                newName: "IX_Pastry_PastryTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PastryType",
                table: "PastryType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pastry_PastryType_PastryTypeId",
                table: "Pastry",
                column: "PastryTypeId",
                principalTable: "PastryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastry_PastryType_PastryTypeId",
                table: "Pastry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PastryType",
                table: "PastryType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry");

            migrationBuilder.RenameTable(
                name: "PastryType",
                newName: "PastryTypes");

            migrationBuilder.RenameTable(
                name: "Pastry",
                newName: "Pastries");

            migrationBuilder.RenameIndex(
                name: "IX_Pastry_PastryTypeId",
                table: "Pastries",
                newName: "IX_Pastries_PastryTypeId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Pastries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PastryTypes",
                table: "PastryTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pastries",
                table: "Pastries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pastries_PastryTypes_PastryTypeId",
                table: "Pastries",
                column: "PastryTypeId",
                principalTable: "PastryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
