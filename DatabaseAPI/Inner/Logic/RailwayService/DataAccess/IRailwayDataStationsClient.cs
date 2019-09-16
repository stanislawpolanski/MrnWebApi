using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients
{
    public interface IRailwayDataStationsClient
    {
        Task<IEnumerable<StationOnARailwayLocationDTO>>
            GetStationsLocationsOnARailway(RailwayDTO railway);
    }
}
