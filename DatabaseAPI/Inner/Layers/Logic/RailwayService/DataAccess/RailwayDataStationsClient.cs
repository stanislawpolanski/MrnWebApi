using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Services.Station;
using DatabaseAPI.Inner.Common.DTOs;

namespace DatabaseAPI.Inner.Layers.Logic.RailwayService.DataAccessClients
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
