using ThreatMap.Domain.Sensors.Entities;

namespace ThreatMap.Application.Shared.Repositories;

public interface ISensorRepository
{
    Task<Sensor> GetByExternalSensorId(string externalId);
    Task CreateAsync(Sensor sensor);
    Task UpdateAsync(Sensor sensor);
    Task DeleteAsync(Sensor sensor);
}