using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePayrollInquiry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "339aa0ff-28e3-42cb-aaaf-38609f0c74f3", "AQAAAAIAAYagAAAAEC8+8M60KfTxllUqtPFNI/XXvZp8IFZvXuo4qlYP7NtN6DsMzc8nqNMDXu8gioIB0Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5efcf59f-0e62-4447-80dd-a1cc2e7d57e7", "AQAAAAIAAYagAAAAEH7qb5TV0K+RLaFJtY5Dq89w8WjN18mslvxXuv++i/HECM+OuATPH6kXjZuHOca16A==" });
        }
    }
}
