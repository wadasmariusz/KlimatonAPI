using Microsoft.AspNetCore.Mvc;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.API.Attributes;
using ThreatMap.Application.Admin.Reports.Commands;
using ThreatMap.Application.Admin.Reports.GetReportList.Queries;
using ThreatMap.Domain.Identity.Static;

namespace ThreatMap.API.Areas.Admin.Controllers;

[Route("admin/reports")]
[ApiAuthorize(Roles = UserRoles.CityAdmin)]
public class AdminReportsController : BaseController
{
    public AdminReportsController()
    {
    }
    
    [HttpGet]
    public async Task<ActionResult> GetReportList([FromQuery] GetAdminReportListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
    
    [HttpPost("import")]
    public async Task<ActionResult> ImportReportList([FromBody] ImportReportCommand query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
}