using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTime.API.Migrations
{
    public partial class pastry_stock_object : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PastryStock",
                columns: table => new
                {
                    PastryFillingId = table.Column<int>(nullable: false),
                    PastryTypeId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastryStock", x => new { x.PastryFillingId, x.PastryTypeId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_PastryStock_PastryFilling_PastryFillingId",
                        column: x => x.PastryFillingId,
                        principalTable: "PastryFilling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PastryStock_PastryType_PastryTypeId",
                        column: x => x.PastryTypeId,
                        principalTable: "PastryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PastryStock_PastryTypeId",
                table: "PastryStock",
                column: "PastryTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PastryStock");
        }
    }
}
