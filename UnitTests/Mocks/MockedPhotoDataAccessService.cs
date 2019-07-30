using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Services.Photo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests.Mocks
{
    class MockedPhotoDataAccessService : IPhotoDataAccessService
    {

        public Task<IEnumerable<PhotoModel>> GetPhotosByStationIdAsync(int stationId)
        {
            IEnumerable<PhotoModel> result = new List<PhotoModel>()
            {
                new PhotoModel(),
                new PhotoModel()
            };
            return Task.FromResult(result);
        }
    }
}
