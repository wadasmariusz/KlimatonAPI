using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.Public.Queries.Sensors.GetSensorList
{
    public class GetSensorListQuery : PaginationRequest, IRequest<PaginatedList<GetSensorListQueryVm>>
    {
        public string SearchPhrase { get; set; }
    }
}
