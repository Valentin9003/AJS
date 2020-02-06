using Microsoft.EntityFrameworkCore.Migrations;

namespace AJS.Data.Migrations
{
    public partial class AddReviewCounterColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewCounter",
                table: "Service",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewCounter",
                table: "News",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewCounter",
                table: "Job",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewCounter",
                table: "Ad",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewCounter",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ReviewCounter",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ReviewCounter",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "ReviewCounter",
                table: "Ad");
        }
    }
}
