using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateleavev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "363b6238-6a09-464e-a3bb-b0b470f375b4", "AQAAAAIAAYagAAAAEHlcB5FN3V0ndYSc7axQ7lej2trccOUR6a99QhR8VD64cJv3oOqCgb5uYwUxowu+rw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87611048-415f-4d52-a659-886d262564b0", "AQAAAAIAAYagAAAAEFlVCpWkZMMlUKW8HJPGjjDMs5dvIsbDTW6T+/n1S2Y3BawOa2ibkvwsbl5iJgrBew==" });
        }
    }
}
