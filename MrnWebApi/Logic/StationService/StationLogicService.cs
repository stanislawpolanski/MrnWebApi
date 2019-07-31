using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Geometry;
using MrnWebApi.DataAccess.Services.Photo;
using MrnWebApi.DataAccess.Services.Railway;
using MrnWebApi.DataAccess.Services.RailwayUnit;
using MrnWebApi.DataAccess.Services.Station;
using System.Collections.Generic;
using System.Linq;
using MrnWebApi.DataAccess.ServicesFactory;
using System.Threading.Tasks;

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

        public async Task AddStationAsync(StationModel inputStation)
        {
            await stationDataAccessService.AddStationAsync(inputStation);
        }

        public async Task DeleteStationByIdAsync(int id)
        {
            await stationDataAccessService.DeleteStationByIdAsync(id);
        }

        public async Task<IEnumerable<StationModel>> GetAllBasicStationsAsync()
        {
            IEnumerable<StationModel> stations = await stationDataAccessService.GetBasicStationsAsync();
            return stations.OrderBy(station => station.Name);
        }

        public async Task<StationModel> GetDetailedStationByIdAsync(int id)
        {
            StationModel model = await stationDataAccessService.GetDetailedStationAsync(id);
            if(model == null)
            {
                return null;
            }
            model.Railways = await railwayDataAccessService.GetRailwaysByStationIdAsync(id);
            model.Photos = await photoDataAccessService.GetPhotosByStationIdAsync(id);
            model.SerialisedGeometry = await geometryDataAccessService.GetFirstGeometryByStationIdAsync(id);
            model.RailwayUnit = await railwayUnitDataAccessService.GetRailwayUnitByStationAsync(model);

            return model;
        }

        public async Task UpdateStationAsync(StationModel inputStation)
        {
            await stationDataAccessService.UpdateStationAsync(inputStation);
        }
    }
}
