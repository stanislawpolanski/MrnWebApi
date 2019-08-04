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

        public async Task<IEnumerable<StationModel>> GetAllBasicStationsAsync()
        {
            List<StationModel> result = new List<StationModel>()
            {
                new StationModel() { Id = 15, Name = "Testowa stacja"},
                new StationModel() { Id = 789, Name = "Druga stacja"}
            };
            return await Task.FromResult(result);
        }

        public Task<StationModel> GetStationByIdAsync(int id)
        {
            return Task.FromResult(
                new StationModel()
                {
                    RailwayUnit = new RailwayUnitModel()
                });
        }

        public async Task PutStationAsync(StationModel inputStation)
        {
            throw new System.NotImplementedException();
        }

        Task IStationLogicService.PostStationAsync(StationModel inputStation)
        {
            throw new System.NotImplementedException();
        }

        Task IStationLogicService.DeleteStationByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
