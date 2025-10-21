using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId1",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId1",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_Products_ProductId1",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_ProductId1",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductId1",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId1",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "CartItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Wishlists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_ProductId1",
                table: "Wishlists",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId1",
                table: "OrderItems",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId1",
                table: "CartItems",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId1",
                table: "CartItems",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId1",
                table: "OrderItems",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_Products_ProductId1",
                table: "Wishlists",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "ProductId");
        }
    }
}
