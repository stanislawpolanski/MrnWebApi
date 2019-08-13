using MrnWebApi.Common.DTOs;
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

        public async Task<IEnumerable<StationDTO>> GetAllBasicStationsAsync()
        {
            List<StationDTO> result = new List<StationDTO>()
            {
                new StationDTO() { Id = 15, Name = "Testowa stacja"},
                new StationDTO() { Id = 789, Name = "Druga stacja"}
            };
            return await Task.FromResult(result);
        }

        public Task<StationDTO> GetStationByIdAsync(int id)
        {
            return Task.FromResult(
                new StationDTO()
                {
                    RailwayUnit = new RailwayUnitDTO()
                });
        }

        public async Task PutStationAsync(StationDTO inputStation)
        {
            throw new System.NotImplementedException();
        }

        Task IStationLogicService.PostStationAsync(StationDTO inputStation)
        {
            throw new System.NotImplementedException();
        }

        Task IStationLogicService.DeleteStationByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
