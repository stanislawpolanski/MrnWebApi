using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Geometry;
using MrnWebApi.DataAccess.Services.Photo;
using MrnWebApi.DataAccess.Services.Railway;
using MrnWebApi.DataAccess.Services.RailwayUnit;
using MrnWebApi.DataAccess.Services.Station;
using MrnWebApi.DataAccess.ServicesFactory;
using MrnWebApi.Logic.StationService.Inner;
using System.Collections.Generic;
using System.Linq;
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

        public StationLogicService(DataAccessServicesFactory 
            injectedDataAccessServicesFactory)
        {
            dataAccessServicesFactory = injectedDataAccessServicesFactory;
        }

        public async Task PostStationAsync(StationModel inputStation)
        {
            AbstractStationLogicProcessor processor =
                new PostStationLogicProcessor();
            processor.SetDataAccessServicesFactory(dataAccessServicesFactory);
            processor.SetStation(inputStation);
            await processor.ProcessStationRootAsync();
        }

        public async Task DeleteStationByIdAsync(int inputId)
        {
            AbstractStationLogicProcessor processor =
                new DeleteStationLogicProcessor();

            processor.SetDataAccessServicesFactory(dataAccessServicesFactory);
            processor.SetStation(new StationModel() { Id = inputId });
            await processor.ProcessStationRootAsync();
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

        public async Task PutStationAsync(StationModel inputStation)
        {
            AbstractStationLogicProcessor processor =
                new PutStationLogicProcessor();

            processor.SetDataAccessServicesFactory(dataAccessServicesFactory);
            processor.SetStation(inputStation);

            await processor.ProcessStationRootAsync();
        }
    }
}
