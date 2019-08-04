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
using MrnWebApi.Logic.StationService.Inner;

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

        public StationLogicService(DataAccessServicesFactory 
            injectedDataAccessServicesFactory)
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
            IEnumerable<StationModel> stations = await stationDataAccessService
                .GetBasicStationsAsync();
            return stations.OrderBy(station => station.Name);
        }

        public async Task<StationModel> GetDetailedStationByIdAsync(int inputId)
        {
            AbstractStationLogicProcessor processor =
                new GetStationLogicProcessor();
            InitialiseStationProcessor(inputId, processor);
            await RunProcessesOnStationProcessor(processor);
            return processor.GetStation();
        }

        private static async Task RunProcessesOnStationProcessor(AbstractStationLogicProcessor processor)
        {
            await processor.ProcessStationRootAsync();
            await processor.ProcessGeometryWithRailwayUnitAsync();
            await processor.ProcessPhotosAsync();
            await processor.ProcessRailwaysAsync();
        }

        private void InitialiseStationProcessor(int inputId, AbstractStationLogicProcessor processor)
        {
            processor.SetDataAccessServicesFactory(dataAccessServicesFactory);
            processor.SetStation(new StationModel() { Id = inputId });
        }

        public async Task UpdateStationAsync(StationModel inputStation)
        {
            await stationDataAccessService.UpdateStationAsync(inputStation);
        }
    }
}
