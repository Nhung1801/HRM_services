using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditTableLeaveApplicationV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MaximumNumberOfDayOff",
                table: "TypeOfLeaves",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb9cf9be-a6cb-4f7c-aedd-bde6ccc2e6a7", "AQAAAAIAAYagAAAAEOXcLeoHngTlKY7migoq+1DTksVKnR1PdY+0iEfHmvkMc55l8bBXD+NPlG6PzoacrQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaximumNumberOfDayOff",
                table: "TypeOfLeaves",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8468e6e4-3613-4bf8-8ba6-fc847b06e9a7", "AQAAAAIAAYagAAAAELAe485VdlBqNX4fhBHwg06SZtsYluv2WwOXoGIHi1WW13MJPTNgj+WxmSIDhnYJLA==" });
        }
    }
}
