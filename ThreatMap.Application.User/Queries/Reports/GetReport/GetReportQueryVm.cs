﻿namespace ThreatMap.Application.User.Queries.Reports.GetReport;

public class GetReportQueryVm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }
    public long UserId { get; set; }
}