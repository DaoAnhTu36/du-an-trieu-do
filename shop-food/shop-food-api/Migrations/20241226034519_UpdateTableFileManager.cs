using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_food_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableFileManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "SHOP",
                table: "FileManager",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "SHOP",
                table: "FileManager");
        }
    }
}
