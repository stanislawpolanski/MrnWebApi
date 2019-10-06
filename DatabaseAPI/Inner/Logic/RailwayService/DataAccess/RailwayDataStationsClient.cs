using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.DataAccess.Services.Station;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.Logic.RailwayService.DataAccess
{
    public class RailwayDataStationsClient : IRailwayDataStationsClient
    {
        private IStationDataAccessService service;

        public RailwayDataStationsClient(IStationDataAccessService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<StationOnARailwayLocationDTO>>
            GetStationsLocationsOnARailway(RailwayDTO railway)
        {
            return await service.GetStationsLocationsByRailwayAsync(railway);
        }
    }
}
