using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class addprojectIdtoGroupWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "GroupWorks",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5acd783-f95a-472a-a0cf-f63acf965163", "AQAAAAIAAYagAAAAEBmPT7wXL3qUww/90r1k10uGzz8TJ6hBa4m767w6tqSek8knjY3it3wsBdUv/0K6cA==" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupWorks_ProjectId",
                table: "GroupWorks",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWorks_Projects_ProjectId",
                table: "GroupWorks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWorks_Projects_ProjectId",
                table: "GroupWorks");

            migrationBuilder.DropIndex(
                name: "IX_GroupWorks_ProjectId",
                table: "GroupWorks");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "GroupWorks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bf93bea7-627c-4ca4-8069-851e6c7a39ce", "AQAAAAIAAYagAAAAECtordlAlg16K3472MQ6ebVn7rNAXuqeZmKHgeQhW1HVrifrYN3gK5DXaHuKvTVSDA==" });
        }
    }
}
