using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "closingTime",
                table: "shop",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "openingTime",
                table: "shop",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "shop",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "closingTime",
                table: "shop");

            migrationBuilder.DropColumn(
                name: "openingTime",
                table: "shop");

            migrationBuilder.DropColumn(
                name: "status",
                table: "shop");
        }
    }
}
