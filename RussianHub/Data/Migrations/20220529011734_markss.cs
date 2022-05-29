using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RussianHub.Data.Migrations
{
    public partial class markss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_BookMark_BookMarkMarkId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_BookMarkMarkId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "BookMarkMarkId",
                table: "Video");

            migrationBuilder.CreateTable(
                name: "BookMarkVideo",
                columns: table => new
                {
                    VideosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bookMarksMarkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookMarkVideo", x => new { x.VideosId, x.bookMarksMarkId });
                    table.ForeignKey(
                        name: "FK_BookMarkVideo_BookMark_bookMarksMarkId",
                        column: x => x.bookMarksMarkId,
                        principalTable: "BookMark",
                        principalColumn: "MarkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookMarkVideo_Video_VideosId",
                        column: x => x.VideosId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookMarkVideo_bookMarksMarkId",
                table: "BookMarkVideo",
                column: "bookMarksMarkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookMarkVideo");

            migrationBuilder.AddColumn<Guid>(
                name: "BookMarkMarkId",
                table: "Video",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_BookMarkMarkId",
                table: "Video",
                column: "BookMarkMarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_BookMark_BookMarkMarkId",
                table: "Video",
                column: "BookMarkMarkId",
                principalTable: "BookMark",
                principalColumn: "MarkId");
        }
    }
}
