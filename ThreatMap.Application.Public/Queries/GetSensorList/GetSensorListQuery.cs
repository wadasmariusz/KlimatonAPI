using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.Public.Queries.GetSensorList
{
    public class GetSensorListQuery : PaginationRequest, IRequest<PaginatedList<GetSensorListQueryVm>>
    {
        public string SearchPhrase { get; set; }
    }
}
