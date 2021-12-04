using MediatR;

namespace ThreatMap.Application.Public.Sensors.Queries.GetSensor
{
    public class GetSensorQuery : IRequest<GetSensorQueryVm>
    {
        public long SensorId { get; set; }
    }
}