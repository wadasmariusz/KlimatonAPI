using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreatMap.Persistence.Migrations
{
    public partial class ReportUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminComment",
                table: "Reports",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "ReportStatus",
                table: "Reports",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminComment",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "Reports");
        }
    }
}
