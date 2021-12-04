using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreatMap.AirlyAPI.Services
{
    public interface IAirlyHttpClient
    {
        Task<string> GetMeasureFromPoint(double? latitude, double? longitude);
        //Task<string> GetInstallationsNearestAreaRzeszow();
        Task UpdateSensorsData(int locationId);
    }
}
