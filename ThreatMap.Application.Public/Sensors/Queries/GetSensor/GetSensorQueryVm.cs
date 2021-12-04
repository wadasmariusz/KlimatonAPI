using ThreatMap.Application.Shared.Common.DTO;
using ThreatMap.Domain.Sensors.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Public.Sensors.Queries.GetSensor
{
    public class GetSensorQueryVm
    {
        public long Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public SensorCategoryE Category { get; set; }
        public string Description { get; set; }
        public AddressDto Address { get; set; }
        public LocationDto Location { get; set; }
    }
}