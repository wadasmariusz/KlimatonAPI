using FluentValidation;

namespace ThreatMap.Application.User.Commands.CreateReport;

public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
{
    public CreateReportCommandValidator()
    {
        // Reguły, które musi spełniać zgłoszenie
    }
}