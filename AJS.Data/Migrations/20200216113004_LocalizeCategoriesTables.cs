using Microsoft.EntityFrameworkCore.Migrations;

namespace AJS.Data.Migrations
{
    public partial class LocalizeCategoriesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdCategoryTranslations_AdCategory_CategoryId",
                table: "AdCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCategoryTranslations_JobCategory_CategoryId",
                table: "JobCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategoryTranslations_ServiceCategory_CategoryId",
                table: "ServiceCategoryTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceCategoryTranslations",
                table: "ServiceCategoryTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCategoryTranslations",
                table: "JobCategoryTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdCategoryTranslations",
                table: "AdCategoryTranslations");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "News");

            migrationBuilder.RenameTable(
                name: "ServiceCategoryTranslations",
                newName: "ServiceCategoryTranslation");

            migrationBuilder.RenameTable(
                name: "JobCategoryTranslations",
                newName: "JobCategoryTranslation");

            migrationBuilder.RenameTable(
                name: "AdCategoryTranslations",
                newName: "AdCategoryTranslation");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategoryTranslations_CategoryId",
                table: "ServiceCategoryTranslation",
                newName: "IX_ServiceCategoryTranslation_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_JobCategoryTranslations_CategoryId",
                table: "JobCategoryTranslation",
                newName: "IX_JobCategoryTranslation_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AdCategoryTranslations_CategoryId",
                table: "AdCategoryTranslation",
                newName: "IX_AdCategoryTranslation_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "News",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceCategoryTranslation",
                table: "ServiceCategoryTranslation",
                column: "ServiceCategoryTranslationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCategoryTranslation",
                table: "JobCategoryTranslation",
                column: "JobCategoryTranslationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdCategoryTranslation",
                table: "AdCategoryTranslation",
                column: "AdCategoryTranslationId");

            migrationBuilder.CreateTable(
                name: "NewsCategory",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategoryTranslation",
                columns: table => new
                {
                    NewsCategoryTranslationId = table.Column<string>(nullable: false),
                    Translation = table.Column<string>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false),
                    NewsCategoryCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategoryTranslation", x => x.NewsCategoryTranslationId);
                    table.ForeignKey(
                        name: "FK_NewsCategoryTranslation_AdCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AdCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsCategoryTranslation_NewsCategory_NewsCategoryCategoryId",
                        column: x => x.NewsCategoryCategoryId,
                        principalTable: "NewsCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCategoryTranslation_CategoryId",
                table: "NewsCategoryTranslation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCategoryTranslation_NewsCategoryCategoryId",
                table: "NewsCategoryTranslation",
                column: "NewsCategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdCategoryTranslation_AdCategory_CategoryId",
                table: "AdCategoryTranslation",
                column: "CategoryId",
                principalTable: "AdCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCategoryTranslation_JobCategory_CategoryId",
                table: "JobCategoryTranslation",
                column: "CategoryId",
                principalTable: "JobCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategory_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "NewsCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategoryTranslation_ServiceCategory_CategoryId",
                table: "ServiceCategoryTranslation",
                column: "CategoryId",
                principalTable: "ServiceCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdCategoryTranslation_AdCategory_CategoryId",
                table: "AdCategoryTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCategoryTranslation_JobCategory_CategoryId",
                table: "JobCategoryTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategory_CategoryId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCategoryTranslation_ServiceCategory_CategoryId",
                table: "ServiceCategoryTranslation");

            migrationBuilder.DropTable(
                name: "NewsCategoryTranslation");

            migrationBuilder.DropTable(
                name: "NewsCategory");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryId",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceCategoryTranslation",
                table: "ServiceCategoryTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCategoryTranslation",
                table: "JobCategoryTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdCategoryTranslation",
                table: "AdCategoryTranslation");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "News");

            migrationBuilder.RenameTable(
                name: "ServiceCategoryTranslation",
                newName: "ServiceCategoryTranslations");

            migrationBuilder.RenameTable(
                name: "JobCategoryTranslation",
                newName: "JobCategoryTranslations");

            migrationBuilder.RenameTable(
                name: "AdCategoryTranslation",
                newName: "AdCategoryTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceCategoryTranslation_CategoryId",
                table: "ServiceCategoryTranslations",
                newName: "IX_ServiceCategoryTranslations_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_JobCategoryTranslation_CategoryId",
                table: "JobCategoryTranslations",
                newName: "IX_JobCategoryTranslations_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AdCategoryTranslation_CategoryId",
                table: "AdCategoryTranslations",
                newName: "IX_AdCategoryTranslations_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceCategoryTranslations",
                table: "ServiceCategoryTranslations",
                column: "ServiceCategoryTranslationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCategoryTranslations",
                table: "JobCategoryTranslations",
                column: "JobCategoryTranslationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdCategoryTranslations",
                table: "AdCategoryTranslations",
                column: "AdCategoryTranslationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdCategoryTranslations_AdCategory_CategoryId",
                table: "AdCategoryTranslations",
                column: "CategoryId",
                principalTable: "AdCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCategoryTranslations_JobCategory_CategoryId",
                table: "JobCategoryTranslations",
                column: "CategoryId",
                principalTable: "JobCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCategoryTranslations_ServiceCategory_CategoryId",
                table: "ServiceCategoryTranslations",
                column: "CategoryId",
                principalTable: "ServiceCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
