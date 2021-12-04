using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Application.Admin.Population.Repositories;
using ThreatMap.Domain.Populations;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Repositories
{
    public class PopulationRepository : IPopulationRepository
    {
        private readonly ThreatMapDbContext _db;

        public PopulationRepository(ThreatMapDbContext db)
        {
            _db = db;
        }


        public async Task CreateAsync(Population Population)
        {
            await _db.Populations.AddAsync(Population);
            await _db.SaveChangesAsync();

        }

    }
}