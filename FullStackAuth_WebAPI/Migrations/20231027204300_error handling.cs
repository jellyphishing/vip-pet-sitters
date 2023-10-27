using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class errorhandling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02cbcee2-d2dd-47c8-9e98-a67c59e3e5d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aacb30e-513a-47dc-aeae-a5a9301b7bf0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a460dff0-351e-4e31-b98e-1a2f639b777b", null, "Admin", "ADMIN" },
                    { "c278e7df-3125-49a5-8537-2bc8a9cfa1fd", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a460dff0-351e-4e31-b98e-1a2f639b777b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c278e7df-3125-49a5-8537-2bc8a9cfa1fd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02cbcee2-d2dd-47c8-9e98-a67c59e3e5d8", null, "User", "USER" },
                    { "9aacb30e-513a-47dc-aeae-a5a9301b7bf0", null, "Admin", "ADMIN" }
                });
        }
    }
}
