using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using MrnWebApi.Common;

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
                station.Url = new Route.RouteBuilder()
                    .Path("api/values")
                    .Path(station.Id.ToString())
                    .Build()
                    .GetRoute());

            return models;
        }
    }
}
