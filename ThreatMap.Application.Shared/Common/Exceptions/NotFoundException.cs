using ThreatMap.Application.Shared.Common.Exceptions.Abstractions;

namespace ThreatMap.Application.Shared.Common.Exceptions;
public class NotFoundException : ThreatMapException
{
    public NotFoundException(string message) : base(message)
    {
    }
}