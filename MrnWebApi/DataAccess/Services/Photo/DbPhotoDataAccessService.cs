using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MrnWebApi.DataAccess.Services.Photo
{
    public class DbPhotoDataAccessService : DbDataAccessAbstractService, IPhotoDataAccessService
    {
        public DbPhotoDataAccessService(MRN_developContext injectedContext) : base(injectedContext)
        {
        }

        public IEnumerable<PhotoModel> GetPhotosByStationId(int stationId)
        {
            return dbContext
                .Photos
                .Where(photo => photo.PhotosToObjectsOfInterest.FirstOrDefault().ObjectOfInterestId.Equals(stationId))
                .Select(photoEntity =>
                    new PhotoModel()
                    {
                        Id = photoEntity.Id,
                        FilePath = photoEntity.FilePath
                    }
                )
                .ToList();
        }
    }
}
