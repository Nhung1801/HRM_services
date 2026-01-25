using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTimekeepingGpsLogV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    IsLate = table.Column<bool>(type: "bit", nullable: false),
                    IsEarlyLeave = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
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
                values: new object[] { "8b650420-aa07-43aa-9ef9-c17dbb747824", "AQAAAAIAAYagAAAAEFdXv0qw85Otg5pENJc4IFpoT1DKpBRQ9a0uiVyhMXVJeL77wm9HSaDxZk28o3pOKQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_TimekeepingGpsLogs_EmployeeId",
                table: "TimekeepingGpsLogs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimekeepingGpsLogs_TimekeepingLocationId",
                table: "TimekeepingGpsLogs",
                column: "TimekeepingLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimekeepingGpsLogs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2f17ce95-cbe8-4512-8bdc-e5d0fd031185", "AQAAAAIAAYagAAAAEBS9Y9cBInmpkQ93/EXlZ2gyQpseoWrrPN+xOPct68cRLTJETZAwuc2naqH22N5xTw==" });
        }
    }
}
