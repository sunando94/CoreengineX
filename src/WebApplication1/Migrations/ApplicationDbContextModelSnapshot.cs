using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication1;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("WebApplication1.Models.Attributes", b =>
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

            modelBuilder.Entity("WebApplication1.Models.Business", b =>
                {
                    b.Property<int>("businessID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("businessName");

                    b.Property<int?>("businessThumbimageID");

                    b.HasKey("businessID");

                    b.HasIndex("businessThumbimageID");

                    b.ToTable("businesses");
                });

            modelBuilder.Entity("WebApplication1.Models.Category", b =>
                {
                    b.Property<int>("categoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("categoryName");

                    b.HasKey("categoryID");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("WebApplication1.Models.Image", b =>
                {
                    b.Property<int>("imageID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("businessID");

                    b.Property<string>("imageUrl");

                    b.Property<int?>("itemID");

                    b.HasKey("imageID");

                    b.HasIndex("businessID");

                    b.HasIndex("itemID");

                    b.ToTable("images");
                });

            modelBuilder.Entity("WebApplication1.Models.Item", b =>
                {
                    b.Property<int>("itemID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("businessID");

                    b.Property<string>("itemDescription");

                    b.Property<string>("itemName");

                    b.Property<decimal>("itemPrice");

                    b.Property<int?>("itemThumbimageID");

                    b.HasKey("itemID");

                    b.HasIndex("businessID");

                    b.HasIndex("itemThumbimageID");

                    b.ToTable("items");
                });

            modelBuilder.Entity("WebApplication1.Models.Location", b =>
                {
                    b.Property<int>("locationID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("latitude");

                    b.Property<int>("longitude");

                    b.HasKey("locationID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("WebApplication1.Models.Reviews", b =>
                {
                    b.Property<int>("reviewID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("businessID");

                    b.Property<string>("review");

                    b.Property<string>("userId");

                    b.HasKey("reviewID");

                    b.HasIndex("businessID");

                    b.HasIndex("userId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("WebApplication1.Models.SubCategory", b =>
                {
                    b.Property<int>("subcategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("subCategoryName");

                    b.HasKey("subcategoryID");

                    b.ToTable("subCategories");
                });

            modelBuilder.Entity("WebApplication1.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser");

                    b.Property<int?>("businessID");

                    b.Property<int?>("businessID1");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<int?>("locationID");

                    b.Property<string>("profilepicUrl");

                    b.HasIndex("businessID");

                    b.HasIndex("businessID1");

                    b.HasIndex("locationID");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
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

            modelBuilder.Entity("WebApplication1.Models.Attributes", b =>
                {
                    b.HasOne("WebApplication1.Models.Item")
                        .WithMany("itemAttributes")
                        .HasForeignKey("itemID");
                });

            modelBuilder.Entity("WebApplication1.Models.Business", b =>
                {
                    b.HasOne("WebApplication1.Models.Image", "businessThumb")
                        .WithMany()
                        .HasForeignKey("businessThumbimageID");
                });

            modelBuilder.Entity("WebApplication1.Models.Image", b =>
                {
                    b.HasOne("WebApplication1.Models.Business")
                        .WithMany("businessGallery")
                        .HasForeignKey("businessID");

                    b.HasOne("WebApplication1.Models.Item")
                        .WithMany("itemGallery")
                        .HasForeignKey("itemID");
                });

            modelBuilder.Entity("WebApplication1.Models.Item", b =>
                {
                    b.HasOne("WebApplication1.Models.Business")
                        .WithMany("products")
                        .HasForeignKey("businessID");

                    b.HasOne("WebApplication1.Models.Image", "itemThumb")
                        .WithMany()
                        .HasForeignKey("itemThumbimageID");
                });

            modelBuilder.Entity("WebApplication1.Models.Reviews", b =>
                {
                    b.HasOne("WebApplication1.Models.Business")
                        .WithMany("reviews")
                        .HasForeignKey("businessID");

                    b.HasOne("WebApplication1.Models.ApplicationUser", "user")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("WebApplication1.Models.ApplicationUser", b =>
                {
                    b.HasOne("WebApplication1.Models.Business")
                        .WithMany("followers")
                        .HasForeignKey("businessID");

                    b.HasOne("WebApplication1.Models.Business")
                        .WithMany("ourTeam")
                        .HasForeignKey("businessID1");

                    b.HasOne("WebApplication1.Models.Location", "location")
                        .WithMany()
                        .HasForeignKey("locationID");
                });
        }
    }
}
