using Microsoft.AspNetCore.Mvc;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.Application.Admin.Institutions.Commands.CreateInstitution;
using ThreatMap.Application.Public.Queries.GetInstitutionsList;

namespace ThreatMap.API.Areas.Admin.Controllers;

[Route("admin/institutions")]
public class InstitutionsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetInstitutionList([FromQuery] GetInstitutionListQuery query)
    {
        var response = Mediator.Send(query);
        return Ok(response);
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateInstitution([FromBody] CreateInstitutionCommand command)
    {
        var id = await Mediator.Send(command);
        return Ok();
    }
}