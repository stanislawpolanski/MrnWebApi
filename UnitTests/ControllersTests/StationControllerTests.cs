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
            IEnumerable<StationBasicModel> expectedList = GetExpectedStationBasicModels();
            IStationLogicService mockedLogicService = new MockedStationLogicService();
            StationController controller = new StationController(mockedLogicService);

            IEnumerable<StationBasicModel> actualList = controller.Get();

            actualList.ToList().ForEach(actual =>
                {
                    StationBasicModel expected =
                        expectedList.ToList().Where(x => x.Id.Equals(actual.Id)).FirstOrDefault();
                    Assert.Equal(actual.Name, expected.Name);
                    Assert.Equal(actual.Url, expected.Url);
                });
        }

        private IEnumerable<StationBasicModel> GetExpectedStationBasicModels()
        {
            return new List<StationBasicModel>()
            {
                new StationBasicModel() { Id = 15, Name = "Testowa stacja", Url = "/api/station/15" },
                new StationBasicModel() { Id = 789, Name = "Druga stacja", Url = "/api/station/789" }
            };
        }
    }
}
