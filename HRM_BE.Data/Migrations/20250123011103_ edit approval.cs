using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class editapproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Employees_ApproverId",
                table: "Approvals");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_ApproverId",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "Approvals");

            migrationBuilder.CreateTable(
                name: "ApprovalEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApprove = table.Column<bool>(type: "bit", nullable: true),
                    RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ApprovalId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ApprovalEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalEmployees_Approvals_ApprovalId",
                        column: x => x.ApprovalId,
                        principalTable: "Approvals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApprovalEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f7e8f247-17d0-4b15-9684-4ccb90bce6c8", "AQAAAAIAAYagAAAAEDdWLV9nQLWKurJhWYW9OP+12GIOvRDXOZIvHXSqzGPbkRPabqwO3nn1vwXOQwRNCw==" });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalEmployees_ApprovalId",
                table: "ApprovalEmployees",
                column: "ApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalEmployees_EmployeeId",
                table: "ApprovalEmployees",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalEmployees");

            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "Approvals",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "980743a3-1eab-4f5a-9d19-0d17ccbe3020", "AQAAAAIAAYagAAAAEAK8gbc+n81KCGLa/8xbVUBDZB3gXTrraZfA+tU02P6EKiLTBnHSCN4iQgO47scfNA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_ApproverId",
                table: "Approvals",
                column: "ApproverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Employees_ApproverId",
                table: "Approvals",
                column: "ApproverId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
