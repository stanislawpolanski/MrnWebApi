using MrnWebApi.Common.Models;
using MrnWebApi.Controllers;
using MrnWebApi.Logic.StationService;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Mocks;
using Xunit;

namespace UnitTests.UnitTests.ControllersTests
{
    public class StationControllerTests
    {
        [Fact]
        public async void EnrichesStationsWithUrls()
        {
            IEnumerable<StationDTO> expectedList = GetExpectedStationModels();
            IStationLogicService mockedLogicService = new MockedStationLogicService();
            StationController controller = new StationController(mockedLogicService);

            IEnumerable<StationDTO> actualList = await controller.GetAllStations();

            actualList.ToList().ForEach(actual =>
                {
                    StationDTO expected =
                        expectedList.ToList().Where(x => x.Id.Equals(actual.Id)).FirstOrDefault();
                    Assert.Equal(actual.Name, expected.Name);
                    Assert.Equal(actual.Url, expected.Url);
                });
        }

        private IEnumerable<StationDTO> GetExpectedStationModels()
        {
            return new List<StationDTO>()
            {
                new StationDTO() { Id = 15, Name = "Testowa stacja", Url = "/api/station/15" },
                new StationDTO() { Id = 789, Name = "Druga stacja", Url = "/api/station/789" }
            };
        }
    }
}
