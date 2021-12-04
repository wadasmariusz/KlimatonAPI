using ThreatMap.Domain.ReportRaises.Enums;
using ThreatMap.Domain.Reports.Entities;

namespace ThreatMap.Application.User.Queries.Reports.GetReportRaiseList;

public class GetReportRaiseListQueryVm
{
    public RaiseAction RaiseAction { get; set; }

    public ReportRaiseListUserDto User { get; set; }
   
}