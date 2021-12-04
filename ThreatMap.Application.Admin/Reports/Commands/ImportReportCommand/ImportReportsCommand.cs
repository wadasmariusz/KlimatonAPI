using MediatR;

namespace ThreatMap.Application.Admin.Reports.Commands;

public class ImportReportCommand : IRequest<long>
{
    public List<Feature> Features { get; set; }
    
    public class Properties
    {
        public string name { get; set; }
        public int? id { get; set; }
        public string adres { get; set; }
        public int? miesiac { get; set; }
        public int rok { get; set; }
    }

    public class Crs
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }
}