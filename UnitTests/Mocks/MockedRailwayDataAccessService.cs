using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Railway;
using System.Collections.Generic;

namespace UnitTests.Mocks
{
    class MockedRailwayDataAccessService : IRailwayDataAccessService
    {
        public IEnumerable<RailwayModel> GetRailwaysByStationId(int stationId)
        {
            return new List<RailwayModel>()
            {
                new RailwayModel(),
                new RailwayModel()
            };
        }
    }
}
