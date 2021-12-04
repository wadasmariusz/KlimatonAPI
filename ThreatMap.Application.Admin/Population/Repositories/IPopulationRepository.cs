using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatMap.Application.Admin.Population.Repositories
{
    public interface IPopulationRepository
    {
        Task CreateAsync(ThreatMap.Domain.Populations.Population population);
    }
}
