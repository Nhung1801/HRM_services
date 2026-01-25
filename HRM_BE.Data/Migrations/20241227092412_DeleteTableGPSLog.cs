using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTableGPSLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimekeepingGpsLogs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "893da04f-e608-40d7-9b15-291812fab099", "AQAAAAIAAYagAAAAENR3PH7YU9kKmCcpCDfUbBpgW4AqTD+dtABWSqlx8kJGNNlpvLAaxnMOQygOb/t6Ug==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimekeepingGpsLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    TimekeepingLocationId = table.Column<int>(type: "int", nullable: true),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IsEarlyLeave = table.Column<bool>(type: "bit", nullable: false),
                    IsLate = table.Column<bool>(type: "bit", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    TimekeepingGPSType = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimekeepingGpsLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimekeepingGpsLogs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TimekeepingGpsLogs_TimekeepingLocations_TimekeepingLocationId",
                        column: x => x.TimekeepingLocationId,
                        principalTable: "TimekeepingLocations",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b6fac98-e004-4ab4-be64-f8770451ad43", "AQAAAAIAAYagAAAAEC1cSsOdxu6WM+UY1osNRiub+q8bc24oj5UzU60jNE/RRf40SruL+uYHNhqXRRXJGQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_TimekeepingGpsLogs_EmployeeId",
                table: "TimekeepingGpsLogs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimekeepingGpsLogs_TimekeepingLocationId",
                table: "TimekeepingGpsLogs",
                column: "TimekeepingLocationId");
        }
    }
}
