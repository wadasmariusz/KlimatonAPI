using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.Public.Queries.Sensors.GetSensorDataList
{
    public class GetSensorDataListQuery : PaginationRequest, IRequest<PaginatedList<GetSensorDataListQueryVm>>
    {
        public string SearchPhrase { get; set; }


    }
}