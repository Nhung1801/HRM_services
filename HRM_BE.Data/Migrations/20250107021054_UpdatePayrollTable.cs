using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayrollTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayrollConfirmationStatus",
                table: "Payrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d97175c8-cc75-4bb7-997b-54f5f84631e5", "AQAAAAIAAYagAAAAEPf/gqXdL+V9NzOROiOCLpHl5Cu3O+TL5zHnVPZp3qL/whlUpkJ96MHqWAv16iMBfg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayrollConfirmationStatus",
                table: "Payrolls");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1d120ff9-67c1-4c36-8c38-c2d8b0e91e92", "AQAAAAIAAYagAAAAEL1QGvnlTQ9cDvnVEWr5iNL9GGjWrxpualTN054DrJrBFGIGNbm4rFgElrUy98fZyQ==" });
        }
    }
}
