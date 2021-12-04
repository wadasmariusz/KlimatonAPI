using MediatR;
using ThreatMap.Domain.Sensors.Enums;

namespace ThreatMap.Application.Admin.Sensors.Commands.CreateSensor;

public class CreateSensorCommand : IRequest<long>
{
    public string ExternalId { get; set; }
    public string Name { get; set; }
    public SensorCategoryE Category { get; set; }
    public string Description { get; set; }
    
    public string Number { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double? Altitude { get; set; }
}