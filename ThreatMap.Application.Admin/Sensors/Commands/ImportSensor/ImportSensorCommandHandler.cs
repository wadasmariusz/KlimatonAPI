using MediatR;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Sensors.Entities;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Admin.Sensors.Commands.ImportSensor;

public class ImportSensorCommandHandler : IRequestHandler<ImportSensorCommand, List<long>>
{
    private readonly ISensorRepository _sensorRepository;
    private readonly IDateService _dateService;
    private readonly ICurrentUserService _userService;

    public ImportSensorCommandHandler(ISensorRepository sensorRepository, IDateService dateService, ICurrentUserService userService)
    {
        _sensorRepository = sensorRepository;
        _dateService = dateService;
        _userService = userService;
    }
    
    public async Task<List<long>> Handle(ImportSensorCommand req, CancellationToken cancellationToken)
    {
        var addedSensor = new List<Sensor>();
        foreach (var item in req.Sensors)
        {
            var sensor = new Sensor
            {
                Name = item.Name,
                ExternalId = item.ExternalId,
                Description = item.Description,
                Address = item.Address,
                Location = Location.Create(item.Latitude, item.Longitude)
            };
            await _sensorRepository.CreateAsync(sensor);
            addedSensor.Add(sensor);
        }

        return addedSensor.Select(q => q.Id).ToList();
    }
}