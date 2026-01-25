using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class editwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkStatus",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "df8ee882-7b9f-41cb-9217-1f3f9026394b", "AQAAAAIAAYagAAAAEMzuKNDEBHC41De2K2Cbq75osI2nDPPOJCIpxFWx4KhWPU8IpHlRIVxs3s7AM+IkDw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkStatus",
                table: "Works");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0ae25017-2ada-4f86-b0d3-84c3eb0d49ef", "AQAAAAIAAYagAAAAECpjUocZY3PVjjNAkA4JOCejT9BdlwFe4ntWhjvmlWz8GudVgW/Q/hQ8Y3n8RR9K3w==" });
        }
    }
}
