using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatMap.AirlyAPI.Services
{
    public interface IAirlyHttpClient
    {
        Task<string> GetData();
        Task<string> GetMeasuresFromNearestAreaRzeszow();
        Task<string> GetMeasuresFromSensor(int locationId);
    }
}
