using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProgram3.Migrations
{
    public partial class cartitemv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "ShoppingCartItems",
                newName: "ShopCartId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ShoppingCartItems",
                newName: "Id");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "ShoppingCartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "ShopCartId",
                table: "ShoppingCartItems",
                newName: "CartId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ShoppingCartItems",
                newName: "ItemId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ShoppingCartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
