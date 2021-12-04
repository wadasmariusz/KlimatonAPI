using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatMap.AirlyAPI.Models
{
    public class AirlyForecast
    {
        public DateTime FromDateTime { get; set; }
        public DateTime TillDateTime { get; set; }
        public List<AirlyValue> Values { get; set; }
        public List<AirlyIndex> Indexes { get; set; }
        public List<AirlyStandard> Standards { get; set; }
    }
}
