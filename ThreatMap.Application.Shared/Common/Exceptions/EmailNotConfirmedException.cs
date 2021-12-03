using ThreatMap.Application.Shared.Common.Exceptions.Abstractions;

namespace ThreatMap.Application.Shared.Common.Exceptions;
public class EmailNotConfirmedException : ThreatMapException
{
    public EmailNotConfirmedException() : base("Email is not confirmed.")
    {
    }
}