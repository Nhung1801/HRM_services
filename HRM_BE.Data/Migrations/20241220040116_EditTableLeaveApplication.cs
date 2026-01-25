using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditTableLeaveApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApproverNote",
                table: "LeaveApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e2b6df53-8477-4cfe-aee3-584a7270590c", "AQAAAAIAAYagAAAAECIYS3swBOGJxm3ZAWgws0bG/01Z+VdpQbYdvHDFqDlq/pzLudq9u0AxthS51K24GQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproverNote",
                table: "LeaveApplications");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b8da5e26-0485-45cb-8494-f13a69a4d7d6", "AQAAAAIAAYagAAAAEBTGrOXU3oON0AXR/b2FOywJsEH/nKimvF1FsWQalpg9mx7DNLjiSsWz7ApWOFT0Iw==" });
        }
    }
}
