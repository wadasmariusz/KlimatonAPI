using Microsoft.AspNetCore.Mvc;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.API.Attributes;
using ThreatMap.Application.Admin.Population.Commands;
using ThreatMap.Application.Admin.Population.Queries;
using ThreatMap.Domain.Identity.Static;

namespace ThreatMap.API.Areas.Admin.Controllers
{
    [Route("admin/populations")]
    [ApiAuthorize(Roles = UserRoles.CityAdmin)]
    public class AdminPopulationsController : BaseController
    {
        [HttpPost("populations")]
        public async Task<IActionResult> GetPopulationList([FromQuery] GetAdminPopulationListQuery query)
        {
            var id = await Mediator.Send(query);
            return Ok();
        }
        
        [HttpPost("import")]
        public async Task<IActionResult> UploadPopulationList([FromBody] ImportPopulationCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok();
        }
    }
}