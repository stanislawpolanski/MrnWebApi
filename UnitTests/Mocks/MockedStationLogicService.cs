using MrnWebApi.Common.Models;
using MrnWebApi.Logic.StationService;
using System.Collections.Generic;

namespace UnitTests.Mocks
{
    class MockedStationLogicService : IStationLogicService
    {
        public MockedStationLogicService()
        {
        }

        public IEnumerable<StationBasicModel> GetBasicStations()
        {
            return new List<StationBasicModel>()
            {
                new StationBasicModel() { Id = 15, Name = "Testowa stacja"},
                new StationBasicModel() { Id = 789, Name = "Druga stacja"}
            };
        }

        public StationDetailedModel GetDetailedStation(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
