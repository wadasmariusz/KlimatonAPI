using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.Sensors.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Domain.Sensors.Entities
{
    public class Sensor : AuditableEntity
    {
        public string Name { get; set; }
        public SensorCategoryE Category { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }


    }
}
