using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace day5.Migrations
{
    /// <inheritdoc />
    public partial class dataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { 1, "Alpha", new DateTime(2024, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Beta", new DateTime(2024, 3, 2, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Gamma", new DateTime(2024, 3, 3, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Delta", new DateTime(2024, 3, 4, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Epsilon", new DateTime(2024, 3, 5, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Zeta", new DateTime(2024, 3, 6, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Eta", new DateTime(2024, 3, 7, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Theta", new DateTime(2024, 3, 8, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Iota", new DateTime(2024, 3, 9, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Kappa", new DateTime(2024, 3, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DepartmentId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 1, "john@example.com", "John Doe" },
                    { 2, 2, "jane@example.com", "Jane Smith" },
                    { 3, 3, "alice@example.com", "Alice Brown" },
                    { 4, 1, "bob@example.com", "Bob Johnson" },
                    { 5, 2, "charlie@example.com", "Charlie White" },
                    { 6, 3, "david@example.com", "David Black" },
                    { 7, 1, "emma@example.com", "Emma Wilson" },
                    { 8, 2, "frank@example.com", "Frank Adams" },
                    { 9, 3, "grace@example.com", "Grace Harris" },
                    { 10, 1, "hank@example.com", "Hank Miller" },
                    { 11, 2, "ivy@example.com", "Ivy Clark" },
                    { 12, 3, "jack@example.com", "Jack Lewis" },
                    { 13, 1, "kate@example.com", "Kate Scott" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProjects",
                columns: new[] { "EmployeeId", "ProjectId", "Role" },
                values: new object[,]
                {
                    { 1, 1, "Developer" },
                    { 2, 1, "Manager" },
                    { 3, 2, "Tester" },
                    { 3, 5, "Tester" },
                    { 4, 1, "Developer" },
                    { 4, 2, "Developer" },
                    { 5, 3, "Manager" },
                    { 6, 3, "Tester" },
                    { 7, 1, "Developer" },
                    { 7, 2, "Developer" },
                    { 7, 4, "Developer" },
                    { 8, 4, "Manager" },
                    { 9, 5, "Tester" },
                    { 10, 5, "Developer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "EmployeeProjects",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);
        }
    }
}
