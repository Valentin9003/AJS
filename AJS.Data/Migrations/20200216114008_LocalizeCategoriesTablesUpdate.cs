using Microsoft.EntityFrameworkCore.Migrations;

namespace AJS.Data.Migrations
{
    public partial class LocalizeCategoriesTablesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsCategoryTranslation_AdCategory_CategoryId",
                table: "NewsCategoryTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsCategoryTranslation_NewsCategory_NewsCategoryCategoryId",
                table: "NewsCategoryTranslation");

            migrationBuilder.DropIndex(
                name: "IX_NewsCategoryTranslation_NewsCategoryCategoryId",
                table: "NewsCategoryTranslation");

            migrationBuilder.DropColumn(
                name: "NewsCategoryCategoryId",
                table: "NewsCategoryTranslation");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsCategoryTranslation_NewsCategory_CategoryId",
                table: "NewsCategoryTranslation",
                column: "CategoryId",
                principalTable: "NewsCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsCategoryTranslation_NewsCategory_CategoryId",
                table: "NewsCategoryTranslation");

            migrationBuilder.AddColumn<string>(
                name: "NewsCategoryCategoryId",
                table: "NewsCategoryTranslation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsCategoryTranslation_NewsCategoryCategoryId",
                table: "NewsCategoryTranslation",
                column: "NewsCategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsCategoryTranslation_AdCategory_CategoryId",
                table: "NewsCategoryTranslation",
                column: "CategoryId",
                principalTable: "AdCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsCategoryTranslation_NewsCategory_NewsCategoryCategoryId",
                table: "NewsCategoryTranslation",
                column: "NewsCategoryCategoryId",
                principalTable: "NewsCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
