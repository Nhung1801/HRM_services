using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePayroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payrolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    SummaryTimesheetNameId = table.Column<int>(type: "int", nullable: true),
                    PayrollName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollStatus = table.Column<int>(type: "int", nullable: false),
                    ApplicablePosition = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Payrolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payrolls_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payrolls_SummaryTimesheetNames_SummaryTimesheetNameId",
                        column: x => x.SummaryTimesheetNameId,
                        principalTable: "SummaryTimesheetNames",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Sex" },
                values: new object[] { "a987b326-3273-4eb5-8241-9d415410fa26", "AQAAAAIAAYagAAAAEDYlalKxqgV9IQDjWxaHWWIT8UMhjsVJ9+p9dvayFrseNk8S4m0MGzDhUgG6x7/Uzw==", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_OrganizationId",
                table: "Payrolls",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_SummaryTimesheetNameId",
                table: "Payrolls",
                column: "SummaryTimesheetNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payrolls");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Sex" },
                values: new object[] { "a27b581f-29fd-4278-8db5-ffc335d87c4e", "AQAAAAIAAYagAAAAENQm3TekScpM5bHP4mG9VOOACxQLFMV6dokAj1EZ3azn6ep4wzZKSnvvS3PrsAewkg==", null });
        }
    }
}
