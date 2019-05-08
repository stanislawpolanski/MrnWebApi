using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.Logic.StationService
{
    public interface IStationLogicService
    {
        IEnumerable<String> GetStations();
    }
}
