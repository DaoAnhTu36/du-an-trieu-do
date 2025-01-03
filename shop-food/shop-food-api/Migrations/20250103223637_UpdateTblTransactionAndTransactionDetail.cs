using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_food_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTblTransactionAndTransactionDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfImport",
                schema: "WH",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                schema: "WH",
                table: "Transaction",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                schema: "WH",
                table: "TransactionDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                schema: "WH",
                table: "Transaction",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfImport",
                schema: "WH",
                table: "Transaction",
                type: "datetime2",
                nullable: true);
        }
    }
}
