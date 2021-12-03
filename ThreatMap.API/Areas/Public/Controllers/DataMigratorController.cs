using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Persistence;

namespace ThreatMap.API.Areas.Public.Controllers;

[Route("admin/db-migrate")]
public class DataMigratorController : Controller
{
    private readonly ThreatMapDbContext _db;

    public DataMigratorController(ThreatMapDbContext db)
    {
        _db = db;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Migrate()
    {
        _db.Database.Migrate();
        return Json("migration-ok");
    }
}