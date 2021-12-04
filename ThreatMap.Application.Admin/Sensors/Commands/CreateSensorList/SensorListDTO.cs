namespace ThreatMap.Application.Admin.Sensors.Commands.CreateSensorList;

public class SensorListDTO
{
    public long Id { get; set; }
    public SensorListLocation Location { get; set; }
    public long LocationId { get; set; }
    public SensorListAddress Address { get; set; }
    public double Elevation { get; set; }
    public bool Airly { get; set; }
    public SensorListSponsor Sponsor { get; set; }
    
    public class SensorListLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class SensorListAddress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string DisplayAddress1 { get; set; }
        public string DisplayAddress2 { get; set; }
    }

    public class SensorListSponsor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public object Link { get; set; }
        public string DisplayName { get; set; }
    }
}