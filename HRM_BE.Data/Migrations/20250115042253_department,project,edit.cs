using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class departmentprojectedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentEmployees_DepartmentRole_DepartmentRoleId",
                table: "DepartmentEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployees_ProjectRole_ProjectRoleId",
                table: "ProjectEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectRole",
                table: "ProjectRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentRole",
                table: "DepartmentRole");

            migrationBuilder.RenameTable(
                name: "ProjectRole",
                newName: "ProjectRoles");

            migrationBuilder.RenameTable(
                name: "DepartmentRole",
                newName: "DepartmentRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectRoles",
                table: "ProjectRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentRoles",
                table: "DepartmentRoles",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b7dda684-fce2-4f99-aa2b-56ae326e5bb1", "AQAAAAIAAYagAAAAEKaZyT5BrXVdfhm4pePgf/WLfSJ8FUXfbf9E84rss7twoNuTtIP+r0I5KcGHq7td+A==" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentEmployees_DepartmentRoles_DepartmentRoleId",
                table: "DepartmentEmployees",
                column: "DepartmentRoleId",
                principalTable: "DepartmentRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployees_ProjectRoles_ProjectRoleId",
                table: "ProjectEmployees",
                column: "ProjectRoleId",
                principalTable: "ProjectRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentEmployees_DepartmentRoles_DepartmentRoleId",
                table: "DepartmentEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployees_ProjectRoles_ProjectRoleId",
                table: "ProjectEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectRoles",
                table: "ProjectRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentRoles",
                table: "DepartmentRoles");

            migrationBuilder.RenameTable(
                name: "ProjectRoles",
                newName: "ProjectRole");

            migrationBuilder.RenameTable(
                name: "DepartmentRoles",
                newName: "DepartmentRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectRole",
                table: "ProjectRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentRole",
                table: "DepartmentRole",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b6dcb54-9204-4322-86f6-f40552fcdc34", "AQAAAAIAAYagAAAAEAo34siAlrJFB6gjzG6IEUjRsI213fTtRqsTHnK1kgEQ6Vy3Jxdi4EteeWF9mEeJGA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentEmployees_DepartmentRole_DepartmentRoleId",
                table: "DepartmentEmployees",
                column: "DepartmentRoleId",
                principalTable: "DepartmentRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployees_ProjectRole_ProjectRoleId",
                table: "ProjectEmployees",
                column: "ProjectRoleId",
                principalTable: "ProjectRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
