using ThreatMap.Domain.Sensors.Entities;

namespace ThreatMap.Application.Shared.Repositories;

public interface ISensorDataRepository
{
    Task CreateAsync(SensorData sensorData);
}