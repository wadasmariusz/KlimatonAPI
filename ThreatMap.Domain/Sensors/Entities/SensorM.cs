using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.Sensors.Enums;

namespace ThreatMap.Domain.Sensors.Entities
{
    public class SensorM : AuditableEntity
    {
        public string Name { get; set; }
        public SensorCategoryE Category { get; set; }
        public string Description { get; set; }


        //Dane Lokalizacyjne = tutaj w double albo w geospatial type z Postgisa
        public double? LocLat { get; set; }
        public double? LocLon { get; set; }
        public double? LocAlt { get; set; }


    }
}
