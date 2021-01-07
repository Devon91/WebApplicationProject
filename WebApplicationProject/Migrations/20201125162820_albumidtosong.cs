using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProject.Migrations
{
    public partial class albumidtosong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumID",
                schema: "project",
                table: "Song");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumID",
                schema: "project",
                table: "Song",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumID",
                schema: "project",
                table: "Song",
                column: "AlbumID",
                principalSchema: "project",
                principalTable: "Album",
                principalColumn: "AlbumID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumID",
                schema: "project",
                table: "Song");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumID",
                schema: "project",
                table: "Song",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumID",
                schema: "project",
                table: "Song",
                column: "AlbumID",
                principalSchema: "project",
                principalTable: "Album",
                principalColumn: "AlbumID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
