using Microsoft.AspNetCore.Mvc;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.API.Attributes;
using ThreatMap.Application.User.Commands.CommentReport;
using ThreatMap.Application.User.Commands.CreateReport;
using ThreatMap.Application.User.Commands.DeleteReport;
using ThreatMap.Application.User.Commands.RaiseReport;
using ThreatMap.Application.User.Commands.UpdateReport;
using ThreatMap.Application.User.Queries.Reports.GetReport;
using ThreatMap.Application.User.Queries.Reports.GetReportCommentList;
using ThreatMap.Application.User.Queries.Reports.GetReportList;
using ThreatMap.Application.User.Queries.Reports.GetReportRaiseList;
using ThreatMap.Domain.Identity.Static;

namespace ThreatMap.API.Areas.User.Controllers;

[Route("user/reports")]
[ApiAuthorize(Roles = UserRoles.User)]
public class ReportsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetReportList([FromQuery]GetReportListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
    
    [HttpGet("{reportId:long}")]
    public async Task<ActionResult> GetReport(long reportId)
    {
        var response = await Mediator.Send(new GetReportQuery {ReportId = reportId});
        return Ok(response);
    }
    
     [HttpPost("{reportId:long}/comment")]
     public async Task<ActionResult> CommentReport([FromBody]CommentReportCommand command, long reportId)
     {
         command.ReportId = reportId;
         await Mediator.Send(command);
         return Ok();
     }
     
     [HttpGet("{reportId:long}/comment")]
     public async Task<ActionResult> GetReportCommentList(long reportId)
     {
         var vm = await Mediator.Send(new GetReportCommentListQuery(){ReportId = reportId});
         return Ok(vm);
     }

     [HttpPost("{reportId:long}/raise")]
    public async Task<ActionResult> RaiseReport([FromBody]RaiseReportCommand command, long reportId)
    {
        command.ReportId = reportId;
        await Mediator.Send(command);

        return Ok();
    }
    
    [HttpGet("{reportId:long}/raise")]
    public async Task<ActionResult> GetReportRaiseList(long reportId)
    {
        var vm = await Mediator.Send(new GetReportRaiseListQuery(){ReportId = reportId});
        return Ok(vm);
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateReport([FromBody]CreateReportCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpPut("{reportId:long}/update")]
    public async Task<ActionResult> UpdateReport([FromBody]UpdateReportCommand command, long reportId)
    {
        command.ReportId = reportId;
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpDelete("{reportId:long}/delete")]
    public async Task<ActionResult> DeleteReport(long reportId)
    {
        await Mediator.Send(new DeleteReportCommand {ReportId = reportId});
        return NoContent();
    }
}