using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class usermodelerrorhandling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1a6e3384-9836-4f95-ad55-bcea0f99dfc0", null, "User", "USER" },
                    { "bb1f0433-ce2d-42da-a3b0-91d4bf56182f", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a6e3384-9836-4f95-ad55-bcea0f99dfc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb1f0433-ce2d-42da-a3b0-91d4bf56182f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a460dff0-351e-4e31-b98e-1a2f639b777b", null, "Admin", "ADMIN" },
                    { "c278e7df-3125-49a5-8537-2bc8a9cfa1fd", null, "User", "USER" }
                });
        }
    }
}
