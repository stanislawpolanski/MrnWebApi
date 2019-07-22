using MrnWebApi.Common.Models;
using MrnWebApi.Controllers;
using MrnWebApi.Logic.StationService;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Mocks;
using Xunit;

namespace UnitTests.ControllersTests
{
    public class StationControllerTests
    {
        [Fact]
        public void EnrichesStationsWithUrls()
        {
            IEnumerable<StationModel> expectedList = GetExpectedStationModels();
            IStationLogicService mockedLogicService = new MockedStationLogicService();
            StationController controller = new StationController(mockedLogicService);

            IEnumerable<StationModel> actualList = controller.GetAllStations();

            actualList.ToList().ForEach(actual =>
                {
                    StationModel expected =
                        expectedList.ToList().Where(x => x.Id.Equals(actual.Id)).FirstOrDefault();
                    Assert.Equal(actual.Name, expected.Name);
                    Assert.Equal(actual.Url, expected.Url);
                });
        }

        private IEnumerable<StationModel> GetExpectedStationModels()
        {
            return new List<StationModel>()
            {
                new StationModel() { Id = 15, Name = "Testowa stacja", Url = "/api/station/15" },
                new StationModel() { Id = 789, Name = "Druga stacja", Url = "/api/station/789" }
            };
        }
    }
}
