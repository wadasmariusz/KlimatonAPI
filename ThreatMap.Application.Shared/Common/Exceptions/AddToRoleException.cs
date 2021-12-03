using ThreatMap.Application.Shared.Common.Exceptions.Abstractions;

namespace ThreatMap.Application.Shared.Common.Exceptions;
public class AddToRoleException : ThreatMapException
{
    public AddToRoleException() : base($"Error occured during adding roles to user.")
    {
    }
}