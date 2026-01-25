using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSalaryComponentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attribute",
                table: "SalaryComponents",
                newName: "Characteristic");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00beb200-cc8c-469c-8fcd-a4dc8b8d8127", "AQAAAAIAAYagAAAAEOTmxy01GCaWo/mXSgda9z1JrdTfEKDd8HQ5Mc8PFs0U9S+puC5ETsWThPVGbpTs+g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Characteristic",
                table: "SalaryComponents",
                newName: "Attribute");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0b805b6-5ea0-446b-b101-28a97e505bb8", "AQAAAAIAAYagAAAAEEsj4fFtOlrYDEbjmOoFoBU/PEEwAy5XJsvvwBLkcgz4l40RUJK1PuluM4PRkn4ErQ==" });
        }
    }
}
