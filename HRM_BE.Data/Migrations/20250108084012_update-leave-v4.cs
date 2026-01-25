using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateleavev4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "17fba287-6b07-4672-9112-16aa29274921", "AQAAAAIAAYagAAAAEGKT6r/3C54ty6CyWfk0YtP6C18F8cX28/OBerG5NyUzuYJWHMM8ugColtCICT82Lg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65c024a6-b87b-4db8-8a0d-d6b4fe779a2d", "AQAAAAIAAYagAAAAEMi/d9Au7i0xDwRe2q4OQ5UqSn0tCCsadsibVuzV0ZLi3PDVJRlc6ZE6mlzJSeAYZA==" });
        }
    }
}
