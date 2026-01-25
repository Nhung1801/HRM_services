using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class editsubwworkentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "SubWork",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0ae25017-2ada-4f86-b0d3-84c3eb0d49ef", "AQAAAAIAAYagAAAAECpjUocZY3PVjjNAkA4JOCejT9BdlwFe4ntWhjvmlWz8GudVgW/Q/hQ8Y3n8RR9K3w==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "SubWork");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6fda44d5-6718-43f9-81fb-f3d4c56b158b", "AQAAAAIAAYagAAAAEPzWpQNubs2RnUNPbQyxU5R1P1hglx+jqQZk0GhNof/OLuQuTw0Wb/PntJC/rP/VcA==" });
        }
    }
}
