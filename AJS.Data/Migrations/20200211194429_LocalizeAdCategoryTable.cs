using Microsoft.EntityFrameworkCore.Migrations;

namespace AJS.Data.Migrations
{
    public partial class LocalizeAdCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdCategoryTranslation_AdCategory_AdCategoryTranslationId",
                table: "AdCategoryTranslation");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "AdCategoryTranslation",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_AdCategoryTranslation_CategoryId",
                table: "AdCategoryTranslation",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdCategoryTranslation_AdCategory_CategoryId",
                table: "AdCategoryTranslation",
                column: "CategoryId",
                principalTable: "AdCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdCategoryTranslation_AdCategory_CategoryId",
                table: "AdCategoryTranslation");

            migrationBuilder.DropIndex(
                name: "IX_AdCategoryTranslation_CategoryId",
                table: "AdCategoryTranslation");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "AdCategoryTranslation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_AdCategoryTranslation_AdCategory_AdCategoryTranslationId",
                table: "AdCategoryTranslation",
                column: "AdCategoryTranslationId",
                principalTable: "AdCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
