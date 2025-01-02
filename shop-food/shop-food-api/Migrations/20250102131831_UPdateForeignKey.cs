using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_food_api.Migrations
{
    /// <inheritdoc />
    public partial class UPdateForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_TransactionDetail_TransactionDetailsId",
                schema: "WH",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "SHOP");

            migrationBuilder.DropIndex(
                name: "IX_Product_TransactionDetailsId",
                schema: "WH",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "TransactionDetailsId",
                schema: "WH",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "TransactionId",
                schema: "WH",
                table: "TransactionDetail",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductsId",
                schema: "WH",
                table: "TransactionDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                schema: "WH",
                table: "TransactionDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SuppliersId",
                schema: "WH",
                table: "TransactionDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitsId",
                schema: "WH",
                table: "TransactionDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_ProductsId",
                schema: "WH",
                table: "TransactionDetail",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_SuppliersId",
                schema: "WH",
                table: "TransactionDetail",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDetail_UnitsId",
                schema: "WH",
                table: "TransactionDetail",
                column: "UnitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetail_Product_ProductsId",
                schema: "WH",
                table: "TransactionDetail",
                column: "ProductsId",
                principalSchema: "WH",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetail_Supplier_SuppliersId",
                schema: "WH",
                table: "TransactionDetail",
                column: "SuppliersId",
                principalSchema: "WH",
                principalTable: "Supplier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionDetail_Unit_UnitsId",
                schema: "WH",
                table: "TransactionDetail",
                column: "UnitsId",
                principalSchema: "WH",
                principalTable: "Unit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetail_Product_ProductsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetail_Supplier_SuppliersId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionDetail_Unit_UnitsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetail_ProductsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetail_SuppliersId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropIndex(
                name: "IX_TransactionDetail_UnitsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropColumn(
                name: "SuppliersId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.DropColumn(
                name: "UnitsId",
                schema: "WH",
                table: "TransactionDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "TransactionId",
                schema: "WH",
                table: "TransactionDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TransactionDetailWhEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
        }
    }
}
