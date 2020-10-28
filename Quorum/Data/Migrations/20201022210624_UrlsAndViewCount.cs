using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.Migrations
{
    public partial class UrlsAndViewCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isPrivate",
                table: "Forums",
                newName: "IsPrivate");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Forums",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Forums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Forums_Url",
                table: "Forums",
                column: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Forums_Url",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Forums");

            migrationBuilder.RenameColumn(
                name: "IsPrivate",
                table: "Forums",
                newName: "isPrivate");
        }
    }
}
