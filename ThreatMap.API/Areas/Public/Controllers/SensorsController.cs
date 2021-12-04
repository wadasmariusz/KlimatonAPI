using Microsoft.AspNetCore.Mvc;
using ThreatMap.Application.Public.Sensors.Queries.GetSensor;
using ThreatMap.Application.Public.Sensors.Queries.GetSensorDataList;
using ThreatMap.Application.Public.Sensors.Queries.GetSensorList;

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

        [HttpGet("{sensorId:long}")]
        public async Task<ActionResult> GetSensor(long sensorId)
        {
            var query = new GetSensorQuery(){ SensorId = sensorId};
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        
        [HttpGet("{sensorId:long}/data")]
        public async Task<ActionResult> GetSensorDataList(long sensorId)
        {
            var query = new GetSensorDataListQuery(){ SensorId = sensorId};
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}