using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProject.Migrations
{
    public partial class Gebruikermodelaangepast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_User_UserID",
                schema: "project",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_UserID",
                schema: "project",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "project",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Review_UserID",
                schema: "project",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserID",
                schema: "project",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "project",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "project",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "project",
                table: "User",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GebruikerID",
                schema: "project",
                table: "User",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GebruikerID",
                schema: "project",
                table: "Review",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "project",
                table: "User",
                column: "GebruikerID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserID",
                schema: "project",
                table: "User",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Review_GebruikerID",
                schema: "project",
                table: "Review",
                column: "GebruikerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_GebruikerID",
                schema: "project",
                table: "Review",
                column: "GebruikerID",
                principalSchema: "project",
                principalTable: "User",
                principalColumn: "GebruikerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_AspNetUsers_UserID",
                schema: "project",
                table: "User",
                column: "UserID",
                principalSchema: "project",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_GebruikerID",
                schema: "project",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_User_AspNetUsers_UserID",
                schema: "project",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "project",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserID",
                schema: "project",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Review_GebruikerID",
                schema: "project",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "GebruikerID",
                schema: "project",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GebruikerID",
                schema: "project",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                schema: "project",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                schema: "project",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                schema: "project",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "project",
                table: "User",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserID",
                schema: "project",
                table: "Review",
                column: "UserID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_UserID",
                schema: "project",
                table: "Review",
                column: "UserID",
                principalSchema: "project",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
