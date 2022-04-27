using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopperSquare.DL.Migrations
{
    public partial class InitCart_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Carts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
