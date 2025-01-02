using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_food_api.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TransactionsId",
                schema: "WH",
                table: "TransactionDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionDetailsId",
                schema: "WH",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "SHOP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransactionDetailWhEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_TransactionDetail_TransactionDetailWhEntityId",
                        column: x => x.TransactionDetailWhEntityId,
                        principalSchema: "WH",
                        principalTable: "TransactionDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_TransactionsId",
                schema: "WH",
                table: "TransactionDetail",
                column: "TransactionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TransactionDetailsId",
                schema: "WH",
                table: "Product",
                column: "TransactionDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TransactionDetailWhEntityId",
                schema: "SHOP",
                table: "Product",
                column: "TransactionDetailWhEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_TransactionDetail_TransactionDetailsId",
                schema: "WH",
                table: "Product",
                column: "TransactionDetailsId",
                principalSchema: "WH",
                principalTable: "TransactionDetail",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_TransactionDetail_TransactionDetailsId",
                schema: "WH",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetail_Transaction_TransactionsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "SHOP");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetail_TransactionsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropIndex(
                name: "IX_Product_TransactionDetailsId",
                schema: "WH",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "TransactionsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropColumn(
                name: "TransactionDetailsId",
                schema: "WH",
                table: "Product");
        }
    }
}
