using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB3295425 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KpiTablePositions",
                columns: table => new
                {
                    StaffPositionId = table.Column<int>(type: "int", nullable: false),
                    KpiTableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KpiTablePositions", x => new { x.StaffPositionId, x.KpiTableId });
                    table.ForeignKey(
                        name: "FK_KpiTablePositions_KpiTables_KpiTableId",
                        column: x => x.KpiTableId,
                        principalTable: "KpiTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KpiTablePositions_StaffPositions_StaffPositionId",
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
                values: new object[] { "e022aa6e-6a4f-42d3-9d72-2a0539754679", "AQAAAAIAAYagAAAAEGSUfyRmTKsN8R6TwSFm0HawPZxZT/LNVty6VeSMM3AM7pVcipo7WcwWbty8qHdJ/Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_KpiTablePositions_KpiTableId",
                table: "KpiTablePositions",
                column: "KpiTableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KpiTablePositions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "93dbc8cf-062f-4d30-88f0-d7bc55a17a0d", "AQAAAAIAAYagAAAAEIrsrJq2d9vw6r8S1id/v/Wfsq1olUx+OJaFw0Cr2aqyw0X7687XKvoWmTiDS123UQ==" });
        }
    }
}
