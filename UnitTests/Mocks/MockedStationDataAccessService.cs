﻿using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Station;
using System;
using System.Collections.Generic;

namespace UnitTests.Mocks
{
    class MockedStationDataAccessService : IStationDataAccessService
    {
        public int AddStation(StationModel inputStation)
        {
            throw new NotImplementedException();
        }

        public void DeleteStationById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<StationModel> GetBasicStations()
        {
            throw new NotImplementedException();
        }

        public StationModel GetDetailedStation(int id)
        {
            return new StationModel()
            {
                Id = -1,
                Name = "Test station",
                TypeOfAStationInfo = new TypeOfAStationModel(),
                OwnerInfo = new OwnerModel()
            };
        }

        public void UpdateStation(StationModel station)
        {
            throw new NotImplementedException();
        }
    }
}
