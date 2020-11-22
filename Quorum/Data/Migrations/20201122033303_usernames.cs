using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.Migrations
{
    public partial class usernames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ForumThreads",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ForumReplies",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ForumThreads");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ForumReplies");
        }
    }
}
