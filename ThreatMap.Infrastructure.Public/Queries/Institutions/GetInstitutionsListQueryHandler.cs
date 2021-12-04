using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Public.Institutions.Queries.GetInstitutionsList;
using ThreatMap.Domain.Institutions.Entities;
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
        var query = await _institutions.ToListAsync(cancellationToken: cancellationToken);

        return new GetInstitutionListQueryVm
        {
            Items = query
        };
    }
}