using Microsoft.AspNetCore.Mvc;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.Application.Admin.Reports.Commands;
using ThreatMap.Application.Admin.Reports.GetReportList.Queries;

namespace ThreatMap.API.Areas.Admin.Controllers;

[Route("admin/reports")]
// [ApiAuthorize(Roles = UserRoles.User)]
public class ReportsController : BaseController
{
    public ReportsController()
    {
    }
    
    [HttpGet]
    public async Task<ActionResult> GetInstitutionList([FromQuery] GetAdminReportListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
    
    [HttpPost("import")]
    public async Task<ActionResult> ImportInstitutionList([FromBody] ImportReportCommand query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
}