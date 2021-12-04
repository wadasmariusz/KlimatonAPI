using ThreatMap.Domain.Sensors.Entities;

namespace ThreatMap.Application.Public.Sensors.Queries.GetSensorDataList
{
    public class GetSensorDataListQueryVm
    {
        public DateTime Date { get; set; }

        public long Sensorid { get; set; }
        public Sensor Sensor { get; set; }

        public string Humidity { get; set; }
        public string Temperature { get; set; }
        public string PM25 { get; set; }
        public string PM10 { get; set; }

    }
}
