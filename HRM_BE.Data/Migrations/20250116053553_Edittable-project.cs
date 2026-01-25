using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class Edittableproject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "efec26cb-75c8-430d-ade7-2aee9c87fc51", "AQAAAAIAAYagAAAAEBgyh0GmzrupbZTIbP+i1tRO22MoUq8XEtr71xoFTyhA9kSbRXNHT+ljplV/GewAvQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "540fbd44-a895-43e5-9c63-25b61239e44f", "AQAAAAIAAYagAAAAEOPyv1LMa7zVA6zInnZFLJL/rJ0w/CyXCrENWVCdecWlTY365SIBjbstDfRgMMdcNw==" });
        }
    }
}
