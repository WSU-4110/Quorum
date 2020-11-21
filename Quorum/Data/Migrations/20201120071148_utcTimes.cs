using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quorum.Migrations
{
    public partial class utcTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumReplies_Forums_ForumId",
                table: "ForumReplies");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedTime",
                table: "ForumThreads",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Forums",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ForumId",
                table: "ForumReplies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedTime",
                table: "ForumReplies",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "ForumReplies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ThreadId",
                table: "ForumReplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateRegistered",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_ForumReplies_ThreadId",
                table: "ForumReplies",
                column: "ThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReplies_Forums_ForumId",
                table: "ForumReplies",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReplies_ForumThreads_ThreadId",
                table: "ForumReplies",
                column: "ThreadId",
                principalTable: "ForumThreads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumReplies_Forums_ForumId",
                table: "ForumReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumReplies_ForumThreads_ThreadId",
                table: "ForumReplies");

            migrationBuilder.DropIndex(
                name: "IX_ForumReplies_ThreadId",
                table: "ForumReplies");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "ForumReplies");

            migrationBuilder.DropColumn(
                name: "ThreadId",
                table: "ForumReplies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ForumThreads",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Forums",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<int>(
                name: "ForumId",
                table: "ForumReplies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ForumReplies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegistered",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumReplies_Forums_ForumId",
                table: "ForumReplies",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
