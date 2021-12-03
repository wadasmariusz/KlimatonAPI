using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.Public.Queries.GetSensorDataList
{
    public class GetSensorDataListQuery : PaginationRequest, IRequest<PaginatedList<GetSensorDataListQueryVm>>
    {
        public string SearchPhrase { get; set; }


    }
}