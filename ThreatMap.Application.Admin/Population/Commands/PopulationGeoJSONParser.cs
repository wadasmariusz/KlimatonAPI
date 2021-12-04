using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatMap.Application.Admin.Population.Commands
{
    public class PopulationGeoJSONParser
    {
        public string type { get; set; }
        public PopulationProperties properties { get; set; }
        public PopulationGeometry geometry { get; set; }


        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class PopulationProperties
        {
            public string Ulica { get; set; }
            public string Numer_domu { get; set; }
            public int Liczba_oso { get; set; }
            public string Adres { get; set; }
        }

        public class PopulationGeometry
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
        }
    }
}