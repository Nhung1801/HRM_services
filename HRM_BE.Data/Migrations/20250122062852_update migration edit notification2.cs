using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatemigrationeditnotification2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RemindWorkNotifications_RemindWorks_RemindWorkId",
                table: "RemindWorkNotifications");

            migrationBuilder.AlterColumn<int>(
                name: "RemindWorkId",
                table: "RemindWorkNotifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WorkId",
                table: "RemindWorkNotifications",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "980743a3-1eab-4f5a-9d19-0d17ccbe3020", "AQAAAAIAAYagAAAAEAK8gbc+n81KCGLa/8xbVUBDZB3gXTrraZfA+tU02P6EKiLTBnHSCN4iQgO47scfNA==" });

            migrationBuilder.CreateIndex(
                name: "IX_RemindWorkNotifications_WorkId",
                table: "RemindWorkNotifications",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_RemindWorkNotifications_RemindWorks_RemindWorkId",
                table: "RemindWorkNotifications",
                column: "RemindWorkId",
                principalTable: "RemindWorks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RemindWorkNotifications_Works_WorkId",
                table: "RemindWorkNotifications",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RemindWorkNotifications_RemindWorks_RemindWorkId",
                table: "RemindWorkNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_RemindWorkNotifications_Works_WorkId",
                table: "RemindWorkNotifications");

            migrationBuilder.DropIndex(
                name: "IX_RemindWorkNotifications_WorkId",
                table: "RemindWorkNotifications");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "RemindWorkNotifications");

            migrationBuilder.AlterColumn<int>(
                name: "RemindWorkId",
                table: "RemindWorkNotifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d76cdf0-4753-4575-b9c6-8c5d80a50562", "AQAAAAIAAYagAAAAEND5CtUwM+Nbaz5zDhyfwlpHiM7BbyhQ9iG8Oj0Bt+XhLA9Ix3OEIAp9i49C6a1XrA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_RemindWorkNotifications_RemindWorks_RemindWorkId",
                table: "RemindWorkNotifications",
                column: "RemindWorkId",
                principalTable: "RemindWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
