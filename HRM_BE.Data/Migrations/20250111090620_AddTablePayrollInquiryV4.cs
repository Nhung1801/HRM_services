using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePayrollInquiryV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrollInquiries_Employees_EmployeeId",
                table: "PayrollInquiries");

            migrationBuilder.DropIndex(
                name: "IX_PayrollInquiries_EmployeeId",
                table: "PayrollInquiries");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PayrollInquiries");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "540a679d-b3c2-44ca-9e29-ea604476e4b8", "AQAAAAIAAYagAAAAEDUhmGaraPCj9C6nS45bg/hKyb74511KuMaqoxsoWyaqo9ZqMyxEVRsjyQLlNpTfBA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "PayrollInquiries",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ce92a70e-7bed-44cf-9100-1ec17ac2d830", "AQAAAAIAAYagAAAAELrUp6CRCNQDrdKFjWZ2NeP+D6S6JVzUfQizhExKQJYLXHHZeaNB0DNgnjkiaQS/Ug==" });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollInquiries_EmployeeId",
                table: "PayrollInquiries",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollInquiries_Employees_EmployeeId",
                table: "PayrollInquiries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
