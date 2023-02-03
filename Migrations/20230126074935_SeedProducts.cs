using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 23, 10, 49, 35, 782, DateTimeKind.Local).AddTicks(2502), "test", "bilgisayar", 2500m, 2 },
                    { 2, new DateTime(2022, 11, 24, 10, 49, 35, 782, DateTimeKind.Local).AddTicks(2517), "test", "motorsiklet", 15000m, 2 },
                    { 4, new DateTime(2022, 12, 27, 10, 49, 35, 782, DateTimeKind.Local).AddTicks(2516), "test", "tablet", 1200m, 5 },
                    { 5, new DateTime(2023, 1, 21, 10, 49, 35, 782, DateTimeKind.Local).AddTicks(2518), "test", "kalem", 963m, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
