using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB3943432 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "89056ffd-0c40-43e2-84a7-8fb3920b42fa", "AQAAAAIAAYagAAAAELgk2i3Ma9Cr69fns+U3H3qRoH0672WGfUvGaVcBKyTyxv0rIQU/5zdty+5P0ZIPWg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a688a72-1b59-449e-b852-9af8cceb864d", "AQAAAAIAAYagAAAAEDRzkc5W0FwydY3LUEIyRry/8L96nsNk+ff5yDfNze47K/TsHvEn60mv3+IOJYR0QA==" });
        }
    }
}
