using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task3_iconnect.Migrations
{
    public partial class InitDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_userid",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Posts",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "IdPost",
                table: "Posts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_userid",
                table: "Posts",
                newName: "IX_Posts_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_userId",
                table: "Posts",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_userId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Posts",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posts",
                newName: "IdPost");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_userId",
                table: "Posts",
                newName: "IX_Posts_userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_userid",
                table: "Posts",
                column: "userid",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
