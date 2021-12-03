using FluentValidation;
using MediatR;
using ThreatMap.Application.Shared.Common.Exceptions;

namespace ThreatMap.Application.Shared.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    // IValidator recognizes whether there is created AbstractValidator<TRequest> 
    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        // If there is AbstractValidator for our request 
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            //Invokes all rules assigned for this request and checks if it returns errors. If it does, then list them.
            var failures = _validators.Select(a => a.Validate(context)).SelectMany(result => result.Errors)
                .Where(b => b != null).ToList();

            if (failures.Count != 0)
            {
                throw new OwnValidationException(failures);
            }
                
        }

        return await next();
    }
}