using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB432742 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KpiTables_StaffPositions_StaffPositionId",
                table: "KpiTables");

            migrationBuilder.DropIndex(
                name: "IX_KpiTables_StaffPositionId",
                table: "KpiTables");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "16f1032b-5a68-454a-96db-2cdd3e600373", "AQAAAAIAAYagAAAAECAzlHzWXhXH/qB5VKv54xMDlXzbfrpp9MgbgY5pWDhSlBPd9jeapGHqQETLbecO3Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e022aa6e-6a4f-42d3-9d72-2a0539754679", "AQAAAAIAAYagAAAAEGSUfyRmTKsN8R6TwSFm0HawPZxZT/LNVty6VeSMM3AM7pVcipo7WcwWbty8qHdJ/Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_KpiTables_StaffPositionId",
                table: "KpiTables",
                column: "StaffPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_KpiTables_StaffPositions_StaffPositionId",
                table: "KpiTables",
                column: "StaffPositionId",
                principalTable: "StaffPositions",
                principalColumn: "Id");
        }
    }
}
