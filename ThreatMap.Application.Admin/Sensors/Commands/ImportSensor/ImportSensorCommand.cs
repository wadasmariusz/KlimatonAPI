using MediatR;

namespace ThreatMap.Application.Admin.Sensors.Commands.ImportSensor;

public class ImportSensorCommand : IRequest<List<long>>
{
    public List<SensorCSV> Sensors { get; set; }
}