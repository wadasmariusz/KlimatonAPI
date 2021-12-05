using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Domain.Populations
{
    public class Population : AuditableEntity
    {
        public string Street { get; set; }
        public string HomeNumber { get; set; }
        public int PeopleCount { get; set; }
        public string Address { get; set; }

        public Location Location  { get; set; }
    }
}