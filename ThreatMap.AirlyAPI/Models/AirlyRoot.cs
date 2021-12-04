using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatMap.AirlyAPI.Models
{
    public class AirlyRoot
    {
        public AirlyCurrent Current { get; set; }
        public List<AirlyHistory> History { get; set; }
        public List<AirlyForecast> Forecast { get; set; }
    }
}
