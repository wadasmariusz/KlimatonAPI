namespace ThreatMap.Domain.ValueObjects;

public record Location
{
    public double Latitude { get; }
    public double Longitude { get; }
    public double? Altitude { get; }

    private Location(double latitude, double longitude, double? altitude)
    {
        Latitude = latitude;
        Longitude = longitude;
        Altitude = altitude;
    }

    public static Location Create(double latitude, double longitude, double? altitude = null)
    {
        return new Location(latitude, longitude, altitude);
    }
}