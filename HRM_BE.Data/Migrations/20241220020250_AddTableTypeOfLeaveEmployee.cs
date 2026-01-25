using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTypeOfLeaveEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeOfLeaveEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfLeaveId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    DaysRemaining = table.Column<double>(type: "float", nullable: true),
                    MaximumNumberOfDayOff = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_TypeOfLeaveEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeOfLeaveEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TypeOfLeaveEmployees_TypeOfLeaves_TypeOfLeaveId",
                        column: x => x.TypeOfLeaveId,
                        principalTable: "TypeOfLeaves",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b8da5e26-0485-45cb-8494-f13a69a4d7d6", "AQAAAAIAAYagAAAAEBTGrOXU3oON0AXR/b2FOywJsEH/nKimvF1FsWQalpg9mx7DNLjiSsWz7ApWOFT0Iw==" });

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfLeaveEmployees_EmployeeId",
                table: "TypeOfLeaveEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfLeaveEmployees_TypeOfLeaveId",
                table: "TypeOfLeaveEmployees",
                column: "TypeOfLeaveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeOfLeaveEmployees");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e90c0043-4abe-485e-95b2-f98a65335d7f", "AQAAAAIAAYagAAAAEAX30m7gNi1hspr/5Fwth6suMFz2SEFdD8oSCzBcZnCsINt9u3+M5EP86Cmr/z7ITQ==" });
        }
    }
}
