using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTimekeepingGpsLogV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimekeepingGPSType",
                table: "TimekeepingGpsLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e422003a-8b8b-4e0a-921d-bcc5f7afb475", "AQAAAAIAAYagAAAAEKtDPL6Sml1jbwZQ222wBFAnRCTDycCQIC088BPtvmNEuTJvmmDNV/MeXmN+FKaw8A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimekeepingGPSType",
                table: "TimekeepingGpsLogs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b650420-aa07-43aa-9ef9-c17dbb747824", "AQAAAAIAAYagAAAAEFdXv0qw85Otg5pENJc4IFpoT1DKpBRQ9a0uiVyhMXVJeL77wm9HSaDxZk28o3pOKQ==" });
        }
    }
}
