using ThreatMap.Domain.Sensors.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Public.Sensors.Queries.GetSensorList
{
    public class GetSensorListQueryVm
    {
        public string Name { get; set; }
        public SensorCategoryE Category { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }

    }
}
