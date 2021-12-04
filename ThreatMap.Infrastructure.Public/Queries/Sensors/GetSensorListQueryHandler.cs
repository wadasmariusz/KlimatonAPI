using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Public.Sensors.Queries.GetSensorList;
using ThreatMap.Domain.Sensors.Entities;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Public.Queries.Sensors;

public class GetSensorListQueryHandler : IRequestHandler<GetSensorListQuery, GetSensorListQueryVm>
{
    private readonly DbSet<Sensor> _sensors;
    public GetSensorListQueryHandler(ThreatMapDbContext context)
    {
        _sensors = context.Sensors;
    }
    
    public async Task<GetSensorListQueryVm> Handle(GetSensorListQuery request, CancellationToken cancellationToken)
    {
        var sensors = await _sensors
            .Select(q => new GetSensorListQueryVm.SensorDto
            {
                Id = q.Id,
                ExternalId = q.ExternalId,
                Name = q.Name,
                Category = q.Category,
                Description = q.Description,
                Location = q.Location,
                Address = q.Address
            })
            .ToListAsync(cancellationToken: cancellationToken);

        return new GetSensorListQueryVm
        {
            Items = sensors
        };
    }
}