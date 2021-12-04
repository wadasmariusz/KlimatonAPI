using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.Public.Sensors.Queries.GetSensorDataList
{
    public class GetSensorDataListQuery : PaginationRequest, IRequest<PaginatedList<GetSensorDataListQueryVm>>
    {
        public string SearchPhrase { get; set; }


    }
}