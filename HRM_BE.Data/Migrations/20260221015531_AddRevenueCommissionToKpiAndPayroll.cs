using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRevenueCommissionToKpiAndPayroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ActualWorkDays",
                table: "PayrollDetails",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CommissionAmount",
                table: "PayrollDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CommissionRate",
                table: "PayrollDetails",
                type: "decimal(9,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Revenue",
                table: "PayrollDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CommissionManualAmount",
                table: "KpiTableDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCommissionManual",
                table: "KpiTableDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Revenue",
                table: "KpiTableDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fef9f03b-697e-49db-a0ce-626ab996179b", "AQAAAAIAAYagAAAAEFVg1aufBr5kvUF6vJDhib7sQD7cYb2OtRo6BFr+pk2zvNnkX81FkKRiXrcwo2GOcQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommissionAmount",
                table: "PayrollDetails");

            migrationBuilder.DropColumn(
                name: "CommissionRate",
                table: "PayrollDetails");

            migrationBuilder.DropColumn(
                name: "Revenue",
                table: "PayrollDetails");

            migrationBuilder.DropColumn(
                name: "CommissionManualAmount",
                table: "KpiTableDetails");

            migrationBuilder.DropColumn(
                name: "IsCommissionManual",
                table: "KpiTableDetails");

            migrationBuilder.DropColumn(
                name: "Revenue",
                table: "KpiTableDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ActualWorkDays",
                table: "PayrollDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "df8ee882-7b9f-41cb-9217-1f3f9026394b", "AQAAAAIAAYagAAAAEMzuKNDEBHC41De2K2Cbq75osI2nDPPOJCIpxFWx4KhWPU8IpHlRIVxs3s7AM+IkDw==" });
        }
    }
}
