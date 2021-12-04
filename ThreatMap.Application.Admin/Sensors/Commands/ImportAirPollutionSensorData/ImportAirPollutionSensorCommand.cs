using MediatR;

namespace ThreatMap.Application.Admin.Sensors.Commands.ImportAirPollutionSensorData;

public class ImportAirPollutionSensorCommand : IRequest<List<long>>
{
    public List<SensorAirPolutionCSV> SensorLogs { get; set; }
}