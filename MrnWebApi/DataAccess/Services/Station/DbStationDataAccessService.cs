using Microsoft.EntityFrameworkCore;
using MrnWebApi.Common.Models;
using MrnWebApi.DataAccess.Inner.Scaffold.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MrnWebApi.DataAccess.Services.Station
{
    public class DbStationDataAccessService : IStationDataAccessService
    {
        private MRN_developContext dbContext;

        public DbStationDataAccessService(MRN_developContext injectedContext)
        {
            dbContext = injectedContext;
        }

        public ICollection<StationBasicModel> GetBasicStations()
        {
            return dbContext.Stations
                .Join(dbContext.ObjectsOfInterest,
                    stationEntity => stationEntity.Id,
                    objectOfInterestEntity => objectOfInterestEntity.Id,
                    (stationEntity, objectOfInterestEntity)
                        => new StationBasicModel { Id = stationEntity.Id, Name = objectOfInterestEntity.Name })
                .ToList();
        }

        public StationDetailedModel GetDetailedStation(int id)
        {
            Stations entity = dbContext
                .Stations
                .Where(station => station.Id.Equals(id))
                .Include(station => station.ParentObjectOfInterest)
                .Include(station => station.ParentObjectOfInterest.Owner)
                .Include(station => station.TypeOfAstation)
                .First();

            return new StationDetailedModel()
            {
                Id = entity.Id,
                Name = entity.ParentObjectOfInterest.Name,
                OwnerInfo = new OwnerModel()
                {
                    Id = entity.ParentObjectOfInterest.Owner.Id,
                    Name = entity.ParentObjectOfInterest.Owner.Name
                },
                TypeOfAStationInfo = new TypeOfAStationModel()
                {
                    AbbreviatedName = entity.TypeOfAstation.AbbreviatedName,
                    Id = entity.TypeOfAstation.Id
                }
            };
        }
    }
}
