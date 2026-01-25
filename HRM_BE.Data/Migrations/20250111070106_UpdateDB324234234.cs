using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB324234234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "KpiTables",
                newName: "ToDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "KpiTables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ce92a70e-7bed-44cf-9100-1ec17ac2d830", "AQAAAAIAAYagAAAAELrUp6CRCNQDrdKFjWZ2NeP+D6S6JVzUfQizhExKQJYLXHHZeaNB0DNgnjkiaQS/Ug==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "KpiTables");

            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "KpiTables",
                newName: "CreateTime");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5efcf59f-0e62-4447-80dd-a1cc2e7d57e7", "AQAAAAIAAYagAAAAEH7qb5TV0K+RLaFJtY5Dq89w8WjN18mslvxXuv++i/HECM+OuATPH6kXjZuHOca16A==" });
        }
    }
}
