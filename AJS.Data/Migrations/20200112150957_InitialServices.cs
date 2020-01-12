using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AJS.Data.Migrations
{
    public partial class InitialServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPictureId",
                table: "Ad");

            migrationBuilder.CreateTable(
                name: "ServiceCategory",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentServiceCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategory", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_ServiceCategory_ServiceCategory_ParentServiceCategoryId",
                        column: x => x.ParentServiceCategoryId,
                        principalTable: "ServiceCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDescription",
                columns: table => new
                {
                    DescriptionId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 700, nullable: false),
                    ServiceId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDescription", x => x.DescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceLocation",
                columns: table => new
                {
                    LocationId = table.Column<string>(nullable: false),
                    ServiceId = table.Column<string>(nullable: false),
                    Country = table.Column<string>(maxLength: 3, nullable: false),
                    City = table.Column<string>(maxLength: 15, nullable: false),
                    Street = table.Column<string>(maxLength: 15, nullable: true),
                    Address = table.Column<string>(maxLength: 15, nullable: true),
                    PostCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLocation", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 22, nullable: false),
                    CreatorId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false),
                    LocationId = table.Column<string>(nullable: false),
                    DescriptionId = table.Column<string>(nullable: false),
                    PublicationDate = table.Column<DateTime>(nullable: false),
                    Language = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Service_ServiceCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ServiceCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Service_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Service_ServiceDescription_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceDescription",
                        principalColumn: "DescriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Service_ServiceLocation_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceLocation",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePicture",
                columns: table => new
                {
                    PictureId = table.Column<string>(nullable: false),
                    ServiceId = table.Column<string>(nullable: false),
                    PictureByteArray = table.Column<byte[]>(maxLength: 10485760, nullable: false),
                    IsProfilePicture = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePicture", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_ServicePicture_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_CategoryId",
                table: "Service",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CreatorId",
                table: "Service",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategory_ParentServiceCategoryId",
                table: "ServiceCategory",
                column: "ParentServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePicture_ServiceId",
                table: "ServicePicture",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicePicture");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "ServiceCategory");

            migrationBuilder.DropTable(
                name: "ServiceDescription");

            migrationBuilder.DropTable(
                name: "ServiceLocation");

            migrationBuilder.AddColumn<string>(
                name: "MainPictureId",
                table: "Ad",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
