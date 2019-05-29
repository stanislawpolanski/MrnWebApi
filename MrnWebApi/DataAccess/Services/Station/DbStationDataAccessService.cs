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

        public ICollection<BasicStationModel> GetBasicStations()
        {
            return dbContext.Stations
                .Join(dbContext.ObjectsOfInterest,
                    stationEntity => stationEntity.Id,
                    objectOfInterestEntity => objectOfInterestEntity.Id,
                    (stationEntity, objectOfInterestEntity) 
                        => new BasicStationModel { Id = stationEntity.Id, Name = objectOfInterestEntity.Name })
                .ToList();
        }
    }
}
