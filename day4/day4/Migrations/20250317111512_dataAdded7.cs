using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace day4.Migrations
{
    /// <inheritdoc />
    public partial class dataAdded7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CreatedDate", "Email", "IsVIP", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@example.com", false, "John Doe" },
                    { 2, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane@example.com", false, "Jane Smith" },
                    { 3, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", false, "Alice Brown" },
                    { 4, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@example.com", false, "Bob White" },
                    { 5, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie@example.com", false, "Charlie Green" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Laptop", 1000m, 25 },
                    { 2, "Phone", 500m, 20 },
                    { 3, "Tablet", 300m, 15 },
                    { 4, "Monitor", 200m, 5 },
                    { 5, "Keyboard", 50m, 25 },
                    { 6, "Mouse", 30m, 30 },
                    { 7, "Headphones", 80m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CustomerId", "IsDeleted", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, false, new DateTime(2025, 3, 10, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, false, new DateTime(2024, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, true, new DateTime(2024, 3, 20, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, false, new DateTime(2025, 3, 25, 9, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, false, new DateTime(2025, 3, 30, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, false, new DateTime(2024, 6, 5, 11, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, false, new DateTime(2024, 7, 10, 17, 10, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 3, 2 },
                    { 3, 2, 2, 1 },
                    { 4, 2, 5, 3 },
                    { 5, 3, 4, 1 },
                    { 6, 3, 7, 1 },
                    { 7, 4, 6, 2 },
                    { 8, 4, 1, 1 },
                    { 9, 5, 3, 1 },
                    { 10, 5, 2, 2 },
                    { 11, 6, 7, 1 },
                    { 12, 6, 5, 1 },
                    { 13, 7, 4, 1 },
                    { 14, 7, 6, 2 },
                    { 15, 7, 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "OrderProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 5);
        }
    }
}
