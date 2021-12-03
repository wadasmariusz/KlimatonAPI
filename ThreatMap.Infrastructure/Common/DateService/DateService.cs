using ThreatMap.Application.Shared.Common.Services;

namespace ThreatMap.Infrastructure.Common.DateService;
//Identity Copy
public class DateService : IDateService
{
    public DateTime CurrentDate() => DateTime.UtcNow;
    public DateTimeOffset CurrentOffsetDate() => DateTimeOffset.UtcNow;
}