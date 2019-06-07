using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Photo;
using System.Collections.Generic;

namespace UnitTests.Mocks
{
    class MockedPhotoDataAccessService : IPhotoDataAccessService
    {
        public IEnumerable<PhotoModel> GetPhotosByStationId(int stationId)
        {
            return new List<PhotoModel>()
            {
                new PhotoModel(),
                new PhotoModel()
            };
        }
    }
}
