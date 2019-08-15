using DatabaseAPI.Common.DTOs;
using DatabaseAPI.Common.DTOs.FromEntitiesAdapters;
using DatabaseAPI.DataAccess.Inner.Scaffold;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatabaseAPI.DataAccess.Services.Photo
{
    public class DbPhotoDataAccessService : DbDataAccessAbstractService, IPhotoDataAccessService
    {
        public DbPhotoDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public async Task<IEnumerable<PhotoDTO>>
            GetPhotosByStationIdAsync(int stationId)
        {
            Expression<System.Func<Photos, bool>> photosThatShowsStationById =
            photo => photo
                .PhotosToObjectsOfInterest
                .Any(relation => relation.ObjectOfInterestId.Equals(stationId));

            IEnumerable<PhotoDTO> result = await context
                .Photos
                .Where(photosThatShowsStationById)
                .Select(photoEntity => new PhotoEntityToPhotoDTOAdapter(photoEntity))
                .ToListAsync();
            return result;
        }
    }
}
