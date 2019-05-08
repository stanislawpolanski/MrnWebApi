using MrnWebApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.Logic.StationService
{
    public class StationLogicService : IStationLogicService
    {
        public IEnumerable<BasicStationModel> GetBasicStations()
        {
            return new List<BasicStationModel>
            {
                new BasicStationModel{ Id = -1, Name = "Szczakowa Południe" },
                new BasicStationModel{ Id = -2, Name = "Ciężkowice" },
                new BasicStationModel{ Id = -3, Name = "Pieczyska" }
            };
        }
    }
}
