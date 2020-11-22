using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.Migrations
{
    public partial class PrimaryKeysUsersFollowed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersFollowed_AspNetUsers_FollowedUserId",
                table: "UsersFollowed");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFollowed_AspNetUsers_UserId",
                table: "UsersFollowed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersFollowed",
                table: "UsersFollowed");

            migrationBuilder.DropIndex(
                name: "IX_UsersFollowed_UserId",
                table: "UsersFollowed");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersFollowed",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FollowedUserId",
                table: "UsersFollowed",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);



            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersFollowed",
                table: "UsersFollowed",
                columns: new[] { "UserId", "FollowedUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFollowed_AspNetUsers_FollowedUserId",
                table: "UsersFollowed",
                column: "FollowedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFollowed_AspNetUsers_UserId",
                table: "UsersFollowed",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersFollowed_AspNetUsers_FollowedUserId",
                table: "UsersFollowed");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFollowed_AspNetUsers_UserId",
                table: "UsersFollowed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersFollowed",
                table: "UsersFollowed");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UsersFollowed",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "FollowedUserId",
                table: "UsersFollowed",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersFollowed",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersFollowed",
                table: "UsersFollowed",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFollowed_UserId",
                table: "UsersFollowed",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFollowed_AspNetUsers_FollowedUserId",
                table: "UsersFollowed",
                column: "FollowedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFollowed_AspNetUsers_UserId",
                table: "UsersFollowed",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
