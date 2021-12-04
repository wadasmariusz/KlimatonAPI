using System.Globalization;
using MediatR;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Sensors.Entities;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Admin.Sensors.Commands.ImportAirPollutionSensorData;

public class ImportAirPollutionSensorCommandHandler : IRequestHandler<ImportAirPollutionSensorCommand, List<long>>
{
    private readonly ISensorRepository _sensorRepository;
    private readonly ISensorDataRepository _sensorDataRepository;
    private readonly IDateService _dateService;
    private readonly ICurrentUserService _userService;

    public ImportAirPollutionSensorCommandHandler(ISensorRepository sensorRepository, IDateService dateService,
        ICurrentUserService userService, ISensorDataRepository sensorDataRepository)
    {
        _sensorRepository = sensorRepository;
        _dateService = dateService;
        _userService = userService;
        _sensorDataRepository = sensorDataRepository;
    }

    public async Task<List<long>> Handle(ImportAirPollutionSensorCommand req, CancellationToken cancellationToken)
    {
        var addedSensorData = new List<SensorData>();
        foreach (var item in req.SensorLogs)
        {
            var sensorData = new SensorData
            {
                Humidity = item.Humidity,
                Temperature = item.Temperature,
                Pressure = item.Pressure,
                PM25 = item.PM25,
                PM10 = item.PM10,
                PM1 = item.PM1,
                PMx = item.PMx,
                O3 = item.O3,
                SOx = item.SOx,
                NOx = item.NOx,
                CO = item.CO,
                CO2 = item.CO2,
                Dust = item.Dust,
                NO = item.NO,
                NO2 = item.NO2,
                Noise = item.Noise,
                Benzol = item.Benzol,
                Russ = item.Russ
            };
            try
            {
                DateTime time = DateTime.ParseExact(item.Time, "HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime date = DateTime.ParseExact(item.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                var saveDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                
                sensorData.Date = DateTime.SpecifyKind(saveDate, DateTimeKind.Utc);

            }
            catch (Exception e)
            {
                continue;
            }

            var existSensor = await _sensorRepository.GetByExternalSensorId(item.Name);
            if (existSensor == null)
            {
                var sensor = new Sensor
                {
                    ExternalId = item.Name,
                };
                if (!string.IsNullOrWhiteSpace(item.Street))
                {
                    sensor.Address =
                        Address.Create(null, item.Street, "Rzeszów"); //TODO: pobierac miasto na podsatwie zalogowanego usera
                }

                if (item.Latitude.HasValue && item.Longitude.HasValue)
                {
                    sensor.Location = Location.Create(item.Latitude.Value, item.Longitude.Value);
                }

                await _sensorRepository.CreateAsync(sensor);
                sensorData.Sensorid = sensor.Id;
                await _sensorDataRepository.CreateAsync(sensorData);
            }
            else
            {
                sensorData.Sensorid = existSensor.Id;
                await _sensorDataRepository.CreateAsync(sensorData);
            }
            addedSensorData.Add(sensorData);
        }
        return addedSensorData.Select(q => q.Id).ToList();
    }
}