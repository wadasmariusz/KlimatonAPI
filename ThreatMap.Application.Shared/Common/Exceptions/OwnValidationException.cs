using FluentValidation.Results;
using ThreatMap.Application.Shared.Common.Exceptions.Abstractions;

namespace ThreatMap.Application.Shared.Common.Exceptions;
public class OwnValidationException : ThreatMapException
{
    public OwnValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public OwnValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}