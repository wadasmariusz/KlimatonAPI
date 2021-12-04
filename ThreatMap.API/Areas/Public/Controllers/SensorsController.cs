using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.Application.Public.Sensors.Queries.GetSensor;
using ThreatMap.Application.Public.Sensors.Queries.GetSensorDataList;
using ThreatMap.Application.Public.Sensors.Queries.GetSensorList;
using ThreatMap.Domain.Sensors.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.API.Areas.Public.Controllers
{
    [Route("sensors")]
    public class SensorsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetSensorList([FromQuery] GetSensorListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{sensorId:long}/data")]
        public async Task<ActionResult> GetSensorDataList([FromQuery] GetSensorDataListQuery query, long sensorId)
        {
            //var response = Mediator.Send(query);
            //return Ok(response);

            //MOCK
            var response = new List<GetSensorDataListQueryVm>();
            response.Add(new GetSensorDataListQueryVm { Date = Convert.ToDateTime("2022-09-02 06:00:00"), Humidity = "25%", PM10 = "50%", PM25 = "50%", Sensor = null, Sensorid = 1, Temperature = "19" });
            response.Add(new GetSensorDataListQueryVm { Date = Convert.ToDateTime("2021-09-02 06:00:00"), Humidity = "25%", PM10 = "50%", PM25 = "50%", Sensor = null, Sensorid = 1, Temperature = "19" });
            response.Add(new GetSensorDataListQueryVm { Date = Convert.ToDateTime("2020-09-02 06:00:00"), Humidity = "25%", PM10 = "50%", PM25 = "50%", Sensor = null, Sensorid = 1, Temperature = "19" });
            response.Add(new GetSensorDataListQueryVm { Date = Convert.ToDateTime("2019-09-02 06:00:00"), Humidity = "25%", PM10 = "50%", PM25 = "50%", Sensor = null, Sensorid = 1, Temperature = "19" });

            return Ok(response);
        }

        [HttpGet("{sensorId:long}")]
        public async Task<ActionResult> GetSensor([FromQuery] GetSensorQuery query, long sensorId)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
