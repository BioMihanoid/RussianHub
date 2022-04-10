using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RussianHub.Migrations.User
{
    public partial class Users : Migration
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

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageRating = table.Column<int>(type: "int", nullable: false),
                    CountLikes = table.Column<int>(type: "int", nullable: false),
                    CountDislikes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountVideos = table.Column<int>(type: "int", nullable: false),
                    CountSubscribers = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalParametersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_PersonalParameters_PersonalParametersId",
                        column: x => x.PersonalParametersId,
                        principalTable: "PersonalParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StankinTeacher = table.Column<bool>(type: "bit", nullable: false),
                    PersonalParametersId = table.Column<int>(type: "int", nullable: false),
                    TimeOnline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_PersonalParameters_PersonalParametersId",
                        column: x => x.PersonalParametersId,
                        principalTable: "PersonalParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CountViews = table.Column<int>(type: "int", nullable: false),
                    DescriptionVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false),
                    CountComments = table.Column<int>(type: "int", nullable: false),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelUser",
                columns: table => new
                {
                    SubscribersId = table.Column<int>(type: "int", nullable: false),
                    SubscribtionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelUser", x => new { x.SubscribersId, x.SubscribtionsId });
                    table.ForeignKey(
                        name: "FK_ModelUser_Model_SubscribtionsId",
                        column: x => x.SubscribtionsId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelUser_User_SubscribersId",
                        column: x => x.SubscribersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PublicationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genre_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModelVideo",
                columns: table => new
                {
                    ModelsId = table.Column<int>(type: "int", nullable: false),
                    VideosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVideo", x => new { x.ModelsId, x.VideosId });
                    table.ForeignKey(
                        name: "FK_ModelVideo_Model_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelVideo_Video_VideosId",
                        column: x => x.VideosId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_VideoId",
                table: "Comment",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_VideoId",
                table: "Genre",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_PersonalParametersId",
                table: "Model",
                column: "PersonalParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelUser_SubscribtionsId",
                table: "ModelUser",
                column: "SubscribtionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelVideo_VideosId",
                table: "ModelVideo",
                column: "VideosId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonalParametersId",
                table: "User",
                column: "PersonalParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_RatingId",
                table: "Video",
                column: "RatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "ModelUser");

            migrationBuilder.DropTable(
                name: "ModelVideo");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "PersonalParameters");

            migrationBuilder.DropTable(
                name: "Rating");
        }
    }
}
