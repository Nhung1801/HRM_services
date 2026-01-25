using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB9423 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc7cf307-b64e-4af9-a404-73b6ba5024e9", "AQAAAAIAAYagAAAAEFIA3PsX1PCP7LN3J2hctJt1s6ZicIl2o/eB+1nxaugXWP9IkHPNzYvKbPuIje7N5A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "16f1032b-5a68-454a-96db-2cdd3e600373", "AQAAAAIAAYagAAAAECAzlHzWXhXH/qB5VKv54xMDlXzbfrpp9MgbgY5pWDhSlBPd9jeapGHqQETLbecO3Q==" });
        }
    }
}
