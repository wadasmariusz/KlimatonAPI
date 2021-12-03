using ThreatMap.Application.Shared.Common.Exceptions.Abstractions;

namespace ThreatMap.Application.Shared.Common.Exceptions;
public class NotActiveTokenException : ThreatMapException
{
    public NotActiveTokenException() : base("Provided token is not active.")
    {
    }
}