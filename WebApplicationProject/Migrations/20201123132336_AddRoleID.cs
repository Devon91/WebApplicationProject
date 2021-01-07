using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProject.Migrations
{
    public partial class AddRoleID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandArtist_Artist_ArtistID",
                schema: "project",
                table: "BandArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_BandArtist_Role_RoleID",
                schema: "project",
                table: "BandArtist");

            migrationBuilder.AlterColumn<int>(
                name: "RoleID",
                schema: "project",
                table: "BandArtist",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                schema: "project",
                table: "BandArtist",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BandArtist_Artist_ArtistID",
                schema: "project",
                table: "BandArtist",
                column: "ArtistID",
                principalSchema: "project",
                principalTable: "Artist",
                principalColumn: "ArtistID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BandArtist_Role_RoleID",
                schema: "project",
                table: "BandArtist",
                column: "RoleID",
                principalSchema: "project",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandArtist_Artist_ArtistID",
                schema: "project",
                table: "BandArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_BandArtist_Role_RoleID",
                schema: "project",
                table: "BandArtist");

            migrationBuilder.AlterColumn<int>(
                name: "RoleID",
                schema: "project",
                table: "BandArtist",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ArtistID",
                schema: "project",
                table: "BandArtist",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BandArtist_Artist_ArtistID",
                schema: "project",
                table: "BandArtist",
                column: "ArtistID",
                principalSchema: "project",
                principalTable: "Artist",
                principalColumn: "ArtistID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BandArtist_Role_RoleID",
                schema: "project",
                table: "BandArtist",
                column: "RoleID",
                principalSchema: "project",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
