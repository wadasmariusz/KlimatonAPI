using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Domain.Common.Entities;

namespace ThreatMap.Domain.Sensors.Entities
{
    public class SensorData : AuditableEntity
    {
        public DateTime Date { get; set; }

        public long Sensorid { get; set; }
        public Sensor Sensor { get; set; }

        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Temperature { get; set; }
        public string PM25 { get; set; }
        public string PM10 { get; set; }
        public string PM1 { get; set; }
        public string PMx { get; set; }
        
        
        public string O3 { get; set; }
        public string SOx { get; set; }
        public string NOx { get; set; }
        public string CO { get; set; }
        public string CO2 { get; set; }
        public string Dust { get; set; }
        public string NO { get; set; }
        public string NO2 { get; set; }
        public string Noise { get; set; }
        public string Benzol { get; set; }
        public string Russ { get; set; }
    }
}