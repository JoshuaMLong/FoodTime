using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTime.API.Migrations
{
    public partial class added_notmappedattribute_to_public_fields_on_pastry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pastry",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Pastry",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pastry",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
