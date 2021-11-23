using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMusic.Migrations
{
    public partial class deletingforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Users_UsersId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_UsersId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Songs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_UsersId",
                table: "Songs",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Users_UsersId",
                table: "Songs",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
