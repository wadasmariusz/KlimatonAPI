using MediatR;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Institutions.Entities;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Admin.Institutions.Commands.CreateInstitution;

public class CreateInstitutionCommandHandler : IRequestHandler<CreateInstitutionCommand, long>
{
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IDateService _dateService;
    private readonly ICurrentUserService _userService;

    public CreateInstitutionCommandHandler(IInstitutionRepository institutionRepository, IDateService dateService, ICurrentUserService userService)
    {
        _institutionRepository = institutionRepository;
        _dateService = dateService;
        _userService = userService;
    }
    
    public async Task<long> Handle(CreateInstitutionCommand req, CancellationToken cancellationToken)
    {
        var institution = new Institution
        {
            Name = req.Name,
            Description = req.Description,
            Type = req.Type,
            SchoolUrl = req.SchoolUrl,
            ContactEmail = req.ContactEmail,
            ContactPhone = req.ContactPhone,
            Address = Address.Create(req.Country, req.Number, req.ZipCode, req.City, req.Street, req.ZipCode),
            Location = Location.Create(req.Latitude, req.Longitude)
        };

        await _institutionRepository.CreateAsync(institution);
        
        return institution.Id;
    }
}