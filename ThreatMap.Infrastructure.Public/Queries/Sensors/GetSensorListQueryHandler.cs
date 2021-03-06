using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Public.Sensors.Queries.GetSensorList;
using ThreatMap.Application.Shared.Common.DTO;
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
        var sensors = await _sensors.AsNoTracking()
            .Select(q => new GetSensorListQueryVm.SensorDto
            {
                Id = q.Id,
                ExternalId = q.ExternalId,
                Name = q.Name,
                Category = q.Category,
                Description = q.Description,
                Location = q.Location == null
                    ? null
                    : new LocationDto()
                    {
                        Lat = q.Location.Latitude,
                        Lng = q.Location.Longitude
                    },
                Address = q.Address == null? null : new AddressDto
                {
                    Number = q.Address.Number,
                    Street = q.Address.Street,
                    ZipCode = q.Address.ZipCode,
                    City = q.Address.City,
                },
            })
            .ToListAsync(cancellationToken: cancellationToken);

        return new GetSensorListQueryVm
        {
            Items = sensors
        };
    }
}