using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayrollTablev5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_SummaryTimesheetNames_SummaryTimesheetNameId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_SummaryTimesheetNameId",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "SummaryTimesheetNameId",
                table: "Payrolls");

            migrationBuilder.CreateTable(
                name: "PayrollSummaryTimesheets",
                columns: table => new
                {
                    PayrollId = table.Column<int>(type: "int", nullable: false),
                    SummaryTimesheetNameId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PayrollSummaryTimesheets", x => new { x.PayrollId, x.SummaryTimesheetNameId });
                    table.ForeignKey(
                        name: "FK_PayrollSummaryTimesheets_Payrolls_PayrollId",
                        column: x => x.PayrollId,
                        principalTable: "Payrolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollSummaryTimesheets_SummaryTimesheetNames_SummaryTimesheetNameId",
                        column: x => x.SummaryTimesheetNameId,
                        principalTable: "SummaryTimesheetNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fad7f925-11d6-4054-aa8a-ec11aa8ffefd", "AQAAAAIAAYagAAAAEBgX/rdRsVvSOuCyIRePVB+BM7U0n4iI4UzXzwQeY6n1yTkyzOMzhugdN3EVpieuCg==" });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollSummaryTimesheets_SummaryTimesheetNameId",
                table: "PayrollSummaryTimesheets",
                column: "SummaryTimesheetNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayrollSummaryTimesheets");

            migrationBuilder.AddColumn<int>(
                name: "SummaryTimesheetNameId",
                table: "Payrolls",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6ecfa5ce-d43b-4dfb-b24f-a07acd50cb8d", "AQAAAAIAAYagAAAAEIfkOsuHLlSqG8MVss2m4KlsnjX6nwUJG6ypcofmVvYHWjkR68lrFsdyJw0yE6GZiQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_SummaryTimesheetNameId",
                table: "Payrolls",
                column: "SummaryTimesheetNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_SummaryTimesheetNames_SummaryTimesheetNameId",
                table: "Payrolls",
                column: "SummaryTimesheetNameId",
                principalTable: "SummaryTimesheetNames",
                principalColumn: "Id");
        }
    }
}
