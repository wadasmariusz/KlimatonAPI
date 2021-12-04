using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatMap.Application.Admin.Population.Commands
{
    public class ImportPopulationCommand : IRequest<List<long>>
    {
        public List<PopulationGeoJSONParser> features { get; set; }
    }
}