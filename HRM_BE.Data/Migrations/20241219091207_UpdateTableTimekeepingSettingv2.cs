using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableTimekeepingSettingv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimekeepingType",
                table: "ApplyOrganizations",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c097b25d-5159-4106-b422-c840c8aa3b69", "AQAAAAIAAYagAAAAEFmtoglB/0xEqv0+wGcxJ9JLxhL7HXL5RzXxxSR+H+puuxFae1PVafKEpgh3ZtLo+w==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimekeepingType",
                table: "ApplyOrganizations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5237ab0d-d40d-4e0d-835f-d095f04b1585", "AQAAAAIAAYagAAAAEMXaY8+0flEqVawBcp86ZfrxE9h2SMvBbS/8U4sx4iNCFMAeHOJMhMsFEV6q+LzYMA==" });
        }
    }
}
