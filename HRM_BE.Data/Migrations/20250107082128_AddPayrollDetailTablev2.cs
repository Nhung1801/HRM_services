using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPayrollDetailTablev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractTypeStatus",
                table: "PayrollDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "PayrollDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCode",
                table: "PayrollDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "PayrollDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "PayrollDetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6ecfa5ce-d43b-4dfb-b24f-a07acd50cb8d", "AQAAAAIAAYagAAAAEIfkOsuHLlSqG8MVss2m4KlsnjX6nwUJG6ypcofmVvYHWjkR68lrFsdyJw0yE6GZiQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollDetails_OrganizationId",
                table: "PayrollDetails",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollDetails_Organizations_OrganizationId",
                table: "PayrollDetails",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayrollDetails_Organizations_OrganizationId",
                table: "PayrollDetails");

            migrationBuilder.DropIndex(
                name: "IX_PayrollDetails_OrganizationId",
                table: "PayrollDetails");

            migrationBuilder.DropColumn(
                name: "ContractTypeStatus",
                table: "PayrollDetails");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "PayrollDetails");

            migrationBuilder.DropColumn(
                name: "EmployeeCode",
                table: "PayrollDetails");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "PayrollDetails");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "PayrollDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6c2a364-07f2-4669-b952-d2e466fe8350", "AQAAAAIAAYagAAAAENz0QdGqVuYKjbLB0E1QG9wcJUotoT+LdR8ZDLQnrl/n35LV809Dzs8bW7l/4+xWKw==" });
        }
    }
}
