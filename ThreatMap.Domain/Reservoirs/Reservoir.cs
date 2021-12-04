using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Domain.Reservoirs
{
    public class Reservoir : AuditableEntity
    {
        public int ExternalId { get; set; }
        public string Name { get; set; }
        public string CapacityM3 { get; set; }
        public string LocationSTR { get; set; }
        public int KolektoNR { get; set; }
        public string Lenght { get; set; }
        public string Quantity { get; set; }
        public string Diameter { get; set; }

        public Location Location { get; set; }






    }
}
