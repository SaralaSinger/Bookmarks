using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmarks.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Users_UserId1",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_UserId1",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Bookmarks");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bookmarks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_UserId",
                table: "Bookmarks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Users_UserId",
                table: "Bookmarks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Users_UserId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_UserId",
                table: "Bookmarks");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookmarks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Bookmarks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_UserId1",
                table: "Bookmarks",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Users_UserId1",
                table: "Bookmarks",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
