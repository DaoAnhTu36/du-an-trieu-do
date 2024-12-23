using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shop_food_authen.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "AdminEntities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "AdminEntities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AdminEntities");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "AdminEntities");
        }
    }
}
