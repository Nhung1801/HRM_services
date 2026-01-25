using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableWorkFactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f365dfa3-d640-4990-b0dd-9ca258b8216f", "AQAAAAIAAYagAAAAEKugSUIYP3ADoG22EXYP0gXTl6BvLtPfgEolpQKvcNddDhYe1yXsOyWpP5kaefdQNA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa4c1eae-f18d-45fc-9bc4-e8a9dd077f2c", "AQAAAAIAAYagAAAAEN8YMPk15JxRAn1uurxAtSuzVtj/rfH6Gx+dGQXjQ7I6Q3KVc2A51svQnkDQHSMEAA==" });
        }
    }
}
