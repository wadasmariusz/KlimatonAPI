using ThreatMap.Application.Shared.Common.Exceptions.Abstractions;

namespace ThreatMap.Application.Shared.Common.Exceptions;
public class InvalidTokenException : ThreatMapException
{
    public InvalidTokenException() : base("Provided token is not valid.")
    {
    }
}