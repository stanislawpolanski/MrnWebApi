using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.RailwayUnit;

namespace UnitTests.Mocks
{
    class MockedRailwayUnitDataAccessService : IRailwayUnitDataAccessService
    {
        public RailwayUnitModel GetRailwayUnitByStation(StationModel station)
        {
            return new RailwayUnitModel();
        }
    }
}
