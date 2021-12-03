namespace ThreatMap.Domain.ValueObjects;

public record Location
{
    public double Latitude { get; }
    public double Longitude { get; }
    public double Altitude { get; }
    
    protected Location()
    {
    }

    public Location(double latitude, double longitude, double altitude)
    {
        Latitude = latitude;
        Longitude = longitude;
        Altitude = altitude;
    }
}