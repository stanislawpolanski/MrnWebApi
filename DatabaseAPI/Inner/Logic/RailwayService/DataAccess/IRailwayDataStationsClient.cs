using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RailwayService.DataAccess
{
    public interface IRailwayDataStationsClient
    {
        Task<IEnumerable<StationOnARailwayLocationDTO>>
            GetStationsLocationsOnARailway(RailwayDTO railway);
    }
}
