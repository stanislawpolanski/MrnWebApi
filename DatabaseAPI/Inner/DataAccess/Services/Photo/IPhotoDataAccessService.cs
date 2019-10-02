using DatabaseAPI.Inner.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.Photo
{
    public interface IPhotoDataAccessService
    {
        Task<IEnumerable<PhotoDTO>> GetPhotosByStationIdAsync(int stationId);
    }
}
