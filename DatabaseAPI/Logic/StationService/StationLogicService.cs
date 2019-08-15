﻿using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Services.Geometry;
using DatabaseAPI.DataAccess.Services.Photo;
using DatabaseAPI.DataAccess.Services.Railway;
using DatabaseAPI.DataAccess.Services.RailwayUnit;
using DatabaseAPI.DataAccess.Services.Station;
using DatabaseAPI.DataAccess.ServicesFactory;
using DatabaseAPI.Logic.StationService.Inner;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Logic.StationService
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

        public async Task PostStationAsync(StationDTO inputStation)
        {
            AbstractStationLogicProcessor processor =
                new PostStationLogicProcessor();
            InitialiseProcessor(inputStation, processor);
            await processor.ProcessStationRootAsync();
        }

        private void InitialiseProcessor(StationDTO inputStation,
            AbstractStationLogicProcessor processor)
        {
            processor.SetDataAccessServicesFactory(dataAccessServicesFactory);
            processor.SetStation(inputStation);
        }

        public async Task DeleteStationByIdAsync(int inputId)
        {
            AbstractStationLogicProcessor processor =
                new DeleteStationLogicProcessor();
            //todo to be refactored to dto builder
            StationDTO stationModel = new StationDTO
                .Builder()
                .Id(inputId)
                .Build();
            InitialiseProcessor(stationModel, processor);
            await processor.ProcessGeometryWithRailwayUnitAsync();
            await processor.ProcessPhotosAsync();
            await processor.ProcessRailwaysAsync();
            await processor.ProcessStationRootAsync();
        }

        public async Task<IEnumerable<StationDTO>> GetAllBasicStationsAsync()
        {
            IEnumerable<StationDTO> stations =
                await stationDataAccessService.GetBasicStationsAsync();
            return stations.OrderBy(station => station.Name);
        }

        public async Task<StationDTO> GetStationByIdAsync(int inputId)
        {
            AbstractStationLogicProcessor processor =
                new GetStationLogicProcessor();
            //todo to be refactored to dto builder
            StationDTO stationModel = new StationDTO() { Id = inputId };
            InitialiseProcessor(stationModel, processor);
            await processor.ProcessStationRootAsync();
            await processor.ProcessGeometryWithRailwayUnitAsync();
            await processor.ProcessPhotosAsync();
            await processor.ProcessRailwaysAsync();
            return processor.GetStation();
        }

        public async Task PutStationAsync(StationDTO inputStation)
        {
            AbstractStationLogicProcessor processor =
                new PutStationLogicProcessor();
            InitialiseProcessor(inputStation, processor);
            await processor.ProcessStationRootAsync();
        }
    }
}