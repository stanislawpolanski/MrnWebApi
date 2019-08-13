using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.DTOs;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Photo
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
                //todo to be replaced by dto builder
                .Select(photoEntity =>
                    new PhotoDTO()
                    {
                        Id = photoEntity.Id,
                        FilePath = photoEntity.FilePath
                    }
                )
                .ToListAsync();
            return result;
        }
    }
}
