﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace day4.Migrations
{
    /// <inheritdoc />
    public partial class _4migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 804, DateTimeKind.Utc).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 804, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 804, DateTimeKind.Utc).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 804, DateTimeKind.Utc).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 804, DateTimeKind.Utc).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 804, DateTimeKind.Utc).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 805, DateTimeKind.Utc).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 805, DateTimeKind.Utc).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 805, DateTimeKind.Utc).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 805, DateTimeKind.Utc).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 805, DateTimeKind.Utc).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 7,
                column: "OrderDate",
                value: new DateTime(2025, 3, 12, 9, 40, 56, 805, DateTimeKind.Utc).AddTicks(30));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
