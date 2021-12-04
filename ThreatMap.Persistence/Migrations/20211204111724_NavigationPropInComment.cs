using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreatMap.Persistence.Migrations
{
    public partial class NavigationPropInComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Reports_ReportId",
                table: "Comment");

            migrationBuilder.AlterColumn<long>(
                name: "ReportId",
                table: "Comment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Reports_ReportId",
                table: "Comment",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Reports_ReportId",
                table: "Comment");

            migrationBuilder.AlterColumn<long>(
                name: "ReportId",
                table: "Comment",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Reports_ReportId",
                table: "Comment",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");
        }
    }
}
