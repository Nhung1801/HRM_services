using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtableremindwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RemindWork_Works_WorkId",
                table: "RemindWork");

            migrationBuilder.DropForeignKey(
                name: "FK_RemindWorkNotifications_RemindWork_RemindWorkId",
                table: "RemindWorkNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RemindWork",
                table: "RemindWork");

            migrationBuilder.RenameTable(
                name: "RemindWork",
                newName: "RemindWorks");

            migrationBuilder.RenameIndex(
                name: "IX_RemindWork_WorkId",
                table: "RemindWorks",
                newName: "IX_RemindWorks_WorkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RemindWorks",
                table: "RemindWorks",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5481d4e2-61da-4c35-8d24-3eb6fc07df6c", "AQAAAAIAAYagAAAAEAa3acjtu00ZOhak0tOenB4m4HEaGsaXWnjdy5wIntm50i0yV6tTMRaFzKyI/quBMA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_RemindWorkNotifications_RemindWorks_RemindWorkId",
                table: "RemindWorkNotifications",
                column: "RemindWorkId",
                principalTable: "RemindWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RemindWorks_Works_WorkId",
                table: "RemindWorks",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RemindWorkNotifications_RemindWorks_RemindWorkId",
                table: "RemindWorkNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_RemindWorks_Works_WorkId",
                table: "RemindWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RemindWorks",
                table: "RemindWorks");

            migrationBuilder.RenameTable(
                name: "RemindWorks",
                newName: "RemindWork");

            migrationBuilder.RenameIndex(
                name: "IX_RemindWorks_WorkId",
                table: "RemindWork",
                newName: "IX_RemindWork_WorkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RemindWork",
                table: "RemindWork",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33b3f546-0736-470c-84c4-24ec6cd1cb3e", "AQAAAAIAAYagAAAAECff68wxAXkSJy2lgU2518yYjuwQ9zrw6RDR16+2vR2quuWMT0xXdBNswgefaMdspA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_RemindWork_Works_WorkId",
                table: "RemindWork",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RemindWorkNotifications_RemindWork_RemindWorkId",
                table: "RemindWorkNotifications",
                column: "RemindWorkId",
                principalTable: "RemindWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
