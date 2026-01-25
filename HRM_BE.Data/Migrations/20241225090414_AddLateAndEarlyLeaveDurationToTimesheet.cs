using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLateAndEarlyLeaveDurationToTimesheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "EarlyLeaveDuration",
                table: "Timesheets",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LateDuration",
                table: "Timesheets",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b65d8fa7-a763-48c7-8d74-0975de982357", "AQAAAAIAAYagAAAAEFDStR4kSu0ZtHuQ8pXlTS3VaVK6E5XrwIBg01679/LugERlTcEBQ755Bbix6azaXw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EarlyLeaveDuration",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "LateDuration",
                table: "Timesheets");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5773abf3-cf1e-4725-8737-70c782be2485", "AQAAAAIAAYagAAAAEEFKnLA4II0R/uFvTPn3L/jWlyYLGkCr928Mcaup4rKoneuIV0/yCLBXll1fqBhN1w==" });
        }
    }
}
