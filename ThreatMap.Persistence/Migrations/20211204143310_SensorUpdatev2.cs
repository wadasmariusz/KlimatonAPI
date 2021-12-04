using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThreatMap.Persistence.Migrations
{
    public partial class SensorUpdatev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Institutions");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Sensors",
                newName: "ZipCode");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Sensors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LocationId",
                table: "Sensors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Sensors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Source",
                table: "Sensors",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Sensors",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Sensors");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Sensors",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Institutions",
                type: "text",
                nullable: true);
        }
    }
}
