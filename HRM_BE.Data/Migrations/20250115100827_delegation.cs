using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class delegation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delegation_Employees_EmployeeId",
                table: "Delegation");

            migrationBuilder.DropForeignKey(
                name: "FK_DelegationEmployee_Delegation_DelegationId",
                table: "DelegationEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_DelegationEmployee_Employees_EmployeeId",
                table: "DelegationEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_DelegationProject_Delegation_DelegationId",
                table: "DelegationProject");

            migrationBuilder.DropForeignKey(
                name: "FK_DelegationProject_Projects_ProjectId",
                table: "DelegationProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DelegationProject",
                table: "DelegationProject");

            migrationBuilder.DropIndex(
                name: "IX_DelegationProject_DelegationId",
                table: "DelegationProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DelegationEmployee",
                table: "DelegationEmployee");

            migrationBuilder.DropIndex(
                name: "IX_DelegationEmployee_DelegationId",
                table: "DelegationEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Delegation",
                table: "Delegation");

            migrationBuilder.RenameTable(
                name: "DelegationProject",
                newName: "DelegationProjects");

            migrationBuilder.RenameTable(
                name: "DelegationEmployee",
                newName: "DelegationEmployees");

            migrationBuilder.RenameTable(
                name: "Delegation",
                newName: "Delegations");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Delegations",
                newName: "EmployeeDelegationId");

            migrationBuilder.RenameIndex(
                name: "IX_Delegation_EmployeeId",
                table: "Delegations",
                newName: "IX_Delegations_EmployeeDelegationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DelegationProjects",
                table: "DelegationProjects",
                columns: new[] { "DelegationId", "ProjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DelegationEmployees",
                table: "DelegationEmployees",
                columns: new[] { "DelegationId", "EmployeeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delegations",
                table: "Delegations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "04060baa-d2ff-44a8-8d1d-bc8f3bb6ff57", "AQAAAAIAAYagAAAAEIx7MkEviMxxhcSYxdwJnHMbYHYlryFH29ckPIr3PnHsOfJSXM285XVgnAxQ1CZUxg==" });

            migrationBuilder.CreateIndex(
                name: "IX_DelegationProjects_ProjectId",
                table: "DelegationProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DelegationEmployees_EmployeeId",
                table: "DelegationEmployees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DelegationEmployees_Delegations_DelegationId",
                table: "DelegationEmployees",
                column: "DelegationId",
                principalTable: "Delegations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DelegationEmployees_Employees_EmployeeId",
                table: "DelegationEmployees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DelegationProjects_Delegations_DelegationId",
                table: "DelegationProjects",
                column: "DelegationId",
                principalTable: "Delegations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DelegationProjects_Projects_ProjectId",
                table: "DelegationProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Delegations_Employees_EmployeeDelegationId",
                table: "Delegations",
                column: "EmployeeDelegationId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DelegationEmployees_Delegations_DelegationId",
                table: "DelegationEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_DelegationEmployees_Employees_EmployeeId",
                table: "DelegationEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_DelegationProjects_Delegations_DelegationId",
                table: "DelegationProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DelegationProjects_Projects_ProjectId",
                table: "DelegationProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Delegations_Employees_EmployeeDelegationId",
                table: "Delegations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Delegations",
                table: "Delegations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DelegationProjects",
                table: "DelegationProjects");

            migrationBuilder.DropIndex(
                name: "IX_DelegationProjects_ProjectId",
                table: "DelegationProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DelegationEmployees",
                table: "DelegationEmployees");

            migrationBuilder.DropIndex(
                name: "IX_DelegationEmployees_EmployeeId",
                table: "DelegationEmployees");

            migrationBuilder.RenameTable(
                name: "Delegations",
                newName: "Delegation");

            migrationBuilder.RenameTable(
                name: "DelegationProjects",
                newName: "DelegationProject");

            migrationBuilder.RenameTable(
                name: "DelegationEmployees",
                newName: "DelegationEmployee");

            migrationBuilder.RenameColumn(
                name: "EmployeeDelegationId",
                table: "Delegation",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Delegations_EmployeeDelegationId",
                table: "Delegation",
                newName: "IX_Delegation_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Delegation",
                table: "Delegation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DelegationProject",
                table: "DelegationProject",
                columns: new[] { "ProjectId", "DelegationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DelegationEmployee",
                table: "DelegationEmployee",
                columns: new[] { "EmployeeId", "DelegationId" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "60941ca1-61f7-4b23-9f10-496653611c02", "AQAAAAIAAYagAAAAEMATngxxEJ3cOVKQsavJCxYuh6dAOU3cuAlHpytNXZMdH0qt29eZhHeeFNoQYCKlDQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_DelegationProject_DelegationId",
                table: "DelegationProject",
                column: "DelegationId");

            migrationBuilder.CreateIndex(
                name: "IX_DelegationEmployee_DelegationId",
                table: "DelegationEmployee",
                column: "DelegationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Delegation_Employees_EmployeeId",
                table: "Delegation",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DelegationEmployee_Delegation_DelegationId",
                table: "DelegationEmployee",
                column: "DelegationId",
                principalTable: "Delegation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DelegationEmployee_Employees_EmployeeId",
                table: "DelegationEmployee",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DelegationProject_Delegation_DelegationId",
                table: "DelegationProject",
                column: "DelegationId",
                principalTable: "Delegation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DelegationProject_Projects_ProjectId",
                table: "DelegationProject",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
