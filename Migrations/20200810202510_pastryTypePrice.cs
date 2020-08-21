using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTime.API.Migrations
{
    public partial class pastryTypePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastries_PastryType_PastryTypeId",
                table: "Pastries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PastryType",
                table: "PastryType");

            migrationBuilder.RenameTable(
                name: "PastryType",
                newName: "PastryTypes");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PastryTypes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PastryTypes",
                table: "PastryTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pastries_PastryTypes_PastryTypeId",
                table: "Pastries",
                column: "PastryTypeId",
                principalTable: "PastryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastries_PastryTypes_PastryTypeId",
                table: "Pastries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PastryTypes",
                table: "PastryTypes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PastryTypes");

            migrationBuilder.RenameTable(
                name: "PastryTypes",
                newName: "PastryType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PastryType",
                table: "PastryType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pastries_PastryType_PastryTypeId",
                table: "Pastries",
                column: "PastryTypeId",
                principalTable: "PastryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
