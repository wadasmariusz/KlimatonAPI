namespace ThreatMap.Application.Admin.Sensors.Commands.ImportSensor;

public class SensorCSV
{
    public string ExternalId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
}