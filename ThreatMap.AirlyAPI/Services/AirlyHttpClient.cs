using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

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

            

            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://airapi.airly.eu/v2/measurements/point?lat=50.062006&lng=19.940984");

            request.Headers.Add("Content-Type", "application/json;charset=utf-8");
                request.Headers.Add("apikey", "QfCoR5zkACQjh9GrloCZ9mSt2fXwqANQ");
                request.Headers.Add("Accept-Language", "pl");

            var client = _clientFactory.CreateClient();

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

    }
}
