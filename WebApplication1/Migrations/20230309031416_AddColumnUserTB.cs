using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnUserTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Userid",
                keyValue: "d8bbdb3d-c158-4cde-8690-8b5de17e957b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Userid",
                keyValue: "e53c0fc8-ab11-433c-b747-7003f60b2db5");

            migrationBuilder.AddColumn<string>(
                name: "LinkActive",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Userid", "Email", "IsActive", "LinkActive", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { "0e439f82-fc87-4294-8302-010a3e8b25cd", "nva@gmail.com", false, null, "Nguyen Van A", "123", "user" },
                    { "fba3973c-05dc-40b6-8242-12e4d0a8c19e", "lmtuan@gmail.com", false, null, "Le Minh Tuan", "123", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Userid",
                keyValue: "0e439f82-fc87-4294-8302-010a3e8b25cd");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Userid",
                keyValue: "fba3973c-05dc-40b6-8242-12e4d0a8c19e");

            migrationBuilder.DropColumn(
                name: "LinkActive",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Userid", "Email", "IsActive", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { "d8bbdb3d-c158-4cde-8690-8b5de17e957b", "lmtuan@gmail.com", false, "Le Minh Tuan", "123", "admin" },
                    { "e53c0fc8-ab11-433c-b747-7003f60b2db5", "nva@gmail.com", false, "Nguyen Van A", "123", "user" }
                });
        }
    }
}
