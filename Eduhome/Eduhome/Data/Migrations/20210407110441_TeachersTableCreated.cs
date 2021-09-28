using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eduhome.Data.Migrations
{
    public partial class TeachersTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(maxLength: 100, nullable: false),
                    TeachingStatus = table.Column<string>(maxLength: 100, nullable: false),
                    Photo = table.Column<string>(maxLength: 500, nullable: true),
                    Desc = table.Column<string>(maxLength: 1500, nullable: true),
                    Degree = table.Column<string>(maxLength: 100, nullable: true),
                    Experience = table.Column<string>(maxLength: 100, nullable: true),
                    Hobby = table.Column<string>(maxLength: 150, nullable: true),
                    Faculty = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Skype = table.Column<string>(maxLength: 100, nullable: true),
                    FacebookUrl = table.Column<string>(maxLength: 100, nullable: true),
                    PinterestUrl = table.Column<string>(maxLength: 100, nullable: true),
                    VimeoUrl = table.Column<string>(maxLength: 100, nullable: true),
                    TwitterUrl = table.Column<string>(maxLength: 100, nullable: true),
                    LanguagePercentage = table.Column<int>(nullable: false),
                    TeamLeaderPercentage = table.Column<int>(nullable: false),
                    DevelopmentPercentage = table.Column<int>(nullable: false),
                    DesignPercentage = table.Column<int>(nullable: false),
                    InnovationPercentage = table.Column<int>(nullable: false),
                    CommunicationPercentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
