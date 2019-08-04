using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.Logic.StationService.Inner
{
    public class PostStationLogicProcessor : AbstractStationLogicProcessor
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
                .PostStationAsync(station);
        }
    }
}
