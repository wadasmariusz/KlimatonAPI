using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatMap.AirlyAPI.Models
{
    public class AirlyStandard
    {
        public string Name { get; set; }
        public string Pollutant { get; set; }
        public int Limit { get; set; }
        public double Percent { get; set; }
        public string Averaging { get; set; }
    }
}
