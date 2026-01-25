using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayrollDetailv9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmationDate",
                table: "PayrollDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5efcf59f-0e62-4447-80dd-a1cc2e7d57e7", "AQAAAAIAAYagAAAAEH7qb5TV0K+RLaFJtY5Dq89w8WjN18mslvxXuv++i/HECM+OuATPH6kXjZuHOca16A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationDate",
                table: "PayrollDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55855ed2-1b11-4285-a561-6176c9f1679f", "AQAAAAIAAYagAAAAEIoDycaHZcEm3D5RkJFTPF77O1oItyNokjHDPIRiSh1QxDtnwApdL38wapzwc5HcWg==" });
        }
    }
}
