using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class updateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_address_AddressID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "AspNetUsers",
                newName: "permanentAddressAddressID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AddressID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_permanentAddressAddressID");

            migrationBuilder.AddColumn<int>(
                name: "currentAddressAddressID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_currentAddressAddressID",
                table: "AspNetUsers",
                column: "currentAddressAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_address_currentAddressAddressID",
                table: "AspNetUsers",
                column: "currentAddressAddressID",
                principalTable: "address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_address_permanentAddressAddressID",
                table: "AspNetUsers",
                column: "permanentAddressAddressID",
                principalTable: "address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_address_currentAddressAddressID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_address_permanentAddressAddressID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_currentAddressAddressID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "currentAddressAddressID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "permanentAddressAddressID",
                table: "AspNetUsers",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_permanentAddressAddressID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_address_AddressID",
                table: "AspNetUsers",
                column: "AddressID",
                principalTable: "address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
