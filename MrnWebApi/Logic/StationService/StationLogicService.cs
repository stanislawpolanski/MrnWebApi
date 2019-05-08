using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.Logic.StationService
{
    public class StationLogicService : IStationLogicService
    {
        public IEnumerable<string> GetStations()
        {
            return new List<String>
            {
                "Szczakowa Południe",
                "Ciężkowice",
                "Pieczyska"
            };
        }
    }
}
