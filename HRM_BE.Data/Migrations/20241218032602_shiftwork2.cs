using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class shiftwork2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalWork",
                table: "ShiftWorks",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "AvatarUrl",
                value: "/Image/Avatar/AvatarDefault.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b2a8976-ddda-407e-8ccb-d6331c56f37b", "AQAAAAIAAYagAAAAEDf9M2eZEWmApLQ2l5bdu3Zymv/jxsGL9xt8whN79VDIGXVcFb66bKORbBLkJZPeDA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalWork",
                table: "ShiftWorks");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "AvatarUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "731ffd8a-9ad0-480e-9fb8-ce8e78abe8ab", "AQAAAAIAAYagAAAAEM9kFDr48MvkOx8nbTIvqG8gTpKN0z2qhSSvnCY0XBz0k0x1nmtEwYkGRMgLLQ0ZGw==" });
        }
    }
}
