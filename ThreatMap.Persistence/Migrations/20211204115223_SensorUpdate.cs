using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreatMap.Persistence.Migrations
{
    public partial class SensorUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Sensors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Sensors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PM1",
                table: "SensorData",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "PM1",
                table: "SensorData");
        }
    }
}
