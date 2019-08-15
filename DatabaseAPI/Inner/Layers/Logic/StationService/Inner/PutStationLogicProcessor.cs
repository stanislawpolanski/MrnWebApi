using System;
using System.Threading.Tasks;

namespace DatabaseAPI.Logic.StationService.Inner
{
    public class PutStationLogicProcessor : AbstractStationLogicProcessor
    {
        public override Task ProcessGeometryWithRailwayUnitAsync()
        {
            throw new NotImplementedException();
        }

        public override Task ProcessPhotosAsync()
        {
            throw new NotImplementedException();
        }

        public override Task ProcessRailwaysAsync()
        {
            throw new NotImplementedException();
        }

        public override async Task ProcessStationRootAsync()
        {
            await dataAccessServicesFactory
                .StationDataAccessService
                .PutStationAsync(station);
        }
    }
}
