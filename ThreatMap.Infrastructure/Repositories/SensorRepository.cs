using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Sensors.Entities;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Repositories;

public class SensorRepository : ISensorRepository
{
    private readonly ThreatMapDbContext _db;

    public SensorRepository(ThreatMapDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(Sensor sensor)
    {
        await _db.Sensors.AddAsync(sensor);
        await _db.SaveChangesAsync();

    }

    public async Task UpdateAsync(Sensor sensor)
    {
        _db.Sensors.Update(sensor);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Sensor sensor)
    {
        _db.Sensors.Remove(sensor);
        await _db.SaveChangesAsync();
    }
}