using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSitterToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b539e0c4-0ad4-4f71-a098-231e2c4bd5ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff5eaff9-d4bf-41ba-a9b7-25f64b67f2c1");

            migrationBuilder.AddColumn<bool>(
                name: "IsSitter",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "daccf9d5-df30-4311-9077-3546936f52e7", null, "User", "USER" },
                    { "f060ab4b-9c73-4e29-8ac3-45fac57a1c90", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daccf9d5-df30-4311-9077-3546936f52e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f060ab4b-9c73-4e29-8ac3-45fac57a1c90");

            migrationBuilder.DropColumn(
                name: "IsSitter",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b539e0c4-0ad4-4f71-a098-231e2c4bd5ae", null, "Admin", "ADMIN" },
                    { "ff5eaff9-d4bf-41ba-a9b7-25f64b67f2c1", null, "User", "USER" }
                });
        }
    }
}
