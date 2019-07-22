using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System.Linq.Expressions;

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
