using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLateAndEarlyLeaveDurationToTimesheetv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b6fac98-e004-4ab4-be64-f8770451ad43", "AQAAAAIAAYagAAAAEC1cSsOdxu6WM+UY1osNRiub+q8bc24oj5UzU60jNE/RRf40SruL+uYHNhqXRRXJGQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b65d8fa7-a763-48c7-8d74-0975de982357", "AQAAAAIAAYagAAAAEFDStR4kSu0ZtHuQ8pXlTS3VaVK6E5XrwIBg01679/LugERlTcEBQ755Bbix6azaXw==" });
        }
    }
}
