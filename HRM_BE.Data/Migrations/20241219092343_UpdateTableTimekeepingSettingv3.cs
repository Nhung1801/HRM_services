using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableTimekeepingSettingv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimekeepingLocationId",
                table: "ApplyOrganizations",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa4c1eae-f18d-45fc-9bc4-e8a9dd077f2c", "AQAAAAIAAYagAAAAEN8YMPk15JxRAn1uurxAtSuzVtj/rfH6Gx+dGQXjQ7I6Q3KVc2A51svQnkDQHSMEAA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyOrganizations_TimekeepingLocationId",
                table: "ApplyOrganizations",
                column: "TimekeepingLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyOrganizations_TimekeepingLocations_TimekeepingLocationId",
                table: "ApplyOrganizations",
                column: "TimekeepingLocationId",
                principalTable: "TimekeepingLocations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyOrganizations_TimekeepingLocations_TimekeepingLocationId",
                table: "ApplyOrganizations");

            migrationBuilder.DropIndex(
                name: "IX_ApplyOrganizations_TimekeepingLocationId",
                table: "ApplyOrganizations");

            migrationBuilder.DropColumn(
                name: "TimekeepingLocationId",
                table: "ApplyOrganizations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c097b25d-5159-4106-b422-c840c8aa3b69", "AQAAAAIAAYagAAAAEFmtoglB/0xEqv0+wGcxJ9JLxhL7HXL5RzXxxSR+H+puuxFae1PVafKEpgh3ZtLo+w==" });
        }
    }
}
