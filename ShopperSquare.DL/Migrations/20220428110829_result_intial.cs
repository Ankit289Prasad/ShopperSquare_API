using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopperSquare.DL.Migrations
{
    public partial class result_intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "itemCount",
                table: "Carts",
                newName: "ItemCount");

            migrationBuilder.RenameColumn(
                name: "cartId",
                table: "Carts",
                newName: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemCount",
                table: "Carts",
                newName: "itemCount");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Carts",
                newName: "cartId");
        }
    }
}
