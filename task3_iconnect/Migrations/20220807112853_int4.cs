using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task3_iconnect.Migrations
{
    public partial class int4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GreatBy",
                table: "Posts",
                newName: "CreatBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatBy",
                table: "Posts",
                newName: "GreatBy");
        }
    }
}
