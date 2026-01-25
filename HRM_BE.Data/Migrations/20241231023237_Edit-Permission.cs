using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Section",
                table: "Permissions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c23ec435-bb22-45b1-9e0e-abb231ea27dc", "AQAAAAIAAYagAAAAELDPp8M2iVPj6QyohSI4Q0ZkwN8n4FIhgvNoHKwWD0qaALr5lAjCNR5TdhL+Cp/yYQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Section",
                table: "Permissions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "563e28d1-09d8-4c55-80c6-2136adde6d8a", "AQAAAAIAAYagAAAAEDKQ7RpqY67N4y4kmrpopGs4qWF4kC/T0LWVjFrGkLxpznYS70LM4y8X00Y5VMDWsA==" });
        }
    }
}
