using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopping.Migrations
{
    /// <inheritdoc />
    public partial class createCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_CartItem_CartItemId",
                table: "ProductList");

            migrationBuilder.DropIndex(
                name: "IX_ProductList_CartItemId",
                table: "ProductList");

            migrationBuilder.DropColumn(
                name: "CartItemId",
                table: "ProductList");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductListId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ProductListId",
                table: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "CartItemId",
                table: "ProductList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductList_CartItemId",
                table: "ProductList",
                column: "CartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_CartItem_CartItemId",
                table: "ProductList",
                column: "CartItemId",
                principalTable: "CartItem",
                principalColumn: "Id");
        }
    }
}
