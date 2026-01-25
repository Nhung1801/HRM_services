using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditTableLeaveApplicationV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximumNumberOfDayOff",
                table: "TypeOfLeaveEmployees");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8468e6e4-3613-4bf8-8ba6-fc847b06e9a7", "AQAAAAIAAYagAAAAELAe485VdlBqNX4fhBHwg06SZtsYluv2WwOXoGIHi1WW13MJPTNgj+WxmSIDhnYJLA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaximumNumberOfDayOff",
                table: "TypeOfLeaveEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2b6df53-8477-4cfe-aee3-584a7270590c", "AQAAAAIAAYagAAAAECIYS3swBOGJxm3ZAWgws0bG/01Z+VdpQbYdvHDFqDlq/pzLudq9u0AxthS51K24GQ==" });
        }
    }
}
