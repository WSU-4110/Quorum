using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.Migrations
{
    public partial class ThreadViewCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Forums");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "ForumThreads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "ForumThreads");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Forums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
