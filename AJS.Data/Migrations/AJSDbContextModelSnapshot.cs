﻿// <auto-generated />
using System;
using AJS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AJS.Data.Migrations
{
    [DbContext(typeof(AJSDbContext))]
    partial class AJSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AJS.Data.Models.Ad", b =>
                {
                    b.Property<string>("AdId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(22)")
                        .HasMaxLength(22);

                    b.HasKey("AdId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Ad");
                });

            modelBuilder.Entity("AJS.Data.Models.AdCategory", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentAdCategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentAdCategoryId");

                    b.ToTable("AdCategory");
                });

            modelBuilder.Entity("AJS.Data.Models.AdDescription", b =>
                {
                    b.Property<string>("DescriptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(700)")
                        .HasMaxLength(700);

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("DescriptionId");

                    b.HasIndex("AdId")
                        .IsUnique();

                    b.ToTable("AdDescription");
                });

            modelBuilder.Entity("AJS.Data.Models.AdLocation", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("LocationId");

                    b.HasIndex("AdId")
                        .IsUnique();

                    b.ToTable("AdLocation");
                });

            modelBuilder.Entity("AJS.Data.Models.AdPicture", b =>
                {
                    b.Property<string>("PictureId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsMainPicture")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PictureByteArray")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasMaxLength(10485760);

                    b.HasKey("PictureId");

                    b.HasIndex("AdId");

                    b.ToTable("AdPicture");
                });

            modelBuilder.Entity("AJS.Data.Models.AdPrice", b =>
                {
                    b.Property<string>("AdPriceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("AdPriceId");

                    b.HasIndex("AdId");

                    b.ToTable("AdPrice");
                });

            modelBuilder.Entity("AJS.Data.Models.Job", b =>
                {
                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(22)")
                        .HasMaxLength(22);

                    b.HasKey("JobId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("AJS.Data.Models.JobCategory", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentJobCategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentJobCategoryId");

                    b.ToTable("JobCategory");
                });

            modelBuilder.Entity("AJS.Data.Models.JobDescription", b =>
                {
                    b.Property<string>("DescriptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(700)")
                        .HasMaxLength(700);

                    b.Property<string>("JobId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DescriptionId");

                    b.HasIndex("JobId")
                        .IsUnique();

                    b.ToTable("JobDescription");
                });

            modelBuilder.Entity("AJS.Data.Models.JobLocation", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("JobId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("LocationId");

                    b.HasIndex("JobId")
                        .IsUnique();

                    b.ToTable("JobLocation");
                });

            modelBuilder.Entity("AJS.Data.Models.JobPicture", b =>
                {
                    b.Property<string>("PictureId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JobId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PictureByteArray")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasMaxLength(10485760);

                    b.HasKey("PictureId");

                    b.ToTable("JobPicture");
                });

            modelBuilder.Entity("AJS.Data.Models.JobPrice", b =>
                {
                    b.Property<string>("JobPriceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("JobPriceId");

                    b.HasIndex("JobId");

                    b.ToTable("JobPrice");
                });

            modelBuilder.Entity("AJS.Data.Models.Service", b =>
                {
                    b.Property<string>("ServiceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(22)")
                        .HasMaxLength(22);

                    b.HasKey("ServiceId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("AJS.Data.Models.ServiceCategory", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentServiceCategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentServiceCategoryId");

                    b.ToTable("ServiceCategory");
                });

            modelBuilder.Entity("AJS.Data.Models.ServiceDescription", b =>
                {
                    b.Property<string>("DescriptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(700)")
                        .HasMaxLength(700);

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DescriptionId");

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("ServiceDescription");
                });

            modelBuilder.Entity("AJS.Data.Models.ServiceLocation", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("LocationId");

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("ServiceLocation");
                });

            modelBuilder.Entity("AJS.Data.Models.ServicePicture", b =>
                {
                    b.Property<string>("PictureId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsMainPicture")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PictureByteArray")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasMaxLength(10485760);

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PictureId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServicePicture");
                });

            modelBuilder.Entity("AJS.Data.Models.ServicePrice", b =>
                {
                    b.Property<string>("ServicePriceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ServiceId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ServicePriceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServicePrice");
                });

            modelBuilder.Entity("AJS.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AJS.Data.Models.Ad", b =>
                {
                    b.HasOne("AJS.Data.Models.AdCategory", "Category")
                        .WithMany("Ads")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AJS.Data.Models.User", "Creator")
                        .WithMany("Ads")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.AdCategory", b =>
                {
                    b.HasOne("AJS.Data.Models.AdCategory", "ParentAdCategory")
                        .WithMany("Categories")
                        .HasForeignKey("ParentAdCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AJS.Data.Models.AdDescription", b =>
                {
                    b.HasOne("AJS.Data.Models.Ad", "Ad")
                        .WithOne("Description")
                        .HasForeignKey("AJS.Data.Models.AdDescription", "AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.AdLocation", b =>
                {
                    b.HasOne("AJS.Data.Models.Ad", "Ad")
                        .WithOne("Location")
                        .HasForeignKey("AJS.Data.Models.AdLocation", "AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.AdPicture", b =>
                {
                    b.HasOne("AJS.Data.Models.Ad", "Ad")
                        .WithMany("Pictures")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.AdPrice", b =>
                {
                    b.HasOne("AJS.Data.Models.Ad", "Ad")
                        .WithMany("Prices")
                        .HasForeignKey("AdId");
                });

            modelBuilder.Entity("AJS.Data.Models.Job", b =>
                {
                    b.HasOne("AJS.Data.Models.JobCategory", "Category")
                        .WithMany("Jobs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AJS.Data.Models.User", "Creator")
                        .WithMany("Jobs")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.JobCategory", b =>
                {
                    b.HasOne("AJS.Data.Models.JobCategory", "ParentJobCategory")
                        .WithMany("Categories")
                        .HasForeignKey("ParentJobCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AJS.Data.Models.JobDescription", b =>
                {
                    b.HasOne("AJS.Data.Models.Job", "Job")
                        .WithOne("Description")
                        .HasForeignKey("AJS.Data.Models.JobDescription", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.JobLocation", b =>
                {
                    b.HasOne("AJS.Data.Models.Job", "Job")
                        .WithOne("Location")
                        .HasForeignKey("AJS.Data.Models.JobLocation", "JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.JobPicture", b =>
                {
                    b.HasOne("AJS.Data.Models.Job", "Job")
                        .WithOne("Picture")
                        .HasForeignKey("AJS.Data.Models.JobPicture", "PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.JobPrice", b =>
                {
                    b.HasOne("AJS.Data.Models.Job", "Job")
                        .WithMany("Prices")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("AJS.Data.Models.Service", b =>
                {
                    b.HasOne("AJS.Data.Models.ServiceCategory", "Category")
                        .WithMany("Services")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AJS.Data.Models.User", "Creator")
                        .WithMany("Services")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.ServiceCategory", b =>
                {
                    b.HasOne("AJS.Data.Models.ServiceCategory", "ParentServiceCategory")
                        .WithMany("Categories")
                        .HasForeignKey("ParentServiceCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AJS.Data.Models.ServiceDescription", b =>
                {
                    b.HasOne("AJS.Data.Models.Service", "Service")
                        .WithOne("Description")
                        .HasForeignKey("AJS.Data.Models.ServiceDescription", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.ServiceLocation", b =>
                {
                    b.HasOne("AJS.Data.Models.Service", "Service")
                        .WithOne("Location")
                        .HasForeignKey("AJS.Data.Models.ServiceLocation", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.ServicePicture", b =>
                {
                    b.HasOne("AJS.Data.Models.Service", "Service")
                        .WithMany("Pictures")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AJS.Data.Models.ServicePrice", b =>
                {
                    b.HasOne("AJS.Data.Models.Service", "Service")
                        .WithMany("Prices")
                        .HasForeignKey("ServiceId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AJS.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AJS.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AJS.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AJS.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
