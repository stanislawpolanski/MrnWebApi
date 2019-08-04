using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.ServicesFactory;

namespace MrnWebApi.Logic.StationService.Inner
{
    public class GetStationLogicProcessor : AbstractStationLogicProcessor
    {
        public GetStationLogicProcessor() : base()
        {
        }

        public async override Task ProcessGeometryWithRailwayUnitAsync()
        {
            await ProcessGeometryAsync();
            await ProcessRailwayUnitAsync();
        }

        private async Task ProcessRailwayUnitAsync()
        {
            station.RailwayUnit = await dataAccessServicesFactory
                .RailwayUnitDataAccessService
                .GetRailwayUnitByStationAsync(station);
        }

        private async Task ProcessGeometryAsync()
        {
            station.SerialisedGeometry = await dataAccessServicesFactory
               .GeometryDataAccessService
               .GetFirstGeometryByStationIdAsync(station.Id);
        }

        public async override Task ProcessPhotosAsync()
        {
            station.Photos = await dataAccessServicesFactory
                .PhotoDataAccessService
                .GetPhotosByStationIdAsync(station.Id);
        }

        public async override Task ProcessRailwaysAsync()
        {
            station.Railways = await dataAccessServicesFactory
                .RailwayDataAccessService
                .GetRailwaysByStationIdAsync(station.Id);
        }

        public async override Task ProcessStationRootAsync()
        {
            station = await dataAccessServicesFactory
               .StationDataAccessService
               .GetDetailedStationAsync(station.Id);
        }
    }
}
