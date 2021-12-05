using System.Security.AccessControl;
using FluentValidation;
using MediatR;

namespace ThreatMap.Application.User.Commands.CommentReport;

public class CommentReportCommandValidator : AbstractValidator<CommentUserReportCommand>
{
    public CommentReportCommandValidator()
    {
        RuleFor(a => a.Content)
            .NotEmpty()
            .NotNull();
    }
}