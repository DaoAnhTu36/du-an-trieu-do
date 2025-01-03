using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_food_api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                schema: "WH",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Unit_UnitId",
                schema: "WH",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Warehouse_WarehouseWhEntityId",
                schema: "WH",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetail_Product_ProductsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetail_Transaction_TransactionsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetail_ProductsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetail_TransactionsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_WarehouseWhEntityId",
                schema: "WH",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Product_SupplierId",
                schema: "WH",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UnitId",
                schema: "WH",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropColumn(
                name: "TransactionsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropColumn(
                name: "WarehouseWhEntityId",
                schema: "WH",
                table: "Transaction");

            migrationBuilder.AddColumn<Guid>(
                name: "UnitWhEntityId",
                schema: "WH",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitWhEntityId",
                schema: "WH",
                table: "Product",
                column: "UnitWhEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitWhEntityId",
                schema: "WH",
                table: "Product",
                column: "UnitWhEntityId",
                principalSchema: "WH",
                principalTable: "Unit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Unit_UnitWhEntityId",
                schema: "WH",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UnitWhEntityId",
                schema: "WH",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UnitWhEntityId",
                schema: "WH",
                table: "Product");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductsId",
                schema: "WH",
                table: "TransactionDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionsId",
                schema: "WH",
                table: "TransactionDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WarehouseWhEntityId",
                schema: "WH",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_ProductsId",
                schema: "WH",
                table: "TransactionDetail",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_TransactionsId",
                schema: "WH",
                table: "TransactionDetail",
                column: "TransactionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_WarehouseWhEntityId",
                schema: "WH",
                table: "Transaction",
                column: "WarehouseWhEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                schema: "WH",
                table: "Product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitId",
                schema: "WH",
                table: "Product",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                schema: "WH",
                table: "Product",
                column: "SupplierId",
                principalSchema: "WH",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                schema: "WH",
                table: "Product",
                column: "UnitId",
                principalSchema: "WH",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Warehouse_WarehouseWhEntityId",
                schema: "WH",
                table: "Transaction",
                column: "WarehouseWhEntityId",
                principalSchema: "WH",
                principalTable: "Warehouse",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetail_Product_ProductsId",
                schema: "WH",
                table: "TransactionDetail",
                column: "ProductsId",
                principalSchema: "WH",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetail_Transaction_TransactionsId",
                schema: "WH",
                table: "TransactionDetail",
                column: "TransactionsId",
                principalSchema: "WH",
                principalTable: "Transaction",
                principalColumn: "Id");
        }
    }
}
