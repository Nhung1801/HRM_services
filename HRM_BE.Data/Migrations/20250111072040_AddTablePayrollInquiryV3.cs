using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePayrollInquiryV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrollInquiries_Employees_EmployeeId",
                table: "PayrollInquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrollInquiries_PayrollDetails_PayrollDetailId",
                table: "PayrollInquiries");

            migrationBuilder.AlterColumn<int>(
                name: "PayrollDetailId",
                table: "PayrollInquiries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "PayrollInquiries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "PayrollInquiries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5476bb2b-e18a-4ed7-b151-3e551713100b", "AQAAAAIAAYagAAAAEIgpSkpP6014niARvGYhyOybfHauV7+wvxvU3CdpdHOF9JHfFINpvyy2BrSjm0dqZQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollInquiries_Employees_EmployeeId",
                table: "PayrollInquiries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollInquiries_PayrollDetails_PayrollDetailId",
                table: "PayrollInquiries",
                column: "PayrollDetailId",
                principalTable: "PayrollDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrollInquiries_Employees_EmployeeId",
                table: "PayrollInquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrollInquiries_PayrollDetails_PayrollDetailId",
                table: "PayrollInquiries");

            migrationBuilder.AlterColumn<int>(
                name: "PayrollDetailId",
                table: "PayrollInquiries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "PayrollInquiries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "PayrollInquiries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0305c4e3-0ec9-4fc8-a1c7-c33e2be2f74f", "AQAAAAIAAYagAAAAECed1Nz810PDJNHLtvXBgKLqnvNUTkM7WWPB+bO5hjXkXXgNmUqbwC8OKzaU3sQfAg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollInquiries_Employees_EmployeeId",
                table: "PayrollInquiries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollInquiries_PayrollDetails_PayrollDetailId",
                table: "PayrollInquiries",
                column: "PayrollDetailId",
                principalTable: "PayrollDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
