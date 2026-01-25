using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayrollTablev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ba1e5a6c-5039-43f1-96d3-438715ab478d", "AQAAAAIAAYagAAAAEEGSBIQ3blZjkr1f3BRGr63t8pzVAsBbth8pIeANQz5Ptl3llozm0+dLIwryhHVrYw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "545c7026-8b70-49ab-b0ee-77fc45505db2", "AQAAAAIAAYagAAAAEJxzhok3E0Sedinjjep6BP3BOrXPMRXPsmE9ulBBiBFc5/73shCR9mur/CGbuzPrtg==" });
        }
    }
}
