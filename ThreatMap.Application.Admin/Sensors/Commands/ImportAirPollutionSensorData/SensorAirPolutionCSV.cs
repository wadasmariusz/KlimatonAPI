using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;

namespace ThreatMap.Application.Admin.Sensors.Commands.ImportAirPollutionSensorData;

public class SensorAirPolutionCSV
{ 
    [JsonProperty(PropertyName = "Nazwa")]
    public string Name { get; set; }
    [JsonProperty(PropertyName = "Położenia")]
    public string Street { get; set; }
    [JsonProperty(PropertyName = "Data")]
    public string Date { get; set; }
    
    [JsonProperty(PropertyName = "Czas")]
    public string Time { get; set; }

    [Optional]
    public string Pressure { get; set; }

    [Optional]
    public string Humidity { get; set; }
    [Optional]
    public string Temperature { get; set; }
    [Optional]
    public string PM25 { get; set; }
    [Optional]
    public string PM10 { get; set; }
    [Optional]
    public string PM1 { get; set; }
    [Optional]
    public string PMx { get; set; }
    [Optional]
    public string O3 { get; set; }
    [Optional]
    public string SOx { get; set; }
    [Optional]
    public string NOx { get; set; }
    [Optional]
    public string CO { get; set; }
    [Optional]
    public string CO2 { get; set; }
    [Optional]
    public string Dust { get; set; }
    [Optional]
    public string NO { get; set; }
    [Optional]
    public string NO2 { get; set; }
    [Optional]
    public string Noise { get; set; }
    [Optional]
    public string Benzol { get; set; }
    [Optional]
    public string Russ { get; set; }
    
    [Optional]
    [JsonProperty(PropertyName = "Szerokość GPS")]
    public double? Latitude { get; set; }
    
    [Optional]
    [JsonProperty(PropertyName = "Długość GPS")]
    public double? Longitude { get; set; }
}