using Microsoft.AspNetCore.Mvc;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.API.Attributes;
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
        var response = Mediator.Send(query);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateReport([FromBody]GetReportListQuery query)
    {
        var response = Mediator.Send(query);
        return Ok(response);
    }
}