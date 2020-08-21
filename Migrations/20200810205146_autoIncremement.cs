using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTime.API.Migrations
{
    public partial class autoIncremement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastry_PastryType_PastryTypeId",
                table: "Pastry");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PastryType",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PastryTypeId",
                table: "Pastry",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PastryFillingId",
                table: "Pastry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PastryFilling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastryFilling", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pastry_PastryFillingId",
                table: "Pastry",
                column: "PastryFillingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pastry_PastryFilling_PastryFillingId",
                table: "Pastry",
                column: "PastryFillingId",
                principalTable: "PastryFilling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pastry_PastryType_PastryTypeId",
                table: "Pastry",
                column: "PastryTypeId",
                principalTable: "PastryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pastry_PastryFilling_PastryFillingId",
                table: "Pastry");

            migrationBuilder.DropForeignKey(
                name: "FK_Pastry_PastryType_PastryTypeId",
                table: "Pastry");

            migrationBuilder.DropTable(
                name: "PastryFilling");

            migrationBuilder.DropIndex(
                name: "IX_Pastry_PastryFillingId",
                table: "Pastry");

            migrationBuilder.DropColumn(
                name: "PastryFillingId",
                table: "Pastry");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PastryType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "PastryTypeId",
                table: "Pastry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Pastry_PastryType_PastryTypeId",
                table: "Pastry",
                column: "PastryTypeId",
                principalTable: "PastryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
