using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addtableintaskwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagWork_Tag_TagId",
                table: "TagWork");

            migrationBuilder.DropForeignKey(
                name: "FK_TagWork_Work_WorkId",
                table: "TagWork");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Employees_ReporterId",
                table: "Work");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_GroupWork_GroupWorkId",
                table: "Work");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Work",
                table: "Work");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagWork",
                table: "TagWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupWork",
                table: "GroupWork");

            migrationBuilder.RenameTable(
                name: "Work",
                newName: "Works");

            migrationBuilder.RenameTable(
                name: "TagWork",
                newName: "TagsWork");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "GroupWork",
                newName: "GroupWorks");

            migrationBuilder.RenameIndex(
                name: "IX_Work_ReporterId",
                table: "Works",
                newName: "IX_Works_ReporterId");

            migrationBuilder.RenameIndex(
                name: "IX_Work_GroupWorkId",
                table: "Works",
                newName: "IX_Works_GroupWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_TagWork_TagId",
                table: "TagsWork",
                newName: "IX_TagsWork_TagId");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Works",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPin",
                table: "Works",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Works",
                table: "Works",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagsWork",
                table: "TagsWork",
                columns: new[] { "WorkId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupWorks",
                table: "GroupWorks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Approvals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproverId = table.Column<int>(type: "int", nullable: true),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApprove = table.Column<bool>(type: "bit", nullable: true),
                    RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approvals_Employees_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CheckLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDone = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckLists_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RepeatWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRepeat = table.Column<bool>(type: "bit", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepeatNumberDay = table.Column<int>(type: "int", nullable: true),
                    IsMonday = table.Column<bool>(type: "bit", nullable: true),
                    IsTuesday = table.Column<bool>(type: "bit", nullable: true),
                    IsWednesday = table.Column<bool>(type: "bit", nullable: true),
                    IsThursday = table.Column<bool>(type: "bit", nullable: true),
                    IsFriday = table.Column<bool>(type: "bit", nullable: true),
                    IsSaturday = table.Column<bool>(type: "bit", nullable: true),
                    IsSunday = table.Column<bool>(type: "bit", nullable: true),
                    RepeatWorkType = table.Column<int>(type: "int", nullable: false),
                    RepeatCycle = table.Column<int>(type: "int", nullable: true),
                    InDayOfWeek = table.Column<int>(type: "int", nullable: true),
                    InDayOfMonth = table.Column<int>(type: "int", nullable: true),
                    RepeatHour = table.Column<TimeSpan>(type: "time", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepeatWorks", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "540fbd44-a895-43e5-9c63-25b61239e44f", "AQAAAAIAAYagAAAAEOPyv1LMa7zVA6zInnZFLJL/rJ0w/CyXCrENWVCdecWlTY365SIBjbstDfRgMMdcNw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_ApproverId",
                table: "Approvals",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckLists_WorkId",
                table: "CheckLists",
                column: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagsWork_Tags_TagId",
                table: "TagsWork",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagsWork_Works_WorkId",
                table: "TagsWork",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_ReporterId",
                table: "Works",
                column: "ReporterId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_GroupWorks_GroupWorkId",
                table: "Works",
                column: "GroupWorkId",
                principalTable: "GroupWorks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagsWork_Tags_TagId",
                table: "TagsWork");

            migrationBuilder.DropForeignKey(
                name: "FK_TagsWork_Works_WorkId",
                table: "TagsWork");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_ReporterId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_GroupWorks_GroupWorkId",
                table: "Works");

            migrationBuilder.DropTable(
                name: "Approvals");

            migrationBuilder.DropTable(
                name: "CheckLists");

            migrationBuilder.DropTable(
                name: "RepeatWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Works",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagsWork",
                table: "TagsWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupWorks",
                table: "GroupWorks");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "IsPin",
                table: "Works");

            migrationBuilder.RenameTable(
                name: "Works",
                newName: "Work");

            migrationBuilder.RenameTable(
                name: "TagsWork",
                newName: "TagWork");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "GroupWorks",
                newName: "GroupWork");

            migrationBuilder.RenameIndex(
                name: "IX_Works_ReporterId",
                table: "Work",
                newName: "IX_Work_ReporterId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_GroupWorkId",
                table: "Work",
                newName: "IX_Work_GroupWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_TagsWork_TagId",
                table: "TagWork",
                newName: "IX_TagWork_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Work",
                table: "Work",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagWork",
                table: "TagWork",
                columns: new[] { "WorkId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupWork",
                table: "GroupWork",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d6c03524-615b-40fd-98e6-96ea3eb01128", "AQAAAAIAAYagAAAAEBFTkGyXvSy0RPb/a12fI/S1h/s+wv56mb9TJTfdvJu9x4pxHdzzXLmjkuO3SLsMVQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_TagWork_Tag_TagId",
                table: "TagWork",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagWork_Work_WorkId",
                table: "TagWork",
                column: "WorkId",
                principalTable: "Work",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Employees_ReporterId",
                table: "Work",
                column: "ReporterId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_GroupWork_GroupWorkId",
                table: "Work",
                column: "GroupWorkId",
                principalTable: "GroupWork",
                principalColumn: "Id");
        }
    }
}
