using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RussianHub.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserRole",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
