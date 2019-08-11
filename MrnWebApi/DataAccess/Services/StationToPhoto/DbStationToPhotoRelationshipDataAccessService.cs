using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrnWebApi.DataAccess.Services.StationToPhoto
{
    public class DbStationToPhotoRelationshipDataAccessService :
        DbDataAccessAbstractService,
        IStationToPhotoRelationshipDataAccessService
    {
        public DbStationToPhotoRelationshipDataAccessService(MRN_developContext injectedContext) :
            base(injectedContext)
        {
        }

        public async Task DeleteRelationshipByStationIdAsync(int stationId)
        {
            IEnumerable<PhotosToObjectsOfInterest> relationshipsToBeDeleted =
                await GetRelationshipsToBeDeleted(stationId);
            context
                .PhotosToObjectsOfInterest
                .RemoveRange(relationshipsToBeDeleted);
            await context.SaveChangesAsync();
        }

        private Task<List<PhotosToObjectsOfInterest>>
            GetRelationshipsToBeDeleted(int stationId)
        {
            return context
                .PhotosToObjectsOfInterest
                .Where(entity => entity.ObjectOfInterestId.Equals(stationId))
                .ToListAsync();
        }

        public void UpdateRelationships(StationModel station, IEnumerable<PhotoModel> photos)
        {
            throw new NotImplementedException();
            /*
            int stationId = station.Id;
            HashSet<int> updatePhotoIds = new HashSet<int>(photos.Select(photo => photo.Id));

            List<PhotosToObjectsOfInterest> existingInDatabase = context.PhotosToObjectsOfInterest
                .Where(relationship => relationship.ObjectOfInterestId.Equals(stationId))
                .ToList();
                */

        }
    }
}
