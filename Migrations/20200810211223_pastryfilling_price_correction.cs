using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTime.Migrations
{
    public partial class pastryfilling_price_correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "PastryFilling",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "PastryFilling",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
