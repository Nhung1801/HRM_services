using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB45835 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KpiTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKpiTable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StaffPositionId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_KpiTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KpiTables_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KpiTables_StaffPositions_StaffPositionId",
                        column: x => x.StaffPositionId,
                        principalTable: "StaffPositions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KpiTableDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KpiTableId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletionRate = table.Column<double>(type: "float", nullable: true),
                    Bonus = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_KpiTableDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KpiTableDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KpiTableDetails_KpiTables_KpiTableId",
                        column: x => x.KpiTableId,
                        principalTable: "KpiTables",
                        principalColumn: "Id");
                });

         
            migrationBuilder.CreateIndex(
                name: "IX_KpiTableDetails_EmployeeId",
                table: "KpiTableDetails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_KpiTableDetails_KpiTableId",
                table: "KpiTableDetails",
                column: "KpiTableId");

            migrationBuilder.CreateIndex(
                name: "IX_KpiTables_OrganizationId",
                table: "KpiTables",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_KpiTables_StaffPositionId",
                table: "KpiTables",
                column: "StaffPositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KpiTableDetails");

            migrationBuilder.DropTable(
                name: "KpiTables");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "563e28d1-09d8-4c55-80c6-2136adde6d8a", "AQAAAAIAAYagAAAAEDKQ7RpqY67N4y4kmrpopGs4qWF4kC/T0LWVjFrGkLxpznYS70LM4y8X00Y5VMDWsA==" });
        }
    }
}
