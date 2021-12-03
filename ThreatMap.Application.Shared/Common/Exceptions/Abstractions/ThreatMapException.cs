namespace ThreatMap.Application.Shared.Common.Exceptions.Abstractions;

public class ThreatMapException : Exception
{
    protected ThreatMapException(string message) : base(message)
    {
        
    }
}