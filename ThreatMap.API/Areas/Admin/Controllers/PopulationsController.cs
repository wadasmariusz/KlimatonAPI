using Microsoft.AspNetCore.Mvc;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.Application.Admin.Population.Commands;

namespace ThreatMap.API.Areas.Admin.Controllers
{
    [Route("admin/populations")]
    // [ApiAuthorize(Roles = UserRoles.User)]
    public class PopulationsController : BaseController
    {
        [HttpPost("import-population")]
        public async Task<IActionResult> UploadPopulationList([FromBody] ImportPopulationCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok();
        }



        
    }
}