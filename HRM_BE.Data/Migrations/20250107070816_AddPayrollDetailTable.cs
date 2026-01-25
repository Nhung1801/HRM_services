using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPayrollDetailTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayrollDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayrollId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StandardWorkDays = table.Column<int>(type: "int", nullable: true),
                    ActualWorkDays = table.Column<int>(type: "int", nullable: true),
                    ReceivedSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KPI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KpiPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KpiSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Bonus = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SocialInsurance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnionFund = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalaryRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalReceivedSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConfirmationStatus = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PayrollDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollDetails_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PayrollDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PayrollDetails_Payrolls_PayrollId",
                        column: x => x.PayrollId,
                        principalTable: "Payrolls",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6c2a364-07f2-4669-b952-d2e466fe8350", "AQAAAAIAAYagAAAAENz0QdGqVuYKjbLB0E1QG9wcJUotoT+LdR8ZDLQnrl/n35LV809Dzs8bW7l/4+xWKw==" });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollDetails_ContractId",
                table: "PayrollDetails",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollDetails_EmployeeId",
                table: "PayrollDetails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollDetails_PayrollId",
                table: "PayrollDetails",
                column: "PayrollId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayrollDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "77720322-695c-4c1c-b0d0-b73020d91da0", "AQAAAAIAAYagAAAAELdtdjFu54lUIFWvB1ANlv1qaIIisfyPygaUKlPP1cbeyiACd2PHGrismUBwy1dUQA==" });
        }
    }
}
