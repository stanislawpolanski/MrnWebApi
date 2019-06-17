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

        public IEnumerable<StationModel> GetBasicStations()
        {
            return new List<StationModel>()
            {
                new StationModel() { Id = 15, Name = "Testowa stacja"},
                new StationModel() { Id = 789, Name = "Druga stacja"}
            };
        }

        public StationModel GetDetailedStation(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
