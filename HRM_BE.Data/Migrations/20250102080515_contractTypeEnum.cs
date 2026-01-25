using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class contractTypeEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractTypeStatus",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);



            migrationBuilder.CreateIndex(
                name: "IX_LeavePermissions_EmployeeId",
                table: "LeavePermissions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeavePermissions_LeaveApplicationId",
                table: "LeavePermissions",
                column: "LeaveApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeavePermissions_Employees_EmployeeId",
                table: "LeavePermissions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeavePermissions_LeaveApplications_LeaveApplicationId",
                table: "LeavePermissions",
                column: "LeaveApplicationId",
                principalTable: "LeaveApplications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeavePermissions_Employees_EmployeeId",
                table: "LeavePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_LeavePermissions_LeaveApplications_LeaveApplicationId",
                table: "LeavePermissions");

            migrationBuilder.DropIndex(
                name: "IX_LeavePermissions_EmployeeId",
                table: "LeavePermissions");

            migrationBuilder.DropIndex(
                name: "IX_LeavePermissions_LeaveApplicationId",
                table: "LeavePermissions");

            migrationBuilder.DropColumn(
                name: "ContractTypeStatus",
                table: "Contracts");


        }
    }
}
