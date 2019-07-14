using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Geometry;
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
        private IPhotoDataAccessService photoDataAccessService;
        private IRailwayDataAccessService railwayDataAccessService;
        private IRailwayUnitDataAccessService railwayUnitDataAccessService;
        private IGeometryDataAccessService geometryDataAccessService;

        public StationLogicService(IStationDataAccessService injectedStationDataAccessService,
            IPhotoDataAccessService injectedPhotosDataAccessSercice,
            IRailwayDataAccessService injectedRailwaysDataAccessService,
            IRailwayUnitDataAccessService injectedRailwayUnitDataAccessService,
            IGeometryDataAccessService injectedGeometryDataAccessService)
        {
            stationDataAccessService = injectedStationDataAccessService;
            photoDataAccessService = injectedPhotosDataAccessSercice;
            railwayDataAccessService = injectedRailwaysDataAccessService;
            railwayUnitDataAccessService = injectedRailwayUnitDataAccessService;
            geometryDataAccessService = injectedGeometryDataAccessService;
        }

        public void AddStation(StationModel inputStation)
        {
            int newStationId = stationDataAccessService.AddStation(inputStation);
        }

        public void DeleteStationById(int id)
        {
            stationDataAccessService.DeleteStationById(id);
        }

        public IEnumerable<StationModel> GetBasicStations()
        {
            return stationDataAccessService.GetBasicStations().OrderBy(station => station.Name);
        }

        public StationModel GetDetailedStation(int id)
        {
            StationModel model = stationDataAccessService.GetDetailedStation(id);
            model.Railways = railwayDataAccessService.GetRailwaysByStationId(id);
            model.Photos = photoDataAccessService.GetPhotosByStationId(id);
            model.SerialisedGeometry = geometryDataAccessService.GetFirstGeometryByStationId(id);
            model.RailwayUnit = railwayUnitDataAccessService.GetRailwayUnitByStation(model);

            return model;
        }
    }
}
