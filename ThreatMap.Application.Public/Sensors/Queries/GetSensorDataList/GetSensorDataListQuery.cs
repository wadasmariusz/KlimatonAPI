using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.Public.Sensors.Queries.GetSensorDataList
{
    public class GetSensorDataListQuery : IRequest<GetSensorDataListQueryVm>
    {
        public long SensorId { get; set; }
    }
}