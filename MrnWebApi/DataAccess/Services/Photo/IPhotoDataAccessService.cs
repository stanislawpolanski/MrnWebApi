using MrnWebApi.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Photo
{
    public interface IPhotoDataAccessService
    {
        Task<IEnumerable<PhotoDTO>> GetPhotosByStationIdAsync(int stationId);
    }
}
