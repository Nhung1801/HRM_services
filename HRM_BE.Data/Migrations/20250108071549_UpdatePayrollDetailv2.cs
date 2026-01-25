using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayrollDetailv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "96a8f233-b8e7-4c99-8a6e-34c2ce01b872", "AQAAAAIAAYagAAAAEB96slWSQc328/y1fEYNpesx1e0sKXJezIlfdXI9OPG5JNByCdxyroYO022pTogqQQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aaaebb29-7a5a-40c8-b502-a1ab55988caa", "AQAAAAIAAYagAAAAEKUpoQo7HvpU2UK4JPLlqEmI732Biv8undcteuum3UBJLymc/m5pUNPo8oOyAMbQhQ==" });
        }
    }
}
