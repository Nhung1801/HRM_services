using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPayrollStaffPositionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicablePosition",
                table: "Payrolls");

            migrationBuilder.CreateTable(
                name: "PayrollStaffPositions",
                columns: table => new
                {
                    PayrollId = table.Column<int>(type: "int", nullable: false),
                    StaffPositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollStaffPositions", x => new { x.PayrollId, x.StaffPositionId });
                    table.ForeignKey(
                        name: "FK_PayrollStaffPositions_Payrolls_PayrollId",
                        column: x => x.PayrollId,
                        principalTable: "Payrolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollStaffPositions_StaffPositions_StaffPositionId",
                        column: x => x.StaffPositionId,
                        principalTable: "StaffPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aaaebb29-7a5a-40c8-b502-a1ab55988caa", "AQAAAAIAAYagAAAAEKUpoQo7HvpU2UK4JPLlqEmI732Biv8undcteuum3UBJLymc/m5pUNPo8oOyAMbQhQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollStaffPositions_StaffPositionId",
                table: "PayrollStaffPositions",
                column: "StaffPositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayrollStaffPositions");

            migrationBuilder.AddColumn<int>(
                name: "ApplicablePosition",
                table: "Payrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "284dff3c-25e8-42e1-9e74-fbdafcc09a67", "AQAAAAIAAYagAAAAEHDcq1xdHm45TKvolkj6TJ7oOsJy5wxIiJ5km9VzklKaXCfPnm8pyFEVnB2gV/kKiA==" });
        }
    }
}
