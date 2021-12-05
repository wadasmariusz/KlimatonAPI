using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Public.Populations.Queries.GetPopulationList;
using ThreatMap.Application.Shared.Common.DTO;
using ThreatMap.Domain.Populations;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Public.Queries.Populations;

public class
    GetPublicPopulationListQueryHandler : IRequestHandler<GetPublicPopulationListQuery, GetPublicPopulationListQueryVm>
{
    private readonly DbSet<Population> _populations;

    public GetPublicPopulationListQueryHandler(ThreatMapDbContext context)
    {
        _populations = context.Populations;
    }

    public async Task<GetPublicPopulationListQueryVm> Handle(GetPublicPopulationListQuery request,
        CancellationToken cancellationToken)
    {
        var sensors = await _populations.AsNoTracking()
            .Select(q => new GetPublicPopulationListQueryVm.PopulationListDto
            {
                Lat = q.Location.Latitude,
                Lng = q.Location.Longitude,
                PeopleCount = q.PeopleCount
            })
            .ToListAsync(cancellationToken: cancellationToken);

        return new GetPublicPopulationListQueryVm
        {
            Items = sensors
        };
    }
}