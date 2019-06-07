﻿using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Photo;
using MrnWebApi.DataAccess.Services.Railway;
using MrnWebApi.DataAccess.Services.RailwayUnit;
using MrnWebApi.DataAccess.Services.Station;
using System.Collections.Generic;
using System.Linq;

namespace MrnWebApi.Logic.StationService
{
    public class StationLogicService : IStationLogicService
    {
        private IStationDataAccessService stationDataAccessService;
        private IPhotoDataAccessService photosDataAccessService;
        private IRailwayDataAccessService railwaysDataAccessService;
        private IRailwayUnitDataAccessService railwayUnitDataAccessService;

        public StationLogicService(IStationDataAccessService injectedStationDataAccessService,
            IPhotoDataAccessService injectedPhotosDataAccessSercice,
            IRailwayDataAccessService injectedRailwaysDataAccessService,
            IRailwayUnitDataAccessService injectedRailwayUnitDataAccessService)
        {
            stationDataAccessService = injectedStationDataAccessService;
            photosDataAccessService = injectedPhotosDataAccessSercice;
            railwaysDataAccessService = injectedRailwaysDataAccessService;
            railwayUnitDataAccessService = injectedRailwayUnitDataAccessService;
        }

        public IEnumerable<StationBasicModel> GetBasicStations()
        {
            return stationDataAccessService.GetBasicStations().OrderBy(station => station.Name);
        }

        public StationDetailedModel GetDetailedStation(int id)
        {
            StationDetailedModel model = stationDataAccessService.GetDetailedStation(id);
            model.Railways = railwaysDataAccessService.GetRailwaysByStationId(id);
            model.Photos = photosDataAccessService.GetPhotosByStationId(id);
            model.RailwayUnit = railwayUnitDataAccessService.GetRailwayUnitByStationId(id);

            return model;
        }
    }
}
