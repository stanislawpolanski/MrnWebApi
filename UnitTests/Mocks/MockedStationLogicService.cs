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

        public void AddStation(StationModel inputStation)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteStationById(int id)
        {
            throw new System.NotImplementedException();
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
