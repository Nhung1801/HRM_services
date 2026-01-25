using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayrollTablev4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b530295-b66d-4ff0-81f7-e0d310790cc1", "AQAAAAIAAYagAAAAENQHF1G2+2rA4ovOE9RyimYj00jJhYosXUlhF6WRqmXzRf8+Syl0sG2rFmS0kLGxhw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ba1e5a6c-5039-43f1-96d3-438715ab478d", "AQAAAAIAAYagAAAAEEGSBIQ3blZjkr1f3BRGr63t8pzVAsBbth8pIeANQz5Ptl3llozm0+dLIwryhHVrYw==" });
        }
    }
}
