using Microsoft.AspNetCore.Mvc;
using ThreatMap.Application.Public.Populations.Queries.GetPopulationList;

namespace ThreatMap.API.Areas.Public.Controllers;

[Route("populations")]
public class PublicPopulationsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetPopulationList([FromQuery] GetPublicPopulationListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
}