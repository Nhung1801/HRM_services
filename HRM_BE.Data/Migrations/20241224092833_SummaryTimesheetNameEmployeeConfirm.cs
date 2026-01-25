using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class SummaryTimesheetNameEmployeeConfirm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e13fff84-2e6e-4562-981e-43eb2f0205c9", "AQAAAAIAAYagAAAAEPNFw04jpx8rd60hrj9GcLuWMwt0o25pso92zgT8UgM89+cjnYbmsxoMALD0kUNd0A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "94c3497e-2205-4452-a5e7-0e3918abcd94", "AQAAAAIAAYagAAAAEAZP626vMvB2HGPAyGm7DPPrS9Q4fN0mofOeUs4Mp9iW41SR5tdv+RYyvxsg8vOY7A==" });
        }
    }
}
