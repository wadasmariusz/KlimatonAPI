using MediatR;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Sensors.Entities;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Admin.Sensors.Commands.CreateSensor;

public class CreateSensorCommandHandler : IRequestHandler<CreateSensorCommand, long>
{
    private readonly ISensorRepository _sensorRepository;
    private readonly IDateService _dateService;
    private readonly ICurrentUserService _userService;

    public CreateSensorCommandHandler(ISensorRepository sensorRepository, IDateService dateService, ICurrentUserService userService)
    {
        _sensorRepository = sensorRepository;
        _dateService = dateService;
        _userService = userService;
    }
    
    public async Task<long> Handle(CreateSensorCommand req, CancellationToken cancellationToken)
    {
        var sensor = new Sensor
        {
            Name = req.Name,
            ExternalId = req.ExternalId,
            Description = req.Description,
            Category = req.Category,
            Address = Address.Create(req.Number,  req.Street, req.City,  req.ZipCode),
            Location = Location.Create(req.Latitude, req.Longitude, req.Altitude)
        };

        await _sensorRepository.CreateAsync(sensor);
        
        return sensor.Id;
    }
}