using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Public.Sensors.Queries.GetSensor;
using ThreatMap.Application.Shared.Common.DTO;
using ThreatMap.Application.Shared.Common.Exceptions;
using ThreatMap.Domain.Sensors.Entities;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Public.Queries.Sensors;

public class GetSensorQueryHandler : IRequestHandler<GetSensorQuery, GetSensorQueryVm>
{
    private readonly DbSet<Sensor> _sensors;

    public GetSensorQueryHandler(ThreatMapDbContext context)
    {
        _sensors = context.Sensors;
    }

    public async Task<GetSensorQueryVm> Handle(GetSensorQuery request, CancellationToken cancellationToken)
    {
        var sensor = await _sensors.AsNoTracking()
                         .Select(q => new GetSensorQueryVm
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
                             Address = q.Address == null
                                 ? null
                                 : new AddressDto
                                 {
                                     Number = q.Address.Number,
                                     Street = q.Address.Street,
                                     ZipCode = q.Address.ZipCode,
                                     City = q.Address.City,
                                 },
                         })
                         .FirstOrDefaultAsync(a => a.Id == request.SensorId, cancellationToken: cancellationToken) ??
                     throw new NotFoundException($"Sensor with requested id:{request.SensorId} could not be found");

        return sensor;
    }
}