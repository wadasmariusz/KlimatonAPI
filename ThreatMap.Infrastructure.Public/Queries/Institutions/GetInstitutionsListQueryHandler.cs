using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Public.Institutions.Queries.GetInstitutionsList;
using ThreatMap.Domain.Institutions.Entities;
using ThreatMap.Domain.Institutions.Enums;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Public.Queries.Institutions;

public class GetInstitutionsListQueryHandler : IRequestHandler<GetInstitutionListQuery, GetInstitutionListQueryVm>
{
    private readonly DbSet<Institution> _institutions;
    public GetInstitutionsListQueryHandler(ThreatMapDbContext context)
    {
        _institutions = context.Institutions;
    }
    
    public async Task<GetInstitutionListQueryVm> Handle(GetInstitutionListQuery request, CancellationToken cancellationToken)
    {
        var query = await _institutions
            .Select(q => new GetInstitutionListQueryVm.InstitutioDto
            {
                Name = q.Name,
                Description = q.Description,
                Type = q.Type,
                SchoolUrl = q.SchoolUrl,
                ContactEmail = q.ContactEmail,
                ContactPhone = q.ContactPhone,
                Address = q.Address == null? null : new GetInstitutionListQueryVm.InstitutioDto.AddressDto
                {
                    Number = q.Address.Number,
                    Street = q.Address.Street,
                    ZipCode = q.Address.ZipCode,
                    City = q.Address.City,
                },
                Location = q.Location == null? null : new GetInstitutionListQueryVm.InstitutioDto.LocationDto
                {
                    Lat = q.Location.Latitude,
                    Lng = q.Location.Latitude
                }
            })
            .ToListAsync(cancellationToken: cancellationToken);

        return new GetInstitutionListQueryVm
        {
            Items = query
        };
    }
}