using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreatMap.Persistence.Migrations
{
    public partial class SensorDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Benzol",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CO",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CO2",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dust",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NO",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NO2",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOx",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Noise",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "O3",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PMx",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pressure",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Russ",
                table: "SensorData",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SOx",
                table: "SensorData",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benzol",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "CO",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "CO2",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "Dust",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "NO",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "NO2",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "NOx",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "Noise",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "O3",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "PMx",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "Pressure",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "Russ",
                table: "SensorData");

            migrationBuilder.DropColumn(
                name: "SOx",
                table: "SensorData");
        }
    }
}
