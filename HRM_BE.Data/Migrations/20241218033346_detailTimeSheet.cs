using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class detailTimeSheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLock",
                table: "DetailTimesheetNames",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "89c1f6aa-1dde-46d3-9b48-5500188f3b05", "AQAAAAIAAYagAAAAELvWDTXQ3Z1ryXT/OSoC/AZqRdLuIKkAyCLu21baiHB82q3cZn4J6yZ23yuze1UQXQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLock",
                table: "DetailTimesheetNames");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b2a8976-ddda-407e-8ccb-d6331c56f37b", "AQAAAAIAAYagAAAAEDf9M2eZEWmApLQ2l5bdu3Zymv/jxsGL9xt8whN79VDIGXVcFb66bKORbBLkJZPeDA==" });
        }
    }
}
