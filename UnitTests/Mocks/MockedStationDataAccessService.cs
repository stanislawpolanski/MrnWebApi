using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Station;
using System;
using System.Collections.Generic;

namespace UnitTests.Mocks
{
    class MockedStationDataAccessService : IStationDataAccessService
    {
        public ICollection<StationBasicModel> GetBasicStations()
        {
            throw new NotImplementedException();
        }

        public StationDetailedModel GetDetailedStation(int id)
        {
            return new StationDetailedModel()
            {
                Id = -1,
                Name = "Test station",
                TypeOfAStationInfo = new TypeOfAStationModel(),
                OwnerInfo = new OwnerModel()
            };
        }
    }
}
