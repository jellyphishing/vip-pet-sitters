using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class allaboutme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a6e3384-9836-4f95-ad55-bcea0f99dfc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb1f0433-ce2d-42da-a3b0-91d4bf56182f");

            migrationBuilder.AddColumn<string>(
                name: "AllAboutMe",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36ad0a07-bdc2-479d-857f-a5b1080015a4", null, "Admin", "ADMIN" },
                    { "81486fdf-15f5-420d-9209-a2ef78c1359d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ad0a07-bdc2-479d-857f-a5b1080015a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81486fdf-15f5-420d-9209-a2ef78c1359d");

            migrationBuilder.DropColumn(
                name: "AllAboutMe",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a6e3384-9836-4f95-ad55-bcea0f99dfc0", null, "User", "USER" },
                    { "bb1f0433-ce2d-42da-a3b0-91d4bf56182f", null, "Admin", "ADMIN" }
                });
        }
    }
}
