using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class shopUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryID",
                table: "businesses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "subcategoryID",
                table: "businesses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_businesses_categoryID",
                table: "businesses",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_businesses_subcategoryID",
                table: "businesses",
                column: "subcategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_businesses_categories_categoryID",
                table: "businesses",
                column: "categoryID",
                principalTable: "categories",
                principalColumn: "categoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_businesses_subCategories_subcategoryID",
                table: "businesses",
                column: "subcategoryID",
                principalTable: "subCategories",
                principalColumn: "subcategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_businesses_categories_categoryID",
                table: "businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_businesses_subCategories_subcategoryID",
                table: "businesses");

            migrationBuilder.DropIndex(
                name: "IX_businesses_categoryID",
                table: "businesses");

            migrationBuilder.DropIndex(
                name: "IX_businesses_subcategoryID",
                table: "businesses");

            migrationBuilder.DropColumn(
                name: "categoryID",
                table: "businesses");

            migrationBuilder.DropColumn(
                name: "subcategoryID",
                table: "businesses");
        }
    }
}
