using MrnWebApi.Common.Models;
using MrnWebApi.Logic.StationService;
using System.Collections.Generic;
using System.Linq;
using MrnWebApi.DataAccess.ServicesFactory;
using UnitTests.Mocks;
using Xunit;


namespace UnitTests.LogicTests
{
    public class StationLogicTests
    {
        [Fact]
        public void CombinesDataAccessProductsIntoDetailedStation()
        {
            StationModel expected = GetExpectedStation();
            IStationLogicService service = new StationLogicService(new DataAccessServicesFactory(
                new MockedStationDataAccessService(),
                new MockedPhotoDataAccessService(),
                new MockedRailwayDataAccessService(),
                new MockedRailwayUnitDataAccessService(),
                new MockedGeometryRailwayDataAccessService(),
                null,
                null));

            StationModel actual = service.GetDetailedStationById(-1);

            Assert.NotNull(actual.RailwayUnit);
            Assert.Equal(expected.Photos.Count(), actual.Photos.Count());
            Assert.Equal(expected.Railways.Count(), actual.Railways.Count());
        }

        private StationModel GetExpectedStation()
        {
            return new StationModel()
            {
                Id = -1,
                OwnerInfo = new OwnerModel(),
                Name = "Test station",
                Photos = new List<PhotoModel>()
                {
                    new PhotoModel(),
                    new PhotoModel()
                },
                Railways = new List<RailwayModel>()
                {
                    new RailwayModel(),
                    new RailwayModel()
                },
                RailwayUnit = new RailwayUnitModel(),
                TypeOfAStationInfo = new TypeOfAStationModel()
            };
        }
    }
}
