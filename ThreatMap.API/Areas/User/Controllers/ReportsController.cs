﻿using Microsoft.AspNetCore.Mvc;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.API.Attributes;
using ThreatMap.Application.User.Commands.CreateReport;
using ThreatMap.Application.User.Commands.DeleteReport;
using ThreatMap.Application.User.Commands.UpdateReport;
using ThreatMap.Application.User.Queries.GetReportList;
using ThreatMap.Domain.Identity.Static;

namespace ThreatMap.API.Areas.User.Controllers;

[Route("reports")]
// [ApiAuthorize(Roles = UserRoles.User)]
public class ReportsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetReportList([FromBody]GetReportListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateReport([FromBody]CreateReportCommand command)
    {
        var id = await Mediator.Send(command);
        return Ok();
    }
    
    [HttpPut("{reportId:long}/update")]
    public async Task<ActionResult> UpdateReport([FromBody]UpdateReportCommand command, long reportId)
    {
        command.reportId = reportId;
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpDelete("{reportId:long}/delete")]
    public async Task<ActionResult> DeleteReport(long reportId)
    {
        await Mediator.Send(new DeleteReportCommand() {ReportId = reportId});
        return NoContent();
    }
}