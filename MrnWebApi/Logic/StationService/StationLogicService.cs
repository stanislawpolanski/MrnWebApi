using MrnWebApi.Common;
using MrnWebApi.Common.Models;
using MrnWebApi.Common.Routing;
using MrnWebApi.DataAccess.Services.Station;
using System.Collections.Generic;
using System.Linq;

namespace MrnWebApi.Logic.StationService
{
    public class StationLogicService : IStationLogicService
    {
        private IStationDataAccessService stationDataAccessService;

        public StationLogicService(IStationDataAccessService injectedService)
        {
            stationDataAccessService = injectedService;
        }

        public IEnumerable<BasicStationModel> GetBasicStations()
        {
            List<BasicStationModel> models = stationDataAccessService
                .GetBasicStations()
                .ToList();

            models.ForEach(station => 
                station.Url = new UriRoute.Builder()
                    .Path(Paths.STATION_PATH)
                    .Path(station.Id.ToString())
                    .Build()
                    .ToString());

            return models;
        }
    }
}
