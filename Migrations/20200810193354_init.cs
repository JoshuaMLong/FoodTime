using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTime.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PastryType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pastries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PastryTypeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pastries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pastries_PastryType_PastryTypeId",
                        column: x => x.PastryTypeId,
                        principalTable: "PastryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pastries_PastryTypeId",
                table: "Pastries",
                column: "PastryTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pastries");

            migrationBuilder.DropTable(
                name: "PastryType");
        }
    }
}
