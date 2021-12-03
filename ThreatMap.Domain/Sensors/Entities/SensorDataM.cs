using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Domain.Common.Entities;

namespace ThreatMap.Domain.Sensors.Entities
{
    public class SensorDataM : AuditableEntity
    {

        public DateTime Date { get; set; }

        public long Sensorid { get; set; }
        public SensorM Sensor { get; set; }

        public string Humidity { get; set; }
        public string Temperature { get; set; }
        public string PM25 { get; set; }
        public string PM10 { get; set; }


    }
}
