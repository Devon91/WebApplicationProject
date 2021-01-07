using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationProject.Migrations
{
    public partial class AddNavigations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandArtist_Band_BandID",
                schema: "project",
                table: "BandArtist");

            migrationBuilder.AlterColumn<int>(
                name: "BandID",
                schema: "project",
                table: "BandArtist",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BandArtist_Band_BandID",
                schema: "project",
                table: "BandArtist",
                column: "BandID",
                principalSchema: "project",
                principalTable: "Band",
                principalColumn: "BandID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandArtist_Band_BandID",
                schema: "project",
                table: "BandArtist");

            migrationBuilder.AlterColumn<int>(
                name: "BandID",
                schema: "project",
                table: "BandArtist",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BandArtist_Band_BandID",
                schema: "project",
                table: "BandArtist",
                column: "BandID",
                principalSchema: "project",
                principalTable: "Band",
                principalColumn: "BandID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
