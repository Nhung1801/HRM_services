using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablePayrollV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b3bce30-e067-44fb-b479-68e61bb8f72d", "AQAAAAIAAYagAAAAEIDCHAfsE/pXDsUJQX7CiGXPJ67orBy+L/npnj3V1+ru1LHTilawn+3XkLSl1uKKuA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "540a679d-b3c2-44ca-9e29-ea604476e4b8", "AQAAAAIAAYagAAAAEDUhmGaraPCj9C6nS45bg/hKyb74511KuMaqoxsoWyaqo9ZqMyxEVRsjyQLlNpTfBA==" });
        }
    }
}
