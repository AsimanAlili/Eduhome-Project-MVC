using Microsoft.EntityFrameworkCore.Migrations;

namespace Eduhome.Data.Migrations
{
    public partial class TestimonialsColumnsAndAboutColumnsAddedIntoSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutDesc",
                table: "Settings",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutPhoto",
                table: "Settings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutTitle",
                table: "Settings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestimonialDesc",
                table: "Settings",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestimonialFullName",
                table: "Settings",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestimonialOccupation",
                table: "Settings",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestimonialPhoto",
                table: "Settings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestimonialPlace",
                table: "Settings",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutDesc",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AboutPhoto",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AboutTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TestimonialDesc",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TestimonialFullName",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TestimonialOccupation",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TestimonialPhoto",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TestimonialPlace",
                table: "Settings");
        }
    }
}
