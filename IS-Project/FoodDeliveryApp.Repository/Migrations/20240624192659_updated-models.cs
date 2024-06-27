using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class updatedmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_customerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryOrders_DeliveryOrdersId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FoodItems_foodItemId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "FoodItemRestaurant");

            migrationBuilder.DropIndex(
                name: "IX_Orders_customerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryOrdersId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryOrdersId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Orders",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "foodItemId",
                table: "Orders",
                newName: "FoodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_foodItemId",
                table: "Orders",
                newName: "IX_Orders_FoodItemId");

            migrationBuilder.AlterColumn<Guid>(
                name: "FoodItemId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryOrderId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "FoodItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "FoodItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "DeliveryOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "DeliveryOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryOrderId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryOrderId",
                table: "Orders",
                column: "DeliveryOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_RestaurantId",
                table: "FoodItems",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DeliveryOrderId",
                table: "AspNetUsers",
                column: "DeliveryOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DeliveryOrders_DeliveryOrderId",
                table: "AspNetUsers",
                column: "DeliveryOrderId",
                principalTable: "DeliveryOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_Restaurants_RestaurantId",
                table: "FoodItems",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryOrders_DeliveryOrderId",
                table: "Orders",
                column: "DeliveryOrderId",
                principalTable: "DeliveryOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FoodItems_FoodItemId",
                table: "Orders",
                column: "FoodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DeliveryOrders_DeliveryOrderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_Restaurants_RestaurantId",
                table: "FoodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryOrders_DeliveryOrderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FoodItems_FoodItemId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryOrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_RestaurantId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DeliveryOrderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "DeliveryOrders");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "DeliveryOrders");

            migrationBuilder.DropColumn(
                name: "DeliveryOrderId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Orders",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "FoodItemId",
                table: "Orders",
                newName: "foodItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_FoodItemId",
                table: "Orders",
                newName: "IX_Orders_foodItemId");

            migrationBuilder.AlterColumn<Guid>(
                name: "foodItemId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryOrdersId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "customerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodItemRestaurant",
                columns: table => new
                {
                    RestaurantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    foodItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemRestaurant", x => new { x.RestaurantsId, x.foodItemsId });
                    table.ForeignKey(
                        name: "FK_FoodItemRestaurant_FoodItems_foodItemsId",
                        column: x => x.foodItemsId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodItemRestaurant_Restaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerId",
                table: "Orders",
                column: "customerId",
                unique: true,
                filter: "[customerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryOrdersId",
                table: "Orders",
                column: "DeliveryOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemRestaurant_foodItemsId",
                table: "FoodItemRestaurant",
                column: "foodItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_customerId",
                table: "Orders",
                column: "customerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryOrders_DeliveryOrdersId",
                table: "Orders",
                column: "DeliveryOrdersId",
                principalTable: "DeliveryOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FoodItems_foodItemId",
                table: "Orders",
                column: "foodItemId",
                principalTable: "FoodItems",
                principalColumn: "Id");
        }
    }
}
