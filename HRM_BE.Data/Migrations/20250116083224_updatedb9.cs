using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedb9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkPiority",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkId",
                table: "Approvals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RemindWork",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    RemindWorkType = table.Column<int>(type: "int", nullable: false),
                    TimeRemindStart = table.Column<double>(type: "float", nullable: true),
                    TimeRemindEnd = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_RemindWork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemindWork_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubWork",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignEmployeeId = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsFinish = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SubWork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubWork_Employees_AssignEmployeeId",
                        column: x => x.AssignEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubWork_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bf93bea7-627c-4ca4-8069-851e6c7a39ce", "AQAAAAIAAYagAAAAECtordlAlg16K3472MQ6ebVn7rNAXuqeZmKHgeQhW1HVrifrYN3gK5DXaHuKvTVSDA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_WorkId",
                table: "Approvals",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_RemindWork_WorkId",
                table: "RemindWork",
                column: "WorkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubWork_AssignEmployeeId",
                table: "SubWork",
                column: "AssignEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubWork_WorkId",
                table: "SubWork",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Works_WorkId",
                table: "Approvals",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Works_WorkId",
                table: "Approvals");

            migrationBuilder.DropTable(
                name: "RemindWork");

            migrationBuilder.DropTable(
                name: "SubWork");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_WorkId",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "WorkPiority",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "Approvals");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "efec26cb-75c8-430d-ade7-2aee9c87fc51", "AQAAAAIAAYagAAAAEBgyh0GmzrupbZTIbP+i1tRO22MoUq8XEtr71xoFTyhA9kSbRXNHT+ljplV/GewAvQ==" });
        }
    }
}
