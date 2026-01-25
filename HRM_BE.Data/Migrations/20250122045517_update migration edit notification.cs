using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatemigrationeditnotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NotificationType",
                table: "RemindWorkNotifications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d76cdf0-4753-4575-b9c6-8c5d80a50562", "AQAAAAIAAYagAAAAEND5CtUwM+Nbaz5zDhyfwlpHiM7BbyhQ9iG8Oj0Bt+XhLA9Ix3OEIAp9i49C6a1XrA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NotificationType",
                table: "RemindWorkNotifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a225fc70-67a3-418c-b80d-526da842f096", "AQAAAAIAAYagAAAAED4qr8zhAnTk8mEoIzN8tljwUQkIlWmwbue+TJJAz51LjgPbgxMsP7WipodLBnUVwA==" });
        }
    }
}
