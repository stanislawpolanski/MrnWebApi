using MrnWebApi.Common.Models;
using MrnWebApi.Controllers;
using MrnWebApi.Logic.StationService;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace UnitTests.ControllersTests
{
    public class StationControllerTests
    {
        [Fact]
        public void ReturnsStations()
        {
            IEnumerable<BasicStationControllerModel> expectedList = GetExpectedStationControllerModels();
            IStationLogicService mockedLogicService = new MockedLogicService();
            StationController controller = new StationController(mockedLogicService);

            IEnumerable<BasicStationControllerModel> actualList = controller.Get();

            actualList.ToList().ForEach(actual => 
                {
                    BasicStationControllerModel expected = 
                        expectedList.ToList().Where(x => x.Id.Equals(actual.Id)).FirstOrDefault();
                    Assert.Equal(actual.Name, expected.Name);
                    Assert.Equal(actual.Url, expected.Url);
                });
        }

        private IEnumerable<BasicStationControllerModel> GetExpectedStationControllerModels()
        {
            return new List<BasicStationControllerModel>()
            {
                new BasicStationControllerModel() { Id = 15, Name = "Testowa stacja", Url = "/api/station/15" },
                new BasicStationControllerModel() { Id = 789, Name = "Druga stacja", Url = "/api/station/789" }
            };
        }
    }

    internal class MockedLogicService : IStationLogicService
    {
        public MockedLogicService()
        {
        }

        public IEnumerable<BasicStationModel> GetBasicStations()
        {
            return new List<BasicStationModel>()
            {
                new BasicStationModel() { Id = 15, Name = "Testowa stacja"},
                new BasicStationModel() { Id = 789, Name = "Druga stacja"}
            };
        }
    }
}
