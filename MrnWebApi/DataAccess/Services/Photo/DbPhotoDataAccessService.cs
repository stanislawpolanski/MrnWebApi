using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.Photo
{
    public class DbPhotoDataAccessService : DbDataAccessAbstractService, IPhotoDataAccessService
    {
        public DbPhotoDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public async Task<IEnumerable<PhotoModel>> GetPhotosByStationIdAsync(int stationId)
        {
            IEnumerable<PhotoModel> result = await context
                .Photos
                .Where(photo => photo
                    .PhotosToObjectsOfInterest
                    .Any(relation => relation.ObjectOfInterestId.Equals(stationId)))
                .Select(photoEntity =>
                    new PhotoModel()
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
