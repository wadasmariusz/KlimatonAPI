using MediatR;
using ThreatMap.Domain.Sensors.Enums;

namespace ThreatMap.Application.Admin.Sensors.Commands.CreateSensor;

public class CreateSensorCommand : IRequest<long>
{
    public string ExternalId { get; set; }
    public string Name { get; set; }
    public SensorCategoryE Category { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double? Altitude { get; set; }
}