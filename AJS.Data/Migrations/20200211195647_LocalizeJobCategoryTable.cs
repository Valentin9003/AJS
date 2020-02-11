using Microsoft.EntityFrameworkCore.Migrations;

namespace AJS.Data.Migrations
{
    public partial class LocalizeJobCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCategoryTranslation",
                columns: table => new
                {
                    JobCategoryTranslationId = table.Column<string>(nullable: false),
                    Translation = table.Column<string>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategoryTranslation", x => x.JobCategoryTranslationId);
                    table.ForeignKey(
                        name: "FK_JobCategoryTranslation_JobCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "JobCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCategoryTranslation_CategoryId",
                table: "JobCategoryTranslation",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCategoryTranslation");
        }
    }
}
