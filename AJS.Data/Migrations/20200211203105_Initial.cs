using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AJS.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdCategory",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentAdCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdCategory", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_AdCategory_AdCategory_ParentAdCategoryId",
                        column: x => x.ParentAdCategoryId,
                        principalTable: "AdCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentJobCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_JobCategory_JobCategory_ParentJobCategoryId",
                        column: x => x.ParentJobCategoryId,
                        principalTable: "JobCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "AdCategoryTranslation",
                columns: table => new
                {
                    AdCategoryTranslationId = table.Column<string>(nullable: false),
                    Translation = table.Column<string>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdCategoryTranslation", x => x.AdCategoryTranslationId);
                    table.ForeignKey(
                        name: "FK_AdCategoryTranslation_AdCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AdCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ad",
                columns: table => new
                {
                    AdId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 22, nullable: false),
                    ReviewCounter = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false),
                    PublicationDate = table.Column<DateTime>(nullable: false),
                    Language = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad", x => x.AdId);
                    table.ForeignKey(
                        name: "FK_Ad_AdCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AdCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ad_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    SenderId = table.Column<string>(nullable: false),
                    ReceivedId = table.Column<string>(nullable: false),
                    MessageId = table.Column<string>(nullable: true),
                    TextMessage = table.Column<string>(maxLength: 700, nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    TimeSend = table.Column<DateTime>(nullable: false),
                    TimeSeen = table.Column<string>(nullable: true),
                    Seen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => new { x.SenderId, x.ReceivedId });
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_ReceivedId",
                        column: x => x.ReceivedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: false),
                    ReviewCounter = table.Column<int>(nullable: false),
                    PublicationDate = table.Column<DateTime>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                    table.ForeignKey(
                        name: "FK_News_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 22, nullable: false),
                    ReviewCounter = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false),
                    PublicationDate = table.Column<DateTime>(nullable: false),
                    Language = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Job_JobCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "JobCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 22, nullable: false),
                    ReviewCounter = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategoryTranslation",
                columns: table => new
                {
                    ServiceCategoryTranslationId = table.Column<string>(nullable: false),
                    Translation = table.Column<string>(nullable: false),
                    Language = table.Column<int>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategoryTranslation", x => x.ServiceCategoryTranslationId);
                    table.ForeignKey(
                        name: "FK_ServiceCategoryTranslation_ServiceCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ServiceCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdDescription",
                columns: table => new
                {
                    DescriptionId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 700, nullable: false),
                    State = table.Column<int>(nullable: false),
                    AdId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdDescription", x => x.DescriptionId);
                    table.ForeignKey(
                        name: "FK_AdDescription_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "AdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdLocation",
                columns: table => new
                {
                    LocationId = table.Column<string>(nullable: false),
                    AdId = table.Column<string>(nullable: false),
                    Country = table.Column<string>(maxLength: 15, nullable: false),
                    City = table.Column<string>(maxLength: 15, nullable: false),
                    Street = table.Column<string>(maxLength: 15, nullable: true),
                    Address = table.Column<string>(maxLength: 15, nullable: true),
                    PostCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdLocation", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_AdLocation_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "AdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdPicture",
                columns: table => new
                {
                    PictureId = table.Column<string>(nullable: false),
                    AdId = table.Column<string>(nullable: false),
                    PictureByteArray = table.Column<byte[]>(maxLength: 10485760, nullable: false),
                    IsMainPicture = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdPicture", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_AdPicture_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "AdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdPrice",
                columns: table => new
                {
                    AdPriceId = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    AdId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdPrice", x => x.AdPriceId);
                    table.ForeignKey(
                        name: "FK_AdPrice_Ad_AdId",
                        column: x => x.AdId,
                        principalTable: "Ad",
                        principalColumn: "AdId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobDescription",
                columns: table => new
                {
                    DescriptionId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 700, nullable: false),
                    JobId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDescription", x => x.DescriptionId);
                    table.ForeignKey(
                        name: "FK_JobDescription_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobLocation",
                columns: table => new
                {
                    LocationId = table.Column<string>(nullable: false),
                    JobId = table.Column<string>(nullable: false),
                    Country = table.Column<string>(maxLength: 15, nullable: false),
                    City = table.Column<string>(maxLength: 15, nullable: false),
                    Street = table.Column<string>(maxLength: 15, nullable: true),
                    Address = table.Column<string>(maxLength: 15, nullable: true),
                    PostCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLocation", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_JobLocation_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPicture",
                columns: table => new
                {
                    PictureId = table.Column<string>(nullable: false),
                    JobId = table.Column<string>(nullable: false),
                    PictureByteArray = table.Column<byte[]>(maxLength: 10485760, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPicture", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_JobPicture_Job_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPrice",
                columns: table => new
                {
                    JobPriceId = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    JobId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPrice", x => x.JobPriceId);
                    table.ForeignKey(
                        name: "FK_JobPrice_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "JobId",
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
                    table.ForeignKey(
                        name: "FK_ServiceDescription_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceLocation",
                columns: table => new
                {
                    LocationId = table.Column<string>(nullable: false),
                    ServiceId = table.Column<string>(nullable: false),
                    Country = table.Column<string>(maxLength: 15, nullable: false),
                    City = table.Column<string>(maxLength: 15, nullable: false),
                    Street = table.Column<string>(maxLength: 15, nullable: true),
                    Address = table.Column<string>(maxLength: 15, nullable: true),
                    PostCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLocation", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_ServiceLocation_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePicture",
                columns: table => new
                {
                    PictureId = table.Column<string>(nullable: false),
                    ServiceId = table.Column<string>(nullable: false),
                    PictureByteArray = table.Column<byte[]>(maxLength: 10485760, nullable: false),
                    IsMainPicture = table.Column<bool>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ServicePrice",
                columns: table => new
                {
                    ServicePriceId = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    ServiceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePrice", x => x.ServicePriceId);
                    table.ForeignKey(
                        name: "FK_ServicePrice_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ad_CategoryId",
                table: "Ad",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ad_CreatorId",
                table: "Ad",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdCategory_ParentAdCategoryId",
                table: "AdCategory",
                column: "ParentAdCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdCategoryTranslation_CategoryId",
                table: "AdCategoryTranslation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdDescription_AdId",
                table: "AdDescription",
                column: "AdId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdLocation_AdId",
                table: "AdLocation",
                column: "AdId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdPicture_AdId",
                table: "AdPicture",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdPrice_AdId",
                table: "AdPrice",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CategoryId",
                table: "Job",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CreatorId",
                table: "Job",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCategory_ParentJobCategoryId",
                table: "JobCategory",
                column: "ParentJobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCategoryTranslation_CategoryId",
                table: "JobCategoryTranslation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobDescription_JobId",
                table: "JobDescription",
                column: "JobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobLocation_JobId",
                table: "JobLocation",
                column: "JobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPrice_JobId",
                table: "JobPrice",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ReceivedId",
                table: "Message",
                column: "ReceivedId");

            migrationBuilder.CreateIndex(
                name: "IX_News_CreatorId",
                table: "News",
                column: "CreatorId");

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
                name: "IX_ServiceCategoryTranslation_CategoryId",
                table: "ServiceCategoryTranslation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDescription_ServiceId",
                table: "ServiceDescription",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLocation_ServiceId",
                table: "ServiceLocation",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicePicture_ServiceId",
                table: "ServicePicture",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePrice_ServiceId",
                table: "ServicePrice",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdCategoryTranslation");

            migrationBuilder.DropTable(
                name: "AdDescription");

            migrationBuilder.DropTable(
                name: "AdLocation");

            migrationBuilder.DropTable(
                name: "AdPicture");

            migrationBuilder.DropTable(
                name: "AdPrice");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "JobCategoryTranslation");

            migrationBuilder.DropTable(
                name: "JobDescription");

            migrationBuilder.DropTable(
                name: "JobLocation");

            migrationBuilder.DropTable(
                name: "JobPicture");

            migrationBuilder.DropTable(
                name: "JobPrice");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "ServiceCategoryTranslation");

            migrationBuilder.DropTable(
                name: "ServiceDescription");

            migrationBuilder.DropTable(
                name: "ServiceLocation");

            migrationBuilder.DropTable(
                name: "ServicePicture");

            migrationBuilder.DropTable(
                name: "ServicePrice");

            migrationBuilder.DropTable(
                name: "Ad");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "AdCategory");

            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropTable(
                name: "ServiceCategory");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
