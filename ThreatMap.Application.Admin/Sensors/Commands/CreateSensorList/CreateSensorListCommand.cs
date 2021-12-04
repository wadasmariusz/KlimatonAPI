using MediatR;

namespace ThreatMap.Application.Admin.Sensors.Commands.CreateSensorList;

public class CreateSensorListCommand : IRequest<List<long>>
{
    public List<SensorListDTO> Sensors { get; set; } = new List<SensorListDTO>();
}