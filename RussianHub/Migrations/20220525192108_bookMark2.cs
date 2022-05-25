using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RussianHub.Migrations
{
    public partial class bookMark2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_BookMark_BookMarkId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_BookMarkId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "BookMarkId",
                table: "Video");

            migrationBuilder.AddColumn<Guid>(
                name: "VideosId",
                table: "BookMark",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BookMark_VideosId",
                table: "BookMark",
                column: "VideosId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookMark_Video_VideosId",
                table: "BookMark",
                column: "VideosId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookMark_Video_VideosId",
                table: "BookMark");

            migrationBuilder.DropIndex(
                name: "IX_BookMark_VideosId",
                table: "BookMark");

            migrationBuilder.DropColumn(
                name: "VideosId",
                table: "BookMark");

            migrationBuilder.AddColumn<Guid>(
                name: "BookMarkId",
                table: "Video",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_BookMarkId",
                table: "Video",
                column: "BookMarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_BookMark_BookMarkId",
                table: "Video",
                column: "BookMarkId",
                principalTable: "BookMark",
                principalColumn: "Id");
        }
    }
}
