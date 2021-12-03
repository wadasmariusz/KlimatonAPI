using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.Sensors.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Domain.River.Enitties
{
    public class River : AuditableEntity
    {
        public string Name { get; set; }        
        public string Description { get; set; } 

    }
}
