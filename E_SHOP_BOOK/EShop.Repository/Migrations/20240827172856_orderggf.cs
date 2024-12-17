using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Repository.Migrations
{
    /// <inheritdoc />
    public partial class orderggf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInOrder_Orders_OrderId",
                table: "BookInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInShoppingCarts_Books_BookId",
                table: "BookInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "BookInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_userId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_OwnerId",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookInShoppingCarts",
                table: "BookInShoppingCarts");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "BookInShoppingCarts",
                newName: "BookInShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_OwnerId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_userId",
                table: "Order",
                newName: "IX_Order_userId");

            migrationBuilder.RenameIndex(
                name: "IX_BookInShoppingCarts_ShoppingCartId",
                table: "BookInShoppingCart",
                newName: "IX_BookInShoppingCart_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_BookInShoppingCarts_BookId",
                table: "BookInShoppingCart",
                newName: "IX_BookInShoppingCart_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookInShoppingCart",
                table: "BookInShoppingCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookInOrder_Order_OrderId",
                table: "BookInOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInShoppingCart_Books_BookId",
                table: "BookInShoppingCart",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInShoppingCart_ShoppingCart_ShoppingCartId",
                table: "BookInShoppingCart",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_userId",
                table: "Order",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_OwnerId",
                table: "ShoppingCart",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInOrder_Order_OrderId",
                table: "BookInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInShoppingCart_Books_BookId",
                table: "BookInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInShoppingCart_ShoppingCart_ShoppingCartId",
                table: "BookInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_userId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_OwnerId",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookInShoppingCart",
                table: "BookInShoppingCart");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "BookInShoppingCart",
                newName: "BookInShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_OwnerId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_userId",
                table: "Orders",
                newName: "IX_Orders_userId");

            migrationBuilder.RenameIndex(
                name: "IX_BookInShoppingCart_ShoppingCartId",
                table: "BookInShoppingCarts",
                newName: "IX_BookInShoppingCarts_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_BookInShoppingCart_BookId",
                table: "BookInShoppingCarts",
                newName: "IX_BookInShoppingCarts_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookInShoppingCarts",
                table: "BookInShoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookInOrder_Orders_OrderId",
                table: "BookInOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInShoppingCarts_Books_BookId",
                table: "BookInShoppingCarts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "BookInShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_userId",
                table: "Orders",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_OwnerId",
                table: "ShoppingCarts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
