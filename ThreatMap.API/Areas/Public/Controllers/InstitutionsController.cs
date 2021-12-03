using Microsoft.AspNetCore.Mvc;
using ThreatMap.Application.Public.Queries.GetInstitutionsList;

namespace ThreatMap.API.Areas.Public.Controllers;

[Route("institutions")]
public class InstitutionsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetInstitutionList([FromQuery] GetInstitutionListQuery query)
    {
        var response = Mediator.Send(query);
        return Ok(response);
    }
}