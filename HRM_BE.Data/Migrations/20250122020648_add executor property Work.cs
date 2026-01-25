using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class addexecutorpropertyWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExecutorId",
                table: "Works",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkAssignments",
                columns: table => new
                {
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    AssigneeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAssignments", x => new { x.WorkId, x.AssigneeId });
                    table.ForeignKey(
                        name: "FK_WorkAssignments_Employees_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkAssignments_Works_WorkId",
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
                values: new object[] { "a225fc70-67a3-418c-b80d-526da842f096", "AQAAAAIAAYagAAAAED4qr8zhAnTk8mEoIzN8tljwUQkIlWmwbue+TJJAz51LjgPbgxMsP7WipodLBnUVwA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Works_ExecutorId",
                table: "Works",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAssignments_AssigneeId",
                table: "WorkAssignments",
                column: "AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_ExecutorId",
                table: "Works",
                column: "ExecutorId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_ExecutorId",
                table: "Works");

            migrationBuilder.DropTable(
                name: "WorkAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Works_ExecutorId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "ExecutorId",
                table: "Works");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5481d4e2-61da-4c35-8d24-3eb6fc07df6c", "AQAAAAIAAYagAAAAEAa3acjtu00ZOhak0tOenB4m4HEaGsaXWnjdy5wIntm50i0yV6tTMRaFzKyI/quBMA==" });
        }
    }
}
