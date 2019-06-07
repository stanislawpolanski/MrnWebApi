using MrnWebApi.Common.Models;
using System.Collections.Generic;

namespace MrnWebApi.DataAccess.Services.Photo
{
    public interface IPhotoDataAccessService
    {
        IEnumerable<PhotoModel> GetPhotosByStationId(int stationId);
    }
}
