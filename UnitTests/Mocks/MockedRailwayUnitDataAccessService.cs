using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.RailwayUnit;

namespace UnitTests.Mocks
{
    class MockedRailwayUnitDataAccessService : IRailwayUnitDataAccessService
    {
        public RailwayUnitModel GetRailwayUnitByStationId(int stationId)
        {
            return new RailwayUnitModel();
        }
    }
}
