using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreatMap.Persistence.Migrations
{
    public partial class ReportUpdatev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Altitude",
                table: "Reports",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Reports",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Reports",
                type: "double precision",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altitude",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Reports");
        }
    }
}
