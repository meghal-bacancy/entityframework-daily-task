using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace day4.Migrations
{
    /// <inheritdoc />
    public partial class _3migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 7,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 38, 58, 423, DateTimeKind.Utc).AddTicks(8911));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 2, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2025, 3, 4, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2025, 3, 5, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(9254));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2025, 3, 7, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2025, 3, 9, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2025, 3, 10, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 7,
                column: "OrderDate",
                value: new DateTime(2025, 3, 11, 9, 37, 7, 506, DateTimeKind.Utc).AddTicks(9260));
        }
    }
}
