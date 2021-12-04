using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ThreatMap.AirlyAPI.Models;
using ThreatMap.Persistence;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Domain.Sensors.Entities;

namespace ThreatMap.AirlyAPI.Services
{
    public class AirlyHttpClient : IAirlyHttpClient
    {
        private System.Net.Http.IHttpClientFactory _clientFactory;
        private ThreatMapDbContext _db;
        public AirlyHttpClient(IHttpClientFactory clientFactory, ThreatMapDbContext db)
        {
            _clientFactory = clientFactory;
            _db = db;
        }

        public async Task<string> GetMeasureFromPoint(double? latitude, double? longitude)
        {
            //var client = CreateHttpClient();

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://airapi.airly.eu/v2/measurements/point?lat=" + $"{latitude}&lng={longitude}");

            request.Headers.Add("apikey", "QfCoR5zkACQjh9GrloCZ9mSt2fXwqANQ");
            request.Headers.Add("Accept-Language", "pl");

            var response = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();

        }


        //public async Task<string> GetnstallationsNearestSensorDataInRzeszow()
        //{
        //    //var client = CreateHttpClient();

        //    var client = _clientFactory.CreateClient();
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");


        //    var request = new HttpRequestMessage(HttpMethod.Get,
        //        "https://airapi.airly.eu/v2/measurements/nearest?indexType=AIRLY_CAQI&lat=50.0145804&lng=21.9731448&maxDistanceKM=30");

        //    //request.Headers.Add("Content-Type", "application/json;charset=utf-8");

        //    request.Headers.Add("apikey", "QfCoR5zkACQjh9GrloCZ9mSt2fXwqANQ");
        //    request.Headers.Add("Accept-Language", "pl");


        //    var response = await client.SendAsync(request);
        //    return await response.Content.ReadAsStringAsync();
        //}
        //private async Task<HttpClient> CreateHttpClient()
        //{

        //    var client = _clientFactory.CreateClient();
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;charset=utf-8");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("apikey", "QfCoR5zkACQjh9GrloCZ9mSt2fXwqANQ");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "pl");
        //    return client;
        //}



        private async Task<AirlyRoot> GetMeasuresFromSensor(int locationId)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            //inicjalizacja requestu
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://airapi.airly.eu/v2/measurements/location?includeWind=true&indexType=AIRLY_CAQI&locationId=" + "{locationId}");

            //Deklaracja Headerów
            request.Headers.Add("apikey", "QfCoR5zkACQjh9GrloCZ9mSt2fXwqANQ");
            request.Headers.Add("Accept-Language", "pl");
            //Wysylanie
            var response = await client.SendAsync(request);

            //Parsowanie do obiektu
            if (response != null)
            {

                var jsonString = await response.Content.ReadAsStringAsync();
                var respObject = JsonConvert.DeserializeObject<AirlyRoot>(jsonString);
                return respObject;
            }
            else
            {
                throw new Exception("Nie znaleziono odpowiedzi");
            }
        }

        private async Task SaveMeasureDataToAsync(AirlyRoot airlyRoot, int locationId)
        {
            var sensor = await _db.Sensors.Where(q => q.LocationId == locationId).FirstOrDefaultAsync() ?? throw new Exception("Nie znaleziono Sensora o podanej Lokalizacji");

            //cos zrobic z current

            var sensorDataList = new List<SensorData>();
            foreach (var historyItem in airlyRoot.History)
            {
                foreach (var item in historyItem.Values)
                {
                    var sensorData = new SensorData() { Date = historyItem.FromDateTime, Sensorid = sensor.Id };
                    if (item.Name == "PM25")
                    {
                        sensorData.PM25 = item.Value.ToString();
                    }
                    if (item.Name == "PM10")
                    {
                        sensorData.PM10 = item.Value.ToString();
                    }
                    if (item.Name == "PM1")
                    {
                        sensorData.PM1 = item.Value.ToString();
                    }
                    if (item.Name == "PRESSURE")
                    {
                        sensorData.Pressure = item.Value.ToString();
                    }
                    if (item.Name == "HUMIDITY")
                    {
                        sensorData.Humidity = item.Value.ToString();
                    }
                    if (item.Name == "TEMPERATURE")
                    {
                        sensorData.Temperature = item.Value.ToString();
                    }
                    sensorDataList.Add(sensorData);
                }
                //Zapis do bazy
                await _db.AddRangeAsync(sensorDataList);


            }
            //foreach (var forecastitem in airlyRoot.Forecast)
            //{

            //}

            
        }

        public async Task UpdateSensorsData(int locationId)
        {
            var airlyResponseObject = await GetMeasuresFromSensor(locationId);// pobranie i sparsowanie danych z Airly
            await SaveMeasureDataToAsync(airlyResponseObject, locationId); //Zapisywanie do bazy
        }
    }

}
