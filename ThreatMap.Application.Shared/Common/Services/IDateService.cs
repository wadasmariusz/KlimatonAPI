namespace ThreatMap.Application.Shared.Common.Services;
public interface IDateService
{
    DateTime CurrentDate();
    DateTimeOffset CurrentOffsetDate();
}