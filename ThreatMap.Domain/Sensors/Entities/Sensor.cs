using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.Sensors.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Domain.Sensors.Entities
{
    public class Sensor : AuditableEntity
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public SensorCategoryE Category { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public string Address { get; set; }
    }
}