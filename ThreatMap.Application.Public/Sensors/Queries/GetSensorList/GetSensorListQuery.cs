using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.Public.Sensors.Queries.GetSensorList
{
    public class GetSensorListQuery : PaginationRequest, IRequest<GetSensorListQueryVm>
    {
        public string SearchPhrase { get; set; }
    }
}
