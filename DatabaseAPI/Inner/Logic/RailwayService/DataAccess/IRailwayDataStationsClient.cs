using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Common.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients
{
    public interface IRailwayDataStationsClient
    {
        Task<IEnumerable<StationOnARailwayLocationDTO>> 
            GetStationsLocationsOnARailway(RailwayDTO railway);
    }
}
