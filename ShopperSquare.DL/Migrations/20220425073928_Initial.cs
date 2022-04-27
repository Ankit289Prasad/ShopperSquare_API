using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopperSquare.DL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 102, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    MRPAmount = table.Column<int>(nullable: false),
                    DiscountPercentage = table.Column<int>(nullable: false),
                    InStock = table.Column<bool>(nullable: false),
                    MaxOrderAmount = table.Column<int>(nullable: false),
                    InventoryId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Test", "Books" },
                    { 2, "Test", "Games" },
                    { 3, "Test", "Tools" },
                    { 4, "Test", "Mobiles" },
                    { 5, "Test", "Laptops" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "DiscountPercentage", "Image", "InStock", "InventoryId", "MRPAmount", "MaxOrderAmount", "Name" },
                values: new object[,]
                {
                    { 1, 4, 10, "oppo1.png", true, "Mob-oppo-1", 15999, 3, "Oppo Reno 6" },
                    { 2, 4, 10, "vivo1.png", true, "Mob-vivo-1", 15999, 3, "Vivo X" },
                    { 3, 4, 10, "samsung1.png", true, "Mob-Sam-1", 15999, 3, "Samsung M31" },
                    { 4, 4, 10, "IPhone1.png", true, "Mob-iphone-1", 15999, 3, "Iphone 13 Max pro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
