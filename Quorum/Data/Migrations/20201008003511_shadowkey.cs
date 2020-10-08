using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.Data.Migrations
{
    public partial class shadowkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumModels_ForumModels_ForumModelId",
                table: "ForumModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumReplies_ForumModels_ForumModelId",
                table: "ForumReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Mod_ForumModels_ForumModelId",
                table: "Mod");

            migrationBuilder.DropIndex(
                name: "IX_Mod_ForumModelId",
                table: "Mod");

            migrationBuilder.DropIndex(
                name: "IX_ForumReplies_ForumModelId",
                table: "ForumReplies");

            migrationBuilder.DropIndex(
                name: "IX_ForumModels_ForumModelId",
                table: "ForumModels");

            migrationBuilder.DropColumn(
                name: "ForumModelId",
                table: "ForumReplies");

            migrationBuilder.DropColumn(
                name: "ForumModelId",
                table: "ForumModels");

            migrationBuilder.AddColumn<int>(
                name: "ForumId",
                table: "Mod",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForumId",
                table: "ForumModels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mod_ForumId",
                table: "Mod",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumReplies_ForumId",
                table: "ForumReplies",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumModels_ForumId",
                table: "ForumModels",
                column: "ForumId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Mod_ForumId",
                table: "Mod");

            migrationBuilder.DropIndex(
                name: "IX_ForumReplies_ForumId",
                table: "ForumReplies");

            migrationBuilder.DropIndex(
                name: "IX_ForumModels_ForumId",
                table: "ForumModels");

            migrationBuilder.DropColumn(
                name: "ForumId",
                table: "Mod");

            migrationBuilder.DropColumn(
                name: "ForumId",
                table: "ForumModels");

            migrationBuilder.AddColumn<int>(
                name: "ForumModelId",
                table: "ForumReplies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForumModelId",
                table: "ForumModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mod_ForumModelId",
                table: "Mod",
                column: "ForumModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumReplies_ForumModelId",
                table: "ForumReplies",
                column: "ForumModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumModels_ForumModelId",
                table: "ForumModels",
                column: "ForumModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumModels_ForumModels_ForumModelId",
                table: "ForumModels",
                column: "ForumModelId",
                principalTable: "ForumModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReplies_ForumModels_ForumModelId",
                table: "ForumReplies",
                column: "ForumModelId",
                principalTable: "ForumModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mod_ForumModels_ForumModelId",
                table: "Mod",
                column: "ForumModelId",
                principalTable: "ForumModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
