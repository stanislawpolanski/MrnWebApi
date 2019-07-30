using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Railway;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    class MockedRailwayDataAccessService : IRailwayDataAccessService
    {
        public Task<IEnumerable<RailwayModel>> GetRailwaysByStationIdAsync(int stationId)
        {
            IEnumerable<RailwayModel> result = new List<RailwayModel>()
            {
                new RailwayModel(),
                new RailwayModel()
            };
            return Task.FromResult(result);
        }
    }
}
