using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MrnWebApi.DataAccess.Services.Photo
{
    public class DbPhotoDataAccessService : IPhotoDataAccessService
    {
        private MRN_developContext dbContext;
        public DbPhotoDataAccessService(MRN_developContext injectedContext)
        {
            dbContext = injectedContext;
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
