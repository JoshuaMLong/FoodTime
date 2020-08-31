using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTime.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PastryDough",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastryDough", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PastryFilling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastryFilling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pastry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PastryDoughId = table.Column<int>(nullable: false),
                    PastryFillingId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pastry_PastryDough_PastryDoughId",
                        column: x => x.PastryDoughId,
                        principalTable: "PastryDough",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pastry_PastryFilling_PastryFillingId",
                        column: x => x.PastryFillingId,
                        principalTable: "PastryFilling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PastryType",
                columns: table => new
                {
                    PastryFillingId = table.Column<int>(nullable: false),
                    PastryDoughId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastryType", x => new { x.PastryFillingId, x.PastryDoughId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_PastryType_PastryDough_PastryDoughId",
                        column: x => x.PastryDoughId,
                        principalTable: "PastryDough",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PastryType_PastryFilling_PastryFillingId",
                        column: x => x.PastryFillingId,
                        principalTable: "PastryFilling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pastry_PastryDoughId",
                table: "Pastry",
                column: "PastryDoughId");

            migrationBuilder.CreateIndex(
                name: "IX_Pastry_PastryFillingId_PastryDoughId",
                table: "Pastry",
                columns: new[] { "PastryFillingId", "PastryDoughId" });

            migrationBuilder.CreateIndex(
                name: "IX_PastryType_PastryDoughId",
                table: "PastryType",
                column: "PastryDoughId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pastry");

            migrationBuilder.DropTable(
                name: "PastryType");

            migrationBuilder.DropTable(
                name: "PastryDough");

            migrationBuilder.DropTable(
                name: "PastryFilling");
        }
    }
}
