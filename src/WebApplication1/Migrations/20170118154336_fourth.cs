using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryID",
                table: "subCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subCategories_categoryID",
                table: "subCategories",
                column: "categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_subCategories_categories_categoryID",
                table: "subCategories",
                column: "categoryID",
                principalTable: "categories",
                principalColumn: "categoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subCategories_categories_categoryID",
                table: "subCategories");

            migrationBuilder.DropIndex(
                name: "IX_subCategories_categoryID",
                table: "subCategories");

            migrationBuilder.DropColumn(
                name: "categoryID",
                table: "subCategories");
        }
    }
}
