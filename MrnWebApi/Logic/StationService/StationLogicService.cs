using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Geometry;
using MrnWebApi.DataAccess.Services.Photo;
using MrnWebApi.DataAccess.Services.Railway;
using MrnWebApi.DataAccess.Services.RailwayUnit;
using MrnWebApi.DataAccess.Services.Station;
using System.Collections.Generic;
using System.Linq;
using MrnWebApi.DataAccess.ServicesFactory;

namespace MrnWebApi.Logic.StationService
{
    public class StationLogicService : IStationLogicService
    {
        private DataAccessServicesFactory dataAccessServicesFactory;

        private IStationDataAccessService stationDataAccessService
        {
            get => dataAccessServicesFactory.StationDataAccessService;
        }
        private IPhotoDataAccessService photoDataAccessService
        {
            get => dataAccessServicesFactory.PhotoDataAccessService;
        }
        private IRailwayDataAccessService railwayDataAccessService
        {
            get => dataAccessServicesFactory.RailwayDataAccessService;
        }
        private IRailwayUnitDataAccessService railwayUnitDataAccessService
        {
            get => dataAccessServicesFactory.RailwayUnitDataAccessService;
        }
        private IGeometryDataAccessService geometryDataAccessService
        {
            get => dataAccessServicesFactory.GeometryDataAccessService;
        }

        public StationLogicService(DataAccessServicesFactory injectedDataAccessServicesFactory)
        {
            dataAccessServicesFactory = injectedDataAccessServicesFactory;
        }

        public void AddStation(StationModel inputStation)
        {
            int newStationId = stationDataAccessService.AddStation(inputStation);
        }

        public void DeleteStationById(int id)
        {
            stationDataAccessService.DeleteStationById(id);
        }

        public IEnumerable<StationModel> GetAllBasicStations()
        {
            return stationDataAccessService.GetBasicStations().OrderBy(station => station.Name);
        }

        public StationModel GetDetailedStationById(int id)
        {
            StationModel model = stationDataAccessService.GetDetailedStation(id);
            model.Railways = railwayDataAccessService.GetRailwaysByStationId(id);
            model.Photos = photoDataAccessService.GetPhotosByStationId(id);
            model.SerialisedGeometry = geometryDataAccessService.GetFirstGeometryByStationId(id);
            model.RailwayUnit = railwayUnitDataAccessService.GetRailwayUnitByStation(model);

            return model;
        }

        public void UpdateStation(StationModel inputStation)
        {
            stationDataAccessService.UpdateStation(inputStation);
        }
    }
}
