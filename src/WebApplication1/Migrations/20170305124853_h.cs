using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class h : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_departments_DepartmentID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "businessID",
                table: "departments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "logoimageID",
                table: "businesses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_departments_businessID",
                table: "departments",
                column: "businessID");

            migrationBuilder.CreateIndex(
                name: "IX_businesses_logoimageID",
                table: "businesses",
                column: "logoimageID");

            migrationBuilder.AddForeignKey(
                name: "FK_businesses_images_logoimageID",
                table: "businesses",
                column: "logoimageID",
                principalTable: "images",
                principalColumn: "imageID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_businesses_businessID",
                table: "departments",
                column: "businessID",
                principalTable: "businesses",
                principalColumn: "businessID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_businesses_images_logoimageID",
                table: "businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_businesses_businessID",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_businessID",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_businesses_logoimageID",
                table: "businesses");

            migrationBuilder.DropColumn(
                name: "businessID",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "logoimageID",
                table: "businesses");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentID",
                table: "AspNetUsers",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_departments_DepartmentID",
                table: "AspNetUsers",
                column: "DepartmentID",
                principalTable: "departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
