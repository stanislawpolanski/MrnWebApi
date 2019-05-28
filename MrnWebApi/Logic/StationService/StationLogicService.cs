﻿using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Station;
using System.Collections.Generic;

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
            return stationDataAccessService.GetBasicStations();
        }
    }
}
