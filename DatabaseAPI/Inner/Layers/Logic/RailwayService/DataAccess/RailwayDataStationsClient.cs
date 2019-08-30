using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Common.DTOs;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients
{
    public class RailwayDataStationsClient : IRailwayDataStationsClient
    {
        public Task<IEnumerable<StationOnARailwayLocationDTO>> 
            GetStationsLocationsOnARailway(RailwayDTO railway)
        {
            throw new NotImplementedException();
        }
    }
}
