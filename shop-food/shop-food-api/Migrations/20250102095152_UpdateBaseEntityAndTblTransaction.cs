using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_food_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseEntityAndTblTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                schema: "WH",
                table: "Transaction",
                newName: "WarehouseIdTo");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "WH",
                table: "Warehouse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "WH",
                table: "Unit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfExpired",
                schema: "WH",
                table: "Transaction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfManufacture",
                schema: "WH",
                table: "Transaction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "WH",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "WarehouseIdFrom",
                schema: "WH",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "WH",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "WH",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "MD",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "WH",
                table: "Inventory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "SHOP",
                table: "FileManager",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "SHOP",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "WH",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "WH",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "DateOfExpired",
                schema: "WH",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "DateOfManufacture",
                schema: "WH",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "WH",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "WarehouseIdFrom",
                schema: "WH",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "WH",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "WH",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "MD",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "WH",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "SHOP",
                table: "FileManager");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "SHOP",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "WarehouseIdTo",
                schema: "WH",
                table: "Transaction",
                newName: "WarehouseId");
        }
    }
}
