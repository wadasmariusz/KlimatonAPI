using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using ThreatMap.AirlyAPI.Services;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.API.Attributes;
using ThreatMap.Application.Admin.Sensors.Commands.CreateSensor;
using ThreatMap.Application.Admin.Sensors.Commands.CreateSensorList;
using ThreatMap.Application.Admin.Sensors.Commands.ImportAirPollutionSensorData;
using ThreatMap.Application.Admin.Sensors.Commands.ImportSensor;
using ThreatMap.Application.Public.Sensors.Queries.GetSensorDataList;
using ThreatMap.Application.Public.Sensors.Queries.GetSensorList;
using ThreatMap.Domain.Identity.Static;
using ThreatMap.Domain.Sensors.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.API.Areas.Admin.Controllers
{
    [Route("admin/sensors")]
    // [ApiAuthorize(Roles = UserRoles.User)]
    public class SensorsController : BaseController
    {
        private readonly IAirlyHttpClient _iAirlyHttpClient;
        public SensorsController(IAirlyHttpClient iAirlyHttpClient = null)
        {
            _iAirlyHttpClient = iAirlyHttpClient;
        }

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
        
        [HttpPost("create")]
        public async Task<ActionResult> CreateSensor([FromBody] CreateSensorCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok();
        }     
        
        [HttpPost("import-list")]
        public async Task<ActionResult> CreateSensor([FromBody] CreateSensorListCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok();
        }
        
        [HttpPost("import-data-csv")]
        public async Task<IActionResult> UploadSensorCSVList([FromForm] IFormFile file)
        {
            List<SensorCSV> records = new List<SensorCSV>();
            if (file.Length > 0)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    records = csv.GetRecords<SensorCSV>().ToList();
                }
            }

            var command = new ImportSensorCommand()
            {
                Sensors = records
            };
            var id = await Mediator.Send(command);
            return Ok();
        }
        
        [HttpPost("import-data")]
        public async Task<IActionResult> UploadSensorList([FromBody] IFormFile file)
        {
            List<SensorCSV> records = new List<SensorCSV>();
            if (file.Length > 0)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    records = csv.GetRecords<SensorCSV>().ToList();
                }
            }

            var command = new ImportSensorCommand()
            {
                Sensors = records
            };
            var id = await Mediator.Send(command);
            return Ok();
        }
        
        [HttpPost("import-measurements")]
        public async Task<IActionResult> UploadMeasurementList([FromBody] ImportAirPollutionSensorCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok();
        }

        //[HttpPut("{reportId:long}/update")]
        //public async Task<ActionResult> UpdateSensor([FromBody] UpdateSensorCommand command, long reportId)
        //{
        //    command.reportId = reportId;
        //    await Mediator.Send(command);
        //    return Ok();
        //}

        //[HttpDelete("{reportId:long}/delete")]
        //public async Task<ActionResult> DeleteSensor(long reportId)
        //{
        //    await Mediator.Send(new DeleteSensorCommand() { SensorId = reportId });
        //    return NoContent();
        //}


        [HttpGet("test")]
        public async Task<ActionResult> GetSensorList()
        {
            // var response = await _iAirlyHttpClient.GetData();
            // return Ok(response);
            return Ok();
        }
    }
}