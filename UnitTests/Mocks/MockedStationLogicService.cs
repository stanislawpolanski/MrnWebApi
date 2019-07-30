using MrnWebApi.Common.Models;
using MrnWebApi.Logic.StationService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    class MockedStationLogicService : IStationLogicService
    {
        public MockedStationLogicService()
        {
        }

        public void AddStationAsync(StationModel inputStation)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteStationById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<StationModel> GetAllBasicStations()
        {
            return new List<StationModel>()
            {
                new StationModel() { Id = 15, Name = "Testowa stacja"},
                new StationModel() { Id = 789, Name = "Druga stacja"}
            };
        }

        public Task<StationModel> GetDetailedStationByIdAsync(int id)
        {
            return Task.FromResult(
                new StationModel()
                {
                    RailwayUnit = new RailwayUnitModel()
                });
        }

        public async Task UpdateStationAsync(StationModel inputStation)
        {
            throw new System.NotImplementedException();
        }

        Task IStationLogicService.AddStationAsync(StationModel inputStation)
        {
            throw new System.NotImplementedException();
        }
    }
}
