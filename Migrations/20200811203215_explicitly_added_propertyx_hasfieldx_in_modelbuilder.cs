using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTime.Migrations
{
    public partial class explicitly_added_propertyx_hasfieldx_in_modelbuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pastry",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Pastry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pastry",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pastry");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Pastry");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pastry");
        }
    }
}
