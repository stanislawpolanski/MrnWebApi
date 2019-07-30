using System.Threading.Tasks;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.RailwayUnit;

namespace UnitTests.Mocks
{
    class MockedRailwayUnitDataAccessService : IRailwayUnitDataAccessService
    {
        public async Task<RailwayUnitModel> GetRailwayUnitByStationAsync(StationModel station)
        {
            return await Task.FromResult(new RailwayUnitModel());
        }
    }
}
