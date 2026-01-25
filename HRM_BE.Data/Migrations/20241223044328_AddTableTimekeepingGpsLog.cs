using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTimekeepingGpsLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2f17ce95-cbe8-4512-8bdc-e5d0fd031185", "AQAAAAIAAYagAAAAEBS9Y9cBInmpkQ93/EXlZ2gyQpseoWrrPN+xOPct68cRLTJETZAwuc2naqH22N5xTw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb9cf9be-a6cb-4f7c-aedd-bde6ccc2e6a7", "AQAAAAIAAYagAAAAEOXcLeoHngTlKY7migoq+1DTksVKnR1PdY+0iEfHmvkMc55l8bBXD+NPlG6PzoacrQ==" });
        }
    }
}
