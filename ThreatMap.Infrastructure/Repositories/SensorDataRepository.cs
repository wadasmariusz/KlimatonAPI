using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Sensors.Entities;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Repositories;

public class SensorDataRepository : ISensorDataRepository
{
    private readonly ThreatMapDbContext _db;

    public SensorDataRepository(ThreatMapDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(SensorData sensorData)
    {
        await _db.SensorData.AddAsync(sensorData);
        await _db.SaveChangesAsync();
    }
}