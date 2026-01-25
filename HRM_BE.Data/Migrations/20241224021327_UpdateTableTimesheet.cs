using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableTimesheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimekeepingTypeId",
                table: "Timesheets");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "94c3497e-2205-4452-a5e7-0e3918abcd94", "AQAAAAIAAYagAAAAEAZP626vMvB2HGPAyGm7DPPrS9Q4fN0mofOeUs4Mp9iW41SR5tdv+RYyvxsg8vOY7A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimekeepingTypeId",
                table: "Timesheets",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e422003a-8b8b-4e0a-921d-bcc5f7afb475", "AQAAAAIAAYagAAAAEKtDPL6Sml1jbwZQ222wBFAnRCTDycCQIC088BPtvmNEuTJvmmDNV/MeXmN+FKaw8A==" });
        }
    }
}
