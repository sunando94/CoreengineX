using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_shop_shopID",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_items_shop_shopID",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_shop_shopID",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_shop_images_shopThumbimageID",
                table: "shop");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_shop_shopID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_shop_shopID1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_shopID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "shopID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "shopID1",
                table: "AspNetUsers",
                newName: "DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_shopID1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_DepartmentID");

            migrationBuilder.RenameColumn(
                name: "shopID",
                table: "reviews",
                newName: "storeID");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_shopID",
                table: "reviews",
                newName: "IX_reviews_storeID");

            migrationBuilder.RenameColumn(
                name: "shopID",
                table: "items",
                newName: "storeID");

            migrationBuilder.RenameIndex(
                name: "IX_items_shopID",
                table: "items",
                newName: "IX_items_storeID");

            migrationBuilder.RenameColumn(
                name: "shopID",
                table: "images",
                newName: "storeID");

            migrationBuilder.RenameIndex(
                name: "IX_images_shopID",
                table: "images",
                newName: "IX_images_storeID");

            migrationBuilder.RenameColumn(
                name: "shopThumbimageID",
                table: "shop",
                newName: "storeThumbimageID");

            migrationBuilder.RenameColumn(
                name: "shopID",
                table: "shop",
                newName: "storeID");

            migrationBuilder.RenameIndex(
                name: "IX_shop_shopThumbimageID",
                table: "shop",
                newName: "IX_shop_storeThumbimageID");

            migrationBuilder.AddColumn<decimal>(
                name: "rating",
                table: "reviews",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "locationID",
                table: "shop",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "totalRating",
                table: "shop",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "StoreApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    storeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreApplicationUser", x => new { x.Id, x.storeID });
                    table.ForeignKey(
                        name: "FK_StoreApplicationUser_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreApplicationUser_shop_storeID",
                        column: x => x.storeID,
                        principalTable: "shop",
                        principalColumn: "storeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shop_locationID",
                table: "shop",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_StoreApplicationUser_storeID",
                table: "StoreApplicationUser",
                column: "storeID");

            migrationBuilder.AddForeignKey(
                name: "FK_images_shop_storeID",
                table: "images",
                column: "storeID",
                principalTable: "shop",
                principalColumn: "storeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_items_shop_storeID",
                table: "items",
                column: "storeID",
                principalTable: "shop",
                principalColumn: "storeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_shop_storeID",
                table: "reviews",
                column: "storeID",
                principalTable: "shop",
                principalColumn: "storeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shop_Location_locationID",
                table: "shop",
                column: "locationID",
                principalTable: "Location",
                principalColumn: "locationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shop_images_storeThumbimageID",
                table: "shop",
                column: "storeThumbimageID",
                principalTable: "images",
                principalColumn: "imageID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_departments_DepartmentID",
                table: "AspNetUsers",
                column: "DepartmentID",
                principalTable: "departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_shop_storeID",
                table: "images");

            migrationBuilder.DropForeignKey(
                name: "FK_items_shop_storeID",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_shop_storeID",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_shop_Location_locationID",
                table: "shop");

            migrationBuilder.DropForeignKey(
                name: "FK_shop_images_storeThumbimageID",
                table: "shop");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_departments_DepartmentID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StoreApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_shop_locationID",
                table: "shop");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "locationID",
                table: "shop");

            migrationBuilder.DropColumn(
                name: "totalRating",
                table: "shop");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "AspNetUsers",
                newName: "shopID1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_DepartmentID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_shopID1");

            migrationBuilder.RenameColumn(
                name: "storeID",
                table: "reviews",
                newName: "shopID");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_storeID",
                table: "reviews",
                newName: "IX_reviews_shopID");

            migrationBuilder.RenameColumn(
                name: "storeID",
                table: "items",
                newName: "shopID");

            migrationBuilder.RenameIndex(
                name: "IX_items_storeID",
                table: "items",
                newName: "IX_items_shopID");

            migrationBuilder.RenameColumn(
                name: "storeID",
                table: "images",
                newName: "shopID");

            migrationBuilder.RenameIndex(
                name: "IX_images_storeID",
                table: "images",
                newName: "IX_images_shopID");

            migrationBuilder.RenameColumn(
                name: "storeThumbimageID",
                table: "shop",
                newName: "shopThumbimageID");

            migrationBuilder.RenameColumn(
                name: "storeID",
                table: "shop",
                newName: "shopID");

            migrationBuilder.RenameIndex(
                name: "IX_shop_storeThumbimageID",
                table: "shop",
                newName: "IX_shop_shopThumbimageID");

            migrationBuilder.AddColumn<int>(
                name: "shopID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_shopID",
                table: "AspNetUsers",
                column: "shopID");

            migrationBuilder.AddForeignKey(
                name: "FK_images_shop_shopID",
                table: "images",
                column: "shopID",
                principalTable: "shop",
                principalColumn: "shopID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_items_shop_shopID",
                table: "items",
                column: "shopID",
                principalTable: "shop",
                principalColumn: "shopID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_shop_shopID",
                table: "reviews",
                column: "shopID",
                principalTable: "shop",
                principalColumn: "shopID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shop_images_shopThumbimageID",
                table: "shop",
                column: "shopThumbimageID",
                principalTable: "images",
                principalColumn: "imageID",
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
    }
}
