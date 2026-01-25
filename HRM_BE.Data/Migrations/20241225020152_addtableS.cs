using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtableS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SummaryTimesheetNameEmployeeConfirms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SummaryTimesheetNameId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_SummaryTimesheetNameEmployeeConfirms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryTimesheetNameEmployeeConfirms_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SummaryTimesheetNameEmployeeConfirms_SummaryTimesheetNames_SummaryTimesheetNameId",
                        column: x => x.SummaryTimesheetNameId,
                        principalTable: "SummaryTimesheetNames",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5773abf3-cf1e-4725-8737-70c782be2485", "AQAAAAIAAYagAAAAEEFKnLA4II0R/uFvTPn3L/jWlyYLGkCr928Mcaup4rKoneuIV0/yCLBXll1fqBhN1w==" });

            migrationBuilder.CreateIndex(
                name: "IX_SummaryTimesheetNameEmployeeConfirms_EmployeeId",
                table: "SummaryTimesheetNameEmployeeConfirms",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryTimesheetNameEmployeeConfirms_SummaryTimesheetNameId",
                table: "SummaryTimesheetNameEmployeeConfirms",
                column: "SummaryTimesheetNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummaryTimesheetNameEmployeeConfirms");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e13fff84-2e6e-4562-981e-43eb2f0205c9", "AQAAAAIAAYagAAAAEPNFw04jpx8rd60hrj9GcLuWMwt0o25pso92zgT8UgM89+cjnYbmsxoMALD0kUNd0A==" });
        }
    }
}
