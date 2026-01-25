using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayrollDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDeadline",
                table: "PayrollDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55855ed2-1b11-4285-a561-6176c9f1679f", "AQAAAAIAAYagAAAAEIoDycaHZcEm3D5RkJFTPF77O1oItyNokjHDPIRiSh1QxDtnwApdL38wapzwc5HcWg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseDeadline",
                table: "PayrollDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17fba287-6b07-4672-9112-16aa29274921", "AQAAAAIAAYagAAAAEGKT6r/3C54ty6CyWfk0YtP6C18F8cX28/OBerG5NyUzuYJWHMM8ugColtCICT82Lg==" });
        }
    }
}
