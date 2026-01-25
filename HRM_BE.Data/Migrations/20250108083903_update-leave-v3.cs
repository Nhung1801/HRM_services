using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateleavev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65c024a6-b87b-4db8-8a0d-d6b4fe779a2d", "AQAAAAIAAYagAAAAEMi/d9Au7i0xDwRe2q4OQ5UqSn0tCCsadsibVuzV0ZLi3PDVJRlc6ZE6mlzJSeAYZA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OnPaidLeaveStatus",
                table: "LeaveApplications",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "363b6238-6a09-464e-a3bb-b0b470f375b4", "AQAAAAIAAYagAAAAEHlcB5FN3V0ndYSc7axQ7lej2trccOUR6a99QhR8VD64cJv3oOqCgb5uYwUxowu+rw==" });
        }
    }
}
