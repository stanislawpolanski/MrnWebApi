using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.Logic.StationService.Inner
{
    public class DeleteStationLogicProcessor : AbstractStationLogicProcessor
    {
        public override async Task ProcessGeometryWithRailwayUnitAsync()
        {
            await dataAccessServicesFactory
                .GeometryDataAccessService
                .DeleteGeometriesByStationIdAsync(station.Id);
            await dataAccessServicesFactory
                .StationToRailwayRelationshipDataAccessService
                .DeleteGeometryInfoFromRelationshipByStationidAsync(station.Id);
        }

        public override async Task ProcessPhotosAsync()
        {
            await dataAccessServicesFactory
                .StationToPhotoRelationshipDataAccessService
                .DeleteRelationshipByStationIdAsync(station.Id);
        }

        public override async Task ProcessRailwaysAsync()
        {
            //if run before deleting geometry, then throw exception
            await dataAccessServicesFactory
                .StationToRailwayRelationshipDataAccessService
                .DeleteRelationshipsByStationIdAsync(station.Id);
        }

        public override async Task ProcessStationRootAsync()
        {
            //if ran before all the other methods, then throw exception
            await dataAccessServicesFactory
                .StationDataAccessService
                .DeleteStationByIdAsync(station.Id);
        }
    }
}
