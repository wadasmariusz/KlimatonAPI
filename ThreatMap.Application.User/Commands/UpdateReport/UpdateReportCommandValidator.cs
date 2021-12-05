using FluentValidation;
using ThreatMap.Application.User.Commands.CreateReport;

namespace ThreatMap.Application.User.Commands.UpdateReport;

public class UpdateReportCommandValidator : AbstractValidator<UpdateUserReportCommand>
{
    public UpdateReportCommandValidator()
    {
        // Reguły, które musi spełniać zgłoszenie
    }
}