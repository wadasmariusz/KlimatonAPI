namespace ThreatMap.Application.Admin.Sensors.Commands.ImportSensor;

public class SensorCSV
{
    public string Number { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    
    public string ExternalId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double? Altitude { get; set; }
}