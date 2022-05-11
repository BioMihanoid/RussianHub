using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RussianHub.Migrations
{
    public partial class VideoMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountViews",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountViews",
                table: "Video");
        }
    }
}
