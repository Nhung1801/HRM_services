using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSalaryComponentTablev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SalaryComponents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4213f371-d6c4-4ea2-92b5-b7f001e35fb2", "AQAAAAIAAYagAAAAEJKFBWFy0x3wAPvHXOTA3GtYaswChnq3NSgUy/zP99tcxBNWilnyVxnZXioJnZ15qQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SalaryComponents");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00beb200-cc8c-469c-8fcd-a4dc8b8d8127", "AQAAAAIAAYagAAAAEOTmxy01GCaWo/mXSgda9z1JrdTfEKDd8HQ5Mc8PFs0U9S+puC5ETsWThPVGbpTs+g==" });
        }
    }
}
