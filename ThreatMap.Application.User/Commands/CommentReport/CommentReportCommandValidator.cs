using System.Security.AccessControl;
using FluentValidation;
using MediatR;

namespace ThreatMap.Application.User.Commands.CommentReport;

public class CommentReportCommandValidator : AbstractValidator<CommentReportCommand>
{
    public CommentReportCommandValidator()
    {
        RuleFor(a => a.Content)
            .NotEmpty()
            .NotNull();
    }
}