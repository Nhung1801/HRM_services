using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayrollTablev6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PayrollSummaryTimesheets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PayrollSummaryTimesheets");

            migrationBuilder.DropColumn(
                name: "CreatedName",
                table: "PayrollSummaryTimesheets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PayrollSummaryTimesheets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PayrollSummaryTimesheets");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PayrollSummaryTimesheets");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PayrollSummaryTimesheets");

            migrationBuilder.DropColumn(
                name: "UpdatedName",
                table: "PayrollSummaryTimesheets");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "284dff3c-25e8-42e1-9e74-fbdafcc09a67", "AQAAAAIAAYagAAAAEHDcq1xdHm45TKvolkj6TJ7oOsJy5wxIiJ5km9VzklKaXCfPnm8pyFEVnB2gV/kKiA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PayrollSummaryTimesheets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "PayrollSummaryTimesheets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedName",
                table: "PayrollSummaryTimesheets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PayrollSummaryTimesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PayrollSummaryTimesheets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PayrollSummaryTimesheets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "PayrollSummaryTimesheets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedName",
                table: "PayrollSummaryTimesheets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fad7f925-11d6-4054-aa8a-ec11aa8ffefd", "AQAAAAIAAYagAAAAEBgX/rdRsVvSOuCyIRePVB+BM7U0n4iI4UzXzwQeY6n1yTkyzOMzhugdN3EVpieuCg==" });
        }
    }
}
