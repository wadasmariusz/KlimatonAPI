using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ThreatMap.AirlyAPI.Models;

namespace ThreatMap.AirlyAPI.Services
{
    public class AirlyHttpClient : IAirlyHttpClient
    {
        private System.Net.Http.IHttpClientFactory _clientFactory;
        public AirlyHttpClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetData()
        {
            //var client = CreateHttpClient();

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "text/xml; charset=utf-8");

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://airapi.airly.eu/v2/measurements/point?lat=50.062006&lng=19.940984");

            request.Headers.Add("apikey", "QfCoR5zkACQjh9GrloCZ9mSt2fXwqANQ");
            request.Headers.Add("Accept-Language", "pl");
                
            var response = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();

        }


        public async Task<string> GetMeasuresFromNearestSensorDataInRzeszow() 
        {
            //var client = CreateHttpClient();

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://airapi.airly.eu/v2/measurements/nearest?indexType=AIRLY_CAQI&lat=50.0145804&lng=21.9731448&maxDistanceKM=30");

            //request.Headers.Add("Content-Type", "application/json;charset=utf-8");

            request.Headers.Add("apikey", "QfCoR5zkACQjh9GrloCZ9mSt2fXwqANQ");
            request.Headers.Add("Accept-Language", "pl");
           






            var response = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
        private async Task<HttpClient> CreateHttpClient()
        {

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;charset=utf-8");
            client.DefaultRequestHeaders.TryAddWithoutValidation("apikey", "QfCoR5zkACQjh9GrloCZ9mSt2fXwqANQ");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "pl");
            return client;
        }



        public async Task<AirlyRoot> GetMeasuresFromSensor(int locationId)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            //inicjalizacja requestu
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://airapi.airly.eu/v2/measurements/location?includeWind=true&indexType=AIRLY_CAQI&locationId="+"{locationId}");

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
            }

        }

        public async Task<string> SavaMeasureDataToAsync(AirlyRoot airlyRoot)
        {

           
            return "blabla";
        }

        public Task<string> GetMeasuresFromNearestAreaRzeszow()
        {
            throw new NotImplementedException();
        }
    }

}
