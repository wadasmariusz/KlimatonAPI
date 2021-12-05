using Microsoft.AspNetCore.Mvc;
using ThreatMap.Application.Public.Reports.Queries.GetReportList;

namespace ThreatMap.API.Areas.Public.Controllers;

[Route("reports")]
// [ApiAuthorize(Roles = UserRoles.User)]
public class ReportsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetReportList([FromQuery]GetPublicReportListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
}