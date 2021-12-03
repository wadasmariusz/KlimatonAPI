using ThreatMap.Application.Shared.Common.Exceptions.Abstractions;

namespace ThreatMap.Application.Shared.Common.Exceptions;
public class InvalidCredentialsException : ThreatMapException
{
    public InvalidCredentialsException() : base("Provided credentials are invalid.")
    {
    }
}