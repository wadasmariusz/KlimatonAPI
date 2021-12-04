using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.Admin.Reports.GetReportList.Queries
{
    public class GetAdminReportListQuery : PaginationRequest, IRequest<PaginatedList<GetAdminReportListQueryVm>>
    {
        public string SearchPhrase { get; set; }
    }
}
