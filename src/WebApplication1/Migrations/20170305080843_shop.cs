using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Migrations
{
    public partial class shop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_businesses_images_businessThumbimageID",
                table: "businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_images_businesses_businessID",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_items_businesses_businessID",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_businesses_businessID",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_businesses_businessID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_businesses_businessID1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_businesses_businessThumbimageID",
                table: "businesses");

            migrationBuilder.DropColumn(
                name: "businessThumbimageID",
                table: "businesses");

            migrationBuilder.RenameColumn(
                name: "businessID1",
                table: "AspNetUsers",
                newName: "shopID1");

            migrationBuilder.RenameColumn(
                name: "businessID",
                table: "AspNetUsers",
                newName: "shopID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_businessID1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_shopID1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_businessID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_shopID");

            migrationBuilder.RenameColumn(
                name: "businessID",
                table: "reviews",
                newName: "shopID");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_businessID",
                table: "reviews",
                newName: "IX_reviews_shopID");

            migrationBuilder.RenameColumn(
                name: "businessID",
                table: "items",
                newName: "subcategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_items_businessID",
                table: "items",
                newName: "IX_items_subcategoryID");

            migrationBuilder.RenameColumn(
                name: "businessID",
                table: "images",
                newName: "shopID");

            migrationBuilder.RenameIndex(
                name: "IX_images_businessID",
                table: "images",
                newName: "IX_images_shopID");

            migrationBuilder.AddColumn<int>(
                name: "categoryID",
                table: "items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "shopID",
                table: "items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "businesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alias",
                table: "businesses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(nullable: true),
                    PocId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_departments_AspNetUsers_PocId",
                        column: x => x.PocId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shop",
                columns: table => new
                {
                    shopID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    businessID = table.Column<int>(nullable: true),
                    shopThumbimageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop", x => x.shopID);
                    table.ForeignKey(
                        name: "FK_shop_businesses_businessID",
                        column: x => x.businessID,
                        principalTable: "businesses",
                        principalColumn: "businessID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shop_images_shopThumbimageID",
                        column: x => x.shopThumbimageID,
                        principalTable: "images",
                        principalColumn: "imageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_categoryID",
                table: "items",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_items_shopID",
                table: "items",
                column: "shopID");

            migrationBuilder.CreateIndex(
                name: "IX_departments_PocId",
                table: "departments",
                column: "PocId");

            migrationBuilder.CreateIndex(
                name: "IX_shop_businessID",
                table: "shop",
                column: "businessID");

            migrationBuilder.CreateIndex(
                name: "IX_shop_shopThumbimageID",
                table: "shop",
                column: "shopThumbimageID");

            migrationBuilder.AddForeignKey(
                name: "FK_images_shop_shopID",
                table: "images",
                column: "shopID",
                principalTable: "shop",
                principalColumn: "shopID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_items_categories_categoryID",
                table: "items",
                column: "categoryID",
                principalTable: "categories",
                principalColumn: "categoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_items_shop_shopID",
                table: "items",
                column: "shopID",
                principalTable: "shop",
                principalColumn: "shopID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_items_subCategories_subcategoryID",
                table: "items",
                column: "subcategoryID",
                principalTable: "subCategories",
                principalColumn: "subcategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_shop_shopID",
                table: "reviews",
                column: "shopID",
                principalTable: "shop",
                principalColumn: "shopID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_shop_shopID",
                table: "AspNetUsers",
                column: "shopID",
                principalTable: "shop",
                principalColumn: "shopID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_shop_shopID1",
                table: "AspNetUsers",
                column: "shopID1",
                principalTable: "shop",
                principalColumn: "shopID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_shop_shopID",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_items_categories_categoryID",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_items_shop_shopID",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_items_subCategories_subcategoryID",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_shop_shopID",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_shop_shopID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_shop_shopID1",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "shop");

            migrationBuilder.DropIndex(
                name: "IX_items_categoryID",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_shopID",
                table: "items");

            migrationBuilder.DropColumn(
                name: "categoryID",
                table: "items");

            migrationBuilder.DropColumn(
                name: "shopID",
                table: "items");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "businesses");

            migrationBuilder.DropColumn(
                name: "alias",
                table: "businesses");

            migrationBuilder.RenameColumn(
                name: "shopID1",
                table: "AspNetUsers",
                newName: "businessID1");

            migrationBuilder.RenameColumn(
                name: "shopID",
                table: "AspNetUsers",
                newName: "businessID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_shopID1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_businessID1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_shopID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_businessID");

            migrationBuilder.RenameColumn(
                name: "shopID",
                table: "reviews",
                newName: "businessID");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_shopID",
                table: "reviews",
                newName: "IX_reviews_businessID");

            migrationBuilder.RenameColumn(
                name: "subcategoryID",
                table: "items",
                newName: "businessID");

            migrationBuilder.RenameIndex(
                name: "IX_items_subcategoryID",
                table: "items",
                newName: "IX_items_businessID");

            migrationBuilder.RenameColumn(
                name: "shopID",
                table: "images",
                newName: "businessID");

            migrationBuilder.RenameIndex(
                name: "IX_images_shopID",
                table: "images",
                newName: "IX_images_businessID");

            migrationBuilder.AddColumn<int>(
                name: "businessThumbimageID",
                table: "businesses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_businesses_businessThumbimageID",
                table: "businesses",
                column: "businessThumbimageID");

            migrationBuilder.AddForeignKey(
                name: "FK_businesses_images_businessThumbimageID",
                table: "businesses",
                column: "businessThumbimageID",
                principalTable: "images",
                principalColumn: "imageID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_images_businesses_businessID",
                table: "images",
                column: "businessID",
                principalTable: "businesses",
                principalColumn: "businessID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_items_businesses_businessID",
                table: "items",
                column: "businessID",
                principalTable: "businesses",
                principalColumn: "businessID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_businesses_businessID",
                table: "reviews",
                column: "businessID",
                principalTable: "businesses",
                principalColumn: "businessID",
                onDelete: ReferentialAction.Restrict);

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
        }
    }
}
