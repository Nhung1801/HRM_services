using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class testmigrationfixbugsnapshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LeavePermissions_EmployeeId",
                table: "LeavePermissions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9e3da35-6ea9-4ca0-a55a-5fcf3b57e874", "AQAAAAIAAYagAAAAEJWNGnOpD2xWjxe/IP2Olp/sUXppF7YVSox+YpdryH+4r27oJCRq/GpyFnvjKeaarQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_LeavePermissions_EmployeeId",
                table: "LeavePermissions",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LeavePermissions_EmployeeId",
                table: "LeavePermissions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c3f1920f-c1d3-4a09-ac18-945c947eedc2", "AQAAAAIAAYagAAAAEP+nMOqPONP6lbcP8EFgzoS/cp4lrnXm2ofPEO4cGojJzMgccYfLIb/hRYzln1V3+A==" });

            migrationBuilder.CreateIndex(
                name: "IX_LeavePermissions_EmployeeId",
                table: "LeavePermissions",
                column: "EmployeeId");
        }
    }
}
