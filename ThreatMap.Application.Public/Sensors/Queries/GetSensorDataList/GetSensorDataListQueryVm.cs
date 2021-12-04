using ThreatMap.Domain.Sensors.Entities;

namespace ThreatMap.Application.Public.Sensors.Queries.GetSensorDataList
{
    public class GetSensorDataListQueryVm
    {
        public List<SensorDataDTO> Items { get; set; } = new List<SensorDataDTO>();
        
        public class SensorDataDTO
        {
            public DateTime Date { get; set; }
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
}