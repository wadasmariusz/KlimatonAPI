using ThreatMap.Application.Shared.Common.Exceptions.Abstractions;

namespace ThreatMap.Application.Shared.Common.Exceptions;

public class AddClaimException : ThreatMapException
{
    public AddClaimException() : base("There was an error during adding claim to user.")
    {
    }
}