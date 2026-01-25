using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class editapproal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveDate",
                table: "ApprovalEmployees");

            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "ApprovalEmployees");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6fda44d5-6718-43f9-81fb-f3d4c56b158b", "AQAAAAIAAYagAAAAEPzWpQNubs2RnUNPbQyxU5R1P1hglx+jqQZk0GhNof/OLuQuTw0Wb/PntJC/rP/VcA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApproveDate",
                table: "ApprovalEmployees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "ApprovalEmployees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f7e8f247-17d0-4b15-9684-4ccb90bce6c8", "AQAAAAIAAYagAAAAEDdWLV9nQLWKurJhWYW9OP+12GIOvRDXOZIvHXSqzGPbkRPabqwO3nn1vwXOQwRNCw==" });
        }
    }
}
