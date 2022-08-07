using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task3_iconnect.Migrations
{
    public partial class int3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GreatBy",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GreatBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Posts");
        }
    }
}
