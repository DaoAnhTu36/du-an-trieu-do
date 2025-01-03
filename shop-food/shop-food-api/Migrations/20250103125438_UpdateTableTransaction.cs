using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_food_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfImport",
                schema: "WH",
                table: "Transaction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionCode",
                schema: "WH",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfImport",
                schema: "WH",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TransactionCode",
                schema: "WH",
                table: "Transaction");
        }
    }
}
