using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatMap.AirlyAPI.Models
{
    public class AirlyIndex
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string Advice { get; set; }
        public string Color { get; set; }
    }
}
