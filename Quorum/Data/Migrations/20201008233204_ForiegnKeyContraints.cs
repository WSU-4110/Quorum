using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.Migrations
{
    public partial class ForiegnKeyContraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumModels_ForumModels_ForumId",
                table: "ForumModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumReplies_ForumModels_ForumId",
                table: "ForumReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Mod_ForumModels_ForumId",
                table: "Mod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumModels",
                table: "ForumModels");

            migrationBuilder.RenameTable(
                name: "ForumModels",
                newName: "Forums");

            migrationBuilder.RenameIndex(
                name: "IX_ForumModels_ForumId",
                table: "Forums",
                newName: "IX_Forums_ForumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forums",
                table: "Forums",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mod_UserId",
                table: "Mod",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumReplies_UserId",
                table: "ForumReplies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Forums_UserId",
                table: "Forums",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReplies_Forums_ForumId",
                table: "ForumReplies",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReplies_AspNetUsers_UserId",
                table: "ForumReplies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_Forums_ForumId",
                table: "Forums",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_AspNetUsers_UserId",
                table: "Forums",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mod_Forums_ForumId",
                table: "Mod",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mod_AspNetUsers_UserId",
                table: "Mod",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumReplies_Forums_ForumId",
                table: "ForumReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumReplies_AspNetUsers_UserId",
                table: "ForumReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Forums_Forums_ForumId",
                table: "Forums");

            migrationBuilder.DropForeignKey(
                name: "FK_Forums_AspNetUsers_UserId",
                table: "Forums");

            migrationBuilder.DropForeignKey(
                name: "FK_Mod_Forums_ForumId",
                table: "Mod");

            migrationBuilder.DropForeignKey(
                name: "FK_Mod_AspNetUsers_UserId",
                table: "Mod");

            migrationBuilder.DropIndex(
                name: "IX_Mod_UserId",
                table: "Mod");

            migrationBuilder.DropIndex(
                name: "IX_ForumReplies_UserId",
                table: "ForumReplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forums",
                table: "Forums");

            migrationBuilder.DropIndex(
                name: "IX_Forums_UserId",
                table: "Forums");

            migrationBuilder.RenameTable(
                name: "Forums",
                newName: "ForumModels");

            migrationBuilder.RenameIndex(
                name: "IX_Forums_ForumId",
                table: "ForumModels",
                newName: "IX_ForumModels_ForumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumModels",
                table: "ForumModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumModels_ForumModels_ForumId",
                table: "ForumModels",
                column: "ForumId",
                principalTable: "ForumModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReplies_ForumModels_ForumId",
                table: "ForumReplies",
                column: "ForumId",
                principalTable: "ForumModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mod_ForumModels_ForumId",
                table: "Mod",
                column: "ForumId",
                principalTable: "ForumModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
