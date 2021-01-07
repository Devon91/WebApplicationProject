using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProject.Migrations
{
    public partial class Gebruikermodelaangepast2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "User",
                schema: "project",
                newName: "Gebruiker",
                newSchema: "project");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserID",
                schema: "project",
                table: "Gebruiker",
                newName: "IX_Gebruiker_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gebruiker",
                schema: "project",
                table: "Gebruiker",
                column: "GebruikerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruiker_AspNetUsers_UserID",
                schema: "project",
                table: "Gebruiker",
                column: "UserID",
                principalSchema: "project",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Gebruiker_GebruikerID",
                schema: "project",
                table: "Review",
                column: "GebruikerID",
                principalSchema: "project",
                principalTable: "Gebruiker",
                principalColumn: "GebruikerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gebruiker_AspNetUsers_UserID",
                schema: "project",
                table: "Gebruiker");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Gebruiker_GebruikerID",
                schema: "project",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gebruiker",
                schema: "project",
                table: "Gebruiker");

            migrationBuilder.RenameTable(
                name: "Gebruiker",
                schema: "project",
                newName: "User",
                newSchema: "project");

            migrationBuilder.RenameIndex(
                name: "IX_Gebruiker_UserID",
                schema: "project",
                table: "User",
                newName: "IX_User_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "project",
                table: "User",
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
    }
}
