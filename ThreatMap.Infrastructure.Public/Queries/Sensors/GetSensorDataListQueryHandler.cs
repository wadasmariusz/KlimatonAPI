using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Public.Sensors.Queries.GetSensorDataList;
using ThreatMap.Domain.Sensors.Entities;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Public.Queries.Sensors;

public class GetSensorDataListQueryHandler : IRequestHandler<GetSensorDataListQuery, GetSensorDataListQueryVm>
{
    private readonly DbSet<SensorData> _sensorsData;
    public GetSensorDataListQueryHandler(ThreatMapDbContext context)
    {
        _sensorsData = context.SensorData;
    }
    
    public async Task<GetSensorDataListQueryVm> Handle(GetSensorDataListQuery request, CancellationToken cancellationToken)
    {
        var sensors = await _sensorsData.AsNoTracking()
            .Where(q => q.Sensorid == request.SensorId)
            .Select(q => new GetSensorDataListQueryVm.SensorDataDTO
            {
                Date = q.Date,
                Pressure = q.Pressure,
                Humidity = q.Humidity,
                Temperature = q.Temperature,
                PM25 = q.PM25,
                PM10 = q.PM10,
                PM1 = q.PM1,
                PMx = q.PMx,
                O3 = q.O3,
                SOx = q.SOx,
                NOx = q.NOx,
                CO = q.CO,
                CO2 = q.CO2,
                Dust = q.Dust,
                NO = q.NO,
                NO2 = q.NO2,
                Noise = q.Noise,
                Benzol = q.Benzol,
                Russ = q.Russ
            })
            .ToListAsync(cancellationToken: cancellationToken);

        return new GetSensorDataListQueryVm
        {
            Items = sensors
        };
    }
}