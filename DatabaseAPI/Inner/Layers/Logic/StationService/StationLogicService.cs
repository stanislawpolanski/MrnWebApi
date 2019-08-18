using DatabaseAPI.Common.DTOs;
using DatabaseAPI.DataAccess.Services.Geometry;
using DatabaseAPI.DataAccess.Services.Photo;
using DatabaseAPI.DataAccess.Services.Railway;
using DatabaseAPI.DataAccess.Services.RailwayUnit;
using DatabaseAPI.DataAccess.Services.Station;
using DatabaseAPI.DataAccess.ServicesFactory;
using DatabaseAPI.Inner.Layers.Logic.StationService.Inner.DetailsServices;
using DatabaseAPI.Logic.StationService.Inner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Logic.StationService
{
    public class StationLogicService : IStationLogicService
    {
        private IEssentialDataStationLogicService essentialsService;
        private IGeographicDataStationLogicService geographicsService;
        public StationLogicService(
            IEssentialDataStationLogicService essentialsService,
            IGeographicDataStationLogicService geographicsService)
        {
            this.essentialsService = essentialsService;
            this.geographicsService = geographicsService;
        }

        public async Task PostStationAsync(StationDTO inputStation)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteStationByIdAsync(int inputId)
        {
            StationDTO stationModel = new StationDTO
                .Builder()
                .Id(inputId)
                .Build();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StationDTO>> GetAllBasicStationsAsync()
        {
            throw new NotImplementedException();
            IEnumerable<StationDTO> stations = null;
            return stations.OrderBy(station => station.Name);
        }

        public async Task<StationDTO> GetStationByIdAsync(int inputId)
        {
            //todo to be refactored to dto builder
            StationDTO station = new StationDTO
                .Builder()
                .Id(inputId)
                .Build();
            await essentialsService.FillStationWithEssentialDataAsync(station);
            await geographicsService.FillStationWithGeographicDataAsync(station);
            return station;
        }

        public async Task PutStationAsync(StationDTO inputStation)
        {
            throw new NotImplementedException();
        }
    }
}
