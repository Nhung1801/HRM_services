using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayrollTablev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "545c7026-8b70-49ab-b0ee-77fc45505db2", "AQAAAAIAAYagAAAAEJxzhok3E0Sedinjjep6BP3BOrXPMRXPsmE9ulBBiBFc5/73shCR9mur/CGbuzPrtg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d97175c8-cc75-4bb7-997b-54f5f84631e5", "AQAAAAIAAYagAAAAEPf/gqXdL+V9NzOROiOCLpHl5Cu3O+TL5zHnVPZp3qL/whlUpkJ96MHqWAv16iMBfg==" });
        }
    }
}
