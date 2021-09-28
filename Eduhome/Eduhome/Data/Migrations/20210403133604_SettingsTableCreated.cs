using Microsoft.EntityFrameworkCore.Migrations;

namespace Eduhome.Data.Migrations
{
    public partial class SettingsTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(maxLength: 100, nullable: false),
                    FooterLogo = table.Column<string>(maxLength: 100, nullable: false),
                    FooterDesc = table.Column<string>(maxLength: 500, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    ServicePhone = table.Column<string>(maxLength: 20, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    WebSiteUrl = table.Column<string>(maxLength: 100, nullable: true),
                    FacebookUrl = table.Column<string>(maxLength: 100, nullable: true),
                    TwitterUrl = table.Column<string>(maxLength: 100, nullable: true),
                    VimeoUrl = table.Column<string>(maxLength: 100, nullable: true),
                    PinteresUrl = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
