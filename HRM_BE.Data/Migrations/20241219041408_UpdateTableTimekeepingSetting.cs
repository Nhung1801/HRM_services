using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableTimekeepingSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timesheets_TimekeepingTypes_TimekeepingTypeId",
                table: "Timesheets");

            migrationBuilder.DropTable(
                name: "TimekeepingTypes");

            migrationBuilder.DropIndex(
                name: "IX_Timesheets_TimekeepingTypeId",
                table: "Timesheets");

            migrationBuilder.AddColumn<int>(
                name: "TimekeepingType",
                table: "Timesheets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimekeepingType",
                table: "TimekeepingSettings",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5237ab0d-d40d-4e0d-835f-d095f04b1585", "AQAAAAIAAYagAAAAEMXaY8+0flEqVawBcp86ZfrxE9h2SMvBbS/8U4sx4iNCFMAeHOJMhMsFEV6q+LzYMA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimekeepingType",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "TimekeepingType",
                table: "TimekeepingSettings");

            migrationBuilder.CreateTable(
                name: "TimekeepingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimekeepingSettingId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimekeepingTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimekeepingTypes_TimekeepingSettings_TimekeepingSettingId",
                        column: x => x.TimekeepingSettingId,
                        principalTable: "TimekeepingSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55454d33-2e11-461b-a223-33bc1f64bee7", "AQAAAAIAAYagAAAAEBp/OruB/vNTOEi2VDqZFuPRmEBaf3sLUR6eSDDlUH+tbVyEYKpAzbhFS1IZRxNEaA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_TimekeepingTypeId",
                table: "Timesheets",
                column: "TimekeepingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimekeepingTypes_TimekeepingSettingId",
                table: "TimekeepingTypes",
                column: "TimekeepingSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timesheets_TimekeepingTypes_TimekeepingTypeId",
                table: "Timesheets",
                column: "TimekeepingTypeId",
                principalTable: "TimekeepingTypes",
                principalColumn: "Id");
        }
    }
}
