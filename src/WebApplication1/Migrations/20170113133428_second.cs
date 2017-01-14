using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "businessID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "businessID1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "locationID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "profilepicUrl",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    categoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    locationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    latitude = table.Column<int>(nullable: false),
                    longitude = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.locationID);
                });

            migrationBuilder.CreateTable(
                name: "subCategories",
                columns: table => new
                {
                    subcategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    subCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subCategories", x => x.subcategoryID);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    imageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    businessID = table.Column<int>(nullable: true),
                    imageUrl = table.Column<string>(nullable: true),
                    itemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.imageID);
                });

            migrationBuilder.CreateTable(
                name: "businesses",
                columns: table => new
                {
                    businessID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    businessName = table.Column<string>(nullable: true),
                    businessThumbimageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businesses", x => x.businessID);
                    table.ForeignKey(
                        name: "FK_businesses_images_businessThumbimageID",
                        column: x => x.businessThumbimageID,
                        principalTable: "images",
                        principalColumn: "imageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    itemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    businessID = table.Column<int>(nullable: true),
                    itemDescription = table.Column<string>(nullable: true),
                    itemName = table.Column<string>(nullable: true),
                    itemPrice = table.Column<decimal>(nullable: false),
                    itemThumbimageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.itemID);
                    table.ForeignKey(
                        name: "FK_items_businesses_businessID",
                        column: x => x.businessID,
                        principalTable: "businesses",
                        principalColumn: "businessID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_items_images_itemThumbimageID",
                        column: x => x.itemThumbimageID,
                        principalTable: "images",
                        principalColumn: "imageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    reviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    businessID = table.Column<int>(nullable: true),
                    review = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.reviewID);
                    table.ForeignKey(
                        name: "FK_reviews_businesses_businessID",
                        column: x => x.businessID,
                        principalTable: "businesses",
                        principalColumn: "businessID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reviews_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attributes",
                columns: table => new
                {
                    attributeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    attributeKey = table.Column<string>(nullable: true),
                    attributeValue = table.Column<string>(nullable: true),
                    itemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attributes", x => x.attributeID);
                    table.ForeignKey(
                        name: "FK_attributes_items_itemID",
                        column: x => x.itemID,
                        principalTable: "items",
                        principalColumn: "itemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_businessID",
                table: "AspNetUsers",
                column: "businessID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_businessID1",
                table: "AspNetUsers",
                column: "businessID1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_locationID",
                table: "AspNetUsers",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_attributes_itemID",
                table: "attributes",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_businesses_businessThumbimageID",
                table: "businesses",
                column: "businessThumbimageID");

            migrationBuilder.CreateIndex(
                name: "IX_images_businessID",
                table: "images",
                column: "businessID");

            migrationBuilder.CreateIndex(
                name: "IX_images_itemID",
                table: "images",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_items_businessID",
                table: "items",
                column: "businessID");

            migrationBuilder.CreateIndex(
                name: "IX_items_itemThumbimageID",
                table: "items",
                column: "itemThumbimageID");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_businessID",
                table: "reviews",
                column: "businessID");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_userId",
                table: "reviews",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_businesses_businessID",
                table: "AspNetUsers",
                column: "businessID",
                principalTable: "businesses",
                principalColumn: "businessID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_businesses_businessID1",
                table: "AspNetUsers",
                column: "businessID1",
                principalTable: "businesses",
                principalColumn: "businessID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Location_locationID",
                table: "AspNetUsers",
                column: "locationID",
                principalTable: "Location",
                principalColumn: "locationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_images_items_itemID",
                table: "images",
                column: "itemID",
                principalTable: "items",
                principalColumn: "itemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_images_businesses_businessID",
                table: "images",
                column: "businessID",
                principalTable: "businesses",
                principalColumn: "businessID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_businesses_businessID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_businesses_businessID1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Location_locationID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_images_items_itemID",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_businesses_images_businessThumbimageID",
                table: "businesses");

            migrationBuilder.DropTable(
                name: "attributes");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "subCategories");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "businesses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_businessID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_businessID1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_locationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "businessID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "businessID1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "locationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "profilepicUrl",
                table: "AspNetUsers");
        }
    }
}
