using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_food_api.Migrations
{
    /// <inheritdoc />
    public partial class EditTblTransactionDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                schema: "WH",
                table: "TransactionDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "WH",
                table: "TransactionDetail");
        }
    }
}
