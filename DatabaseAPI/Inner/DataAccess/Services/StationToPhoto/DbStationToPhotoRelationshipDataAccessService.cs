using DatabaseAPI.Inner.Common.DTOs;
using DatabaseAPI.Inner.DataAccess.Inner.Scaffold;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseAPI.Inner.DataAccess.Services.StationToPhoto
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

        public void UpdateRelationships(StationDTO station, IEnumerable<PhotoDTO> photos)
        {
            throw new NotImplementedException();
        }
    }
}
