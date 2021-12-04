using MediatR;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Institutions.Entities;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Admin.Institutions.Commands.ImportInstitution;

public class ImportInstitutionCommandHandler : IRequestHandler<ImportInstitutionCommand, List<long>>
{
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IDateService _dateService;
    private readonly ICurrentUserService _userService;

    public ImportInstitutionCommandHandler(IInstitutionRepository institutionRepository, IDateService dateService, ICurrentUserService userService)
    {
        _institutionRepository = institutionRepository;
        _dateService = dateService;
        _userService = userService;
    }
    
    public async Task<List<long>> Handle(ImportInstitutionCommand req, CancellationToken cancellationToken)
    {
        var addedInstitution = new List<Institution>();
        foreach (var item in req.Institutions)
        {
            var institution = new Institution
            {
                Name = item.Name,
                Type = item.Type,
                SchoolUrl = item.SchoolUrl,
                ContactEmail = item.ContactEmail,
                ContactPhone = item.ContactPhone,
                Address = Address.Create("Polska", item.Number, item.ZipCode, item.City, item.Street, item.ZipCode),
                Location = Location.Create(item.Latitude, item.Longitude)
            };
            await _institutionRepository.CreateAsync(institution);
            addedInstitution.Add(institution);
        }

        return addedInstitution.Select(q => q.Id).ToList();
    }
}