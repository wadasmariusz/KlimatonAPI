﻿using ThreatMap.Application.Shared.Common.DTO;
using ThreatMap.Domain.Comments.Entities;
using ThreatMap.Domain.ReportRaises.Entities;
using ThreatMap.Domain.Reports.Enums;

namespace ThreatMap.Application.User.Queries.Reports.GetReportList;

public class GetReportListQueryVm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }
    public long UserId { get; set; }
    public int CommentsCount { get; set; }
    public int RaisesCount { get; set; }

    public ReportStatus ReportStatus { get; set; }
    public string AdminComment { get; set; }
    public LocationDto Location { get; set; }
    
    public ICollection<CommentDTO> Comments { get; set; } = new List<CommentDTO>();
    public ICollection<ReportRaise> ReportRaises { get; set; } = new List<ReportRaise>();
    
    public class CommentDTO
    {
        public string Content { get; set; }
        public string UserFirstName { get; set; }
    }
}