using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RussianHub.Migrations.PersonalParameters
{
    public partial class PersonalParametrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ade = table.Column<int>(type: "int", nullable: false),
                    Weigh = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatefBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalParameters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalParameters");
        }
    }
}
