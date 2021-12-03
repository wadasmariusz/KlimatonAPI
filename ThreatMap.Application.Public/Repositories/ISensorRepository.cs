using ThreatMap.Domain.Sensors.Entities;
using ThreatMap.Domain.Sensors.Entities;

namespace ThreatMap.Application.Public.Repositories;

public interface ISensorsRepository
{
    Task<Sensor> GetAsync(long sensorId);
    Task CreateAsync(Sensor sensor);
    Task UpdateAsync(Sensor sensor);
    Task DeleteAsync(Sensor sensor);
}