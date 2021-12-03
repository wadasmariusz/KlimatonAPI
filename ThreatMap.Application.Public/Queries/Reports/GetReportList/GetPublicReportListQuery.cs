using System.Linq.Dynamic.Core;
using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.Public.Queries.Reports.GetReportList;

public class GetPublicReportListQuery :PaginationRequest, IRequest<PaginatedList<GetPublicReportListQueryVm>>
{
    public string SearchPhrase { get; set; }
}