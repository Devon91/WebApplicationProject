using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProject.Migrations
{
    public partial class CutomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naam",
                schema: "project",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                schema: "project",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserID",
                schema: "project",
                table: "AspNetUsers",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_User_UserID",
                schema: "project",
                table: "AspNetUsers",
                column: "UserID",
                principalSchema: "project",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_User_UserID",
                schema: "project",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserID",
                schema: "project",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "project",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                schema: "project",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
