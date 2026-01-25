using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatetableleaveapplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "LeaveApplications",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55454d33-2e11-461b-a223-33bc1f64bee7", "AQAAAAIAAYagAAAAEBp/OruB/vNTOEi2VDqZFuPRmEBaf3sLUR6eSDDlUH+tbVyEYKpAzbhFS1IZRxNEaA==" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_OrganizationId",
                table: "LeaveApplications",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_Organizations_OrganizationId",
                table: "LeaveApplications",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_Organizations_OrganizationId",
                table: "LeaveApplications");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_OrganizationId",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "LeaveApplications");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6dc588a0-8b2d-435f-868f-568d13aef875", "AQAAAAIAAYagAAAAEJMR8YE9RczE5v19FGt3aG/uunsRckbQIGNSBBRupSu8M0YlpOKF9WF0ddtNT0G/NA==" });
        }
    }
}
