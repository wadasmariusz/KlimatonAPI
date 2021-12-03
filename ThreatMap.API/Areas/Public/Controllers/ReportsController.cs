using Microsoft.AspNetCore.Mvc;
using ThreatMap.Application.User.Queries.Reports.GetReportList;

namespace ThreatMap.API.Areas.Public.Controllers;

[Microsoft.AspNetCore.Components.Route("reports")]
// [ApiAuthorize(Roles = UserRoles.User)]
public class ReportsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetReportList([FromQuery]GetReportListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
    
    
}