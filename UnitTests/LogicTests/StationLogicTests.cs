﻿using MrnWebApi.Common.Models;
using MrnWebApi.Logic.StationService;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Mocks;
using Xunit;


namespace UnitTests.LogicTests
{
    public class StationLogicTests
    {
        [Fact]
        public void CombinesDataAccessProductsIntoDetailedStation()
        {
            StationDetailedModel expected = GetExpectedStation();
            IStationLogicService service = new StationLogicService(new MockedStationDataAccessService(),
                new MockedPhotoDataAccessService(),
                new MockedRailwayDataAccessService(),
                new MockedRailwayUnitDataAccessService());

            StationDetailedModel actual = service.GetDetailedStation(-1);

            Assert.NotNull(actual.RailwayUnit);
            Assert.Equal(expected.Photos.Count(), actual.Photos.Count());
            Assert.Equal(expected.Railways.Count(), actual.Railways.Count());
        }

        private StationDetailedModel GetExpectedStation()
        {
            return new StationDetailedModel()
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