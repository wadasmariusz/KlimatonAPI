using MediatR;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Sensors.Entities;
using ThreatMap.Domain.Sensors.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Admin.Sensors.Commands.CreateSensorList;

public class CreateSensorListCommandHandler : IRequestHandler<CreateSensorListCommand, List<long>>
{
    private readonly ISensorRepository _sensorRepository;
    private readonly IDateService _dateService;
    private readonly ICurrentUserService _userService;

    public CreateSensorListCommandHandler(ISensorRepository sensorRepository, IDateService dateService, ICurrentUserService userService)
    {
        _sensorRepository = sensorRepository;
        _dateService = dateService;
        _userService = userService;
    }
    
    public async Task<List<long>> Handle(CreateSensorListCommand req, CancellationToken cancellationToken)
    {
        var addedSensorList = new List<Sensor>();
        foreach (var item in req.Sensors)
        {
            var existSensor = await _sensorRepository.GetByExternalSensorId(item.Id.ToString());
            if (existSensor != null)
            {
                var sensor = new Sensor
                {
                    ExternalId = item.Id.ToString(),
                    LocationId = item.LocationId,
                    Source = SensorSource.Airly,
                };
                
                if (item.Address != null)
                {
                    sensor.Address = Address.Create(item.Address.Number, item.Address.Street, item.Address.City);
                }
                
                if (item.Location != null)
                {
                    sensor.Location = Location.Create(item.Location.Latitude, item.Location.Longitude, item.Elevation);
                }
                
                if (item.Airly)
                {
                    sensor.Source = SensorSource.Airly;
                }
                
                await _sensorRepository.CreateAsync(sensor);
                addedSensorList.Add(sensor);
            }
        }

        return addedSensorList.Select(q => q.Id).ToList();
    }
}