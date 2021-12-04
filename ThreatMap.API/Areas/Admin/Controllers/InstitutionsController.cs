using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using ThreatMap.API.Areas.Public.Controllers;
using ThreatMap.Application.Admin.Institutions.Commands.CreateInstitution;
using ThreatMap.Application.Admin.Institutions.Commands.ImportInstitution;
using ThreatMap.Application.Public.Institutions.Queries.GetInstitutionsList;

namespace ThreatMap.API.Areas.Admin.Controllers;

[Route("admin/institutions")]
public class InstitutionsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetInstitutionList([FromQuery] GetInstitutionListQuery query)
    {
        var response = await Mediator.Send(query);
        return Ok(response);
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> CreateInstitution([FromBody] CreateInstitutionCommand command)
    {
        var id = await Mediator.Send(command);
        return Ok();
    }
    
    [HttpPost("import-data")]
    public async Task<IActionResult> UploadSchoolList([FromForm] IFormFile file)
    {
        List<InstitutionCSV> records = new List<InstitutionCSV>();
        if (file.Length > 0)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<InstitutionCSV>().ToList();
            }
        }

        var command = new ImportInstitutionCommand()
        {
            Institutions = records
        };
        var id = await Mediator.Send(command);
        return Ok();
    }
}