﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using coreenginex;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170305080843_shop")]
    partial class shop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("coreenginex.Models.Attributes", b =>
                {
                    b.Property<int>("attributeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("attributeKey");

                    b.Property<string>("attributeValue");

                    b.Property<int?>("itemID");

                    b.HasKey("attributeID");

                    b.HasIndex("itemID");

                    b.ToTable("attributes");
                });

            modelBuilder.Entity("coreenginex.Models.Business", b =>
                {
                    b.Property<int>("businessID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Id");

                    b.Property<string>("Type");

                    b.Property<string>("UserId");

                    b.Property<string>("alias");

                    b.Property<string>("businessName");

                    b.HasKey("businessID");

                    b.HasIndex("UserId");

                    b.ToTable("businesses");
                });

            modelBuilder.Entity("coreenginex.Models.Category", b =>
                {
                    b.Property<int>("categoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("categoryName");

                    b.HasKey("categoryID");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("coreenginex.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName");

                    b.Property<string>("PocId");

                    b.HasKey("DepartmentID");

                    b.HasIndex("PocId");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("coreenginex.Models.Image", b =>
                {
                    b.Property<int>("imageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("imageUrl");

                    b.Property<int?>("itemID");

                    b.Property<int?>("shopID");

                    b.HasKey("imageID");

                    b.HasIndex("itemID");

                    b.HasIndex("shopID");

                    b.ToTable("images");
                });

            modelBuilder.Entity("coreenginex.Models.Item", b =>
                {
                    b.Property<int>("itemID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("categoryID");

                    b.Property<string>("itemDescription");

                    b.Property<string>("itemName");

                    b.Property<decimal>("itemPrice");

                    b.Property<int?>("itemThumbimageID");

                    b.Property<int?>("shopID");

                    b.Property<int?>("subcategoryID");

                    b.HasKey("itemID");

                    b.HasIndex("categoryID");

                    b.HasIndex("itemThumbimageID");

                    b.HasIndex("shopID");

                    b.HasIndex("subcategoryID");

                    b.ToTable("items");
                });

            modelBuilder.Entity("coreenginex.Models.Location", b =>
                {
                    b.Property<int>("locationID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("latitude");

                    b.Property<double>("longitude");

                    b.HasKey("locationID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("coreenginex.Models.Reviews", b =>
                {
                    b.Property<int>("reviewID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("review");

                    b.Property<int?>("shopID");

                    b.Property<string>("userId");

                    b.HasKey("reviewID");

                    b.HasIndex("shopID");

                    b.HasIndex("userId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("coreenginex.Models.Shop", b =>
                {
                    b.Property<int>("shopID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("businessID");

                    b.Property<int?>("shopThumbimageID");

                    b.HasKey("shopID");

                    b.HasIndex("businessID");

                    b.HasIndex("shopThumbimageID");

                    b.ToTable("shop");
                });

            modelBuilder.Entity("coreenginex.Models.SubCategory", b =>
                {
                    b.Property<int>("subcategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("categoryID");

                    b.Property<string>("subCategoryName");

                    b.HasKey("subcategoryID");

                    b.HasIndex("categoryID");

                    b.ToTable("subCategories");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("coreenginex.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<int?>("locationID");

                    b.Property<string>("profilepicUrl");

                    b.Property<int?>("shopID");

                    b.Property<int?>("shopID1");

                    b.HasIndex("locationID");

                    b.HasIndex("shopID");

                    b.HasIndex("shopID1");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("coreenginex.Models.Attributes", b =>
                {
                    b.HasOne("coreenginex.Models.Item")
                        .WithMany("itemAttributes")
                        .HasForeignKey("itemID");
                });

            modelBuilder.Entity("coreenginex.Models.Business", b =>
                {
                    b.HasOne("coreenginex.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("coreenginex.Models.Department", b =>
                {
                    b.HasOne("coreenginex.Models.ApplicationUser", "Poc")
                        .WithMany()
                        .HasForeignKey("PocId");
                });

            modelBuilder.Entity("coreenginex.Models.Image", b =>
                {
                    b.HasOne("coreenginex.Models.Item")
                        .WithMany("itemGallery")
                        .HasForeignKey("itemID");

                    b.HasOne("coreenginex.Models.Shop")
                        .WithMany("shopGallery")
                        .HasForeignKey("shopID");
                });

            modelBuilder.Entity("coreenginex.Models.Item", b =>
                {
                    b.HasOne("coreenginex.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryID");

                    b.HasOne("coreenginex.Models.Image", "itemThumb")
                        .WithMany()
                        .HasForeignKey("itemThumbimageID");

                    b.HasOne("coreenginex.Models.Shop")
                        .WithMany("products")
                        .HasForeignKey("shopID");

                    b.HasOne("coreenginex.Models.SubCategory", "subCategory")
                        .WithMany()
                        .HasForeignKey("subcategoryID");
                });

            modelBuilder.Entity("coreenginex.Models.Reviews", b =>
                {
                    b.HasOne("coreenginex.Models.Shop")
                        .WithMany("reviews")
                        .HasForeignKey("shopID");

                    b.HasOne("coreenginex.Models.ApplicationUser", "user")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("coreenginex.Models.Shop", b =>
                {
                    b.HasOne("coreenginex.Models.Business")
                        .WithMany("Shops")
                        .HasForeignKey("businessID");

                    b.HasOne("coreenginex.Models.Image", "shopThumb")
                        .WithMany()
                        .HasForeignKey("shopThumbimageID");
                });

            modelBuilder.Entity("coreenginex.Models.SubCategory", b =>
                {
                    b.HasOne("coreenginex.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreenginex.Models.ApplicationUser", b =>
                {
                    b.HasOne("coreenginex.Models.Location", "location")
                        .WithMany()
                        .HasForeignKey("locationID");

                    b.HasOne("coreenginex.Models.Shop")
                        .WithMany("followers")
                        .HasForeignKey("shopID");

                    b.HasOne("coreenginex.Models.Shop")
                        .WithMany("ourTeam")
                        .HasForeignKey("shopID1");
                });
        }
    }
}
